/*
  LICENSE
  -------
  Copyright (C) 2007 Ray Molenkamp
 
  Windows Vista / Windows 7 Loopback implementation by
  Lennart Denninger
 
  Loopback allows to capture all audio played by Windows.
  Basicly it's a software implementation of the "Record from stereomix" functionality,
  that some audiodrivers don't seem to supply anymore.

  This source code is provided 'as-is', without any express or implied
  warranty.  In no event will the authors be held liable for any damages
  arising from the use of this source code or the software it produces.

  Permission is granted to anyone to use this source code for any purpose,
  including commercial applications, and to alter it and redistribute it
  freely, subject to the following restrictions:

  1. The origin of this source code must not be misrepresented; you must not
     claim that you wrote the original source code.  If you use this source code
     in a product, an acknowledgment in the product documentation would be
     appreciated but is not required.
  2. Altered source versions must be plainly marked as such, and must not be
     misrepresented as being the original source code.
  3. This notice may not be removed or altered from any source distribution.
*/

using System;
using System.Collections.Generic;
using System.Text;

using NAudio.Wave;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace NAudio.CoreAudioApi
{
    /// <summary>
    /// Audio Capture using Wasapi
    /// See http://msdn.microsoft.com/en-us/library/dd370800%28VS.85%29.aspx
    /// </summary>
    public class WasapiLoopbackCapture : IWaveIn
    {
        private const long REFTIMES_PER_SEC = 10000;
        private const long REFTIMES_PER_MILLISEC = 10;
        private volatile bool stop;
        private byte[] recordBuffer;
        private Thread captureThread;
        private AudioClient audioClient;
        private int bytesPerFrame;

        /// <summary>
        /// Indicates recorded data is available 
        /// </summary>
        public event EventHandler<WaveInEventArgs> DataAvailable;

        /// <summary>
        /// Indicates that all recorded data has now been received.
        /// </summary>
        public event EventHandler<StoppedEventArgs> RecordingStopped;

        /// <summary>
        /// Initialises a new instance of the WASAPI capture class
        /// </summary>
        public WasapiLoopbackCapture() :
            this(GetDefaultCaptureDevice())
        {
        }


        /// <summary>
        /// Initialises a new instance of the WASAPI capture class
        /// </summary>
        /// <param name="captureDevice">Capture device to use</param>
        public WasapiLoopbackCapture(MMDevice captureDevice)
        {
            this.audioClient = captureDevice.AudioClient;
        }

        /// <summary>
        /// Recording wave format
        /// </summary>
        public WaveFormat WaveFormat
        {
            get
            {
                return audioClient.MixFormat;
            }
            set
            {
                throw new Exception("Setting of Wave Format not supported for loopback device !");
            }
        }

        /// <summary>
        /// Gets the default audio capture device
        /// </summary>
        /// <returns>The default audio capture device</returns>
        public static MMDevice GetDefaultCaptureDevice()
        {
            MMDeviceEnumerator devices = new MMDeviceEnumerator();
            return devices.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
        }

        private void InitializeCaptureDevice()
        {
            long requestedDuration = REFTIMES_PER_MILLISEC * 100;

            audioClient.Initialize(AudioClientShareMode.Shared,
                AudioClientStreamFlags.Loopback,
                requestedDuration,
                0,
                WaveFormat,
                Guid.Empty);

            int bufferFrameCount = audioClient.BufferSize;
            bytesPerFrame = WaveFormat.BlockAlign;
            recordBuffer = new byte[bufferFrameCount * bytesPerFrame];
            Debug.WriteLine(string.Format("record buffer size = {0}", recordBuffer.Length));
        }

        /// <summary>
        /// Start Recording
        /// </summary>
        public void StartRecording()
        {
            InitializeCaptureDevice();
            ThreadStart start = delegate { this.CaptureThread(this.audioClient); };
            this.captureThread = new Thread(start);
            this.captureThread.IsBackground = true;
            this.captureThread.Name = "WASAPI Loopback Thread";

            Debug.WriteLine("Thread starting...");
            this.stop = false;
            this.captureThread.Start();
        }

        /// <summary>
        /// Stop Recording
        /// </summary>
        public void StopRecording()
        {
            if (this.captureThread != null)
            {
                this.stop = true;

                Debug.WriteLine("Thread ending...");

                // wait for thread to end
                this.captureThread.Abort();
                this.captureThread = null;

                Debug.WriteLine("Done.");

                this.stop = false;
            }
        }

        private void CaptureThread(AudioClient client)
        {
            Debug.WriteLine(client.BufferSize);
            int bufferFrameCount = audioClient.BufferSize;

            // Calculate the actual duration of the allocated buffer.
            long actualDuration = (long)((double)REFTIMES_PER_SEC *
                             bufferFrameCount / WaveFormat.SampleRate);
            int sleepMilliseconds = (int)(actualDuration / REFTIMES_PER_MILLISEC / 2);

            AudioCaptureClient capture = client.AudioCaptureClient;
            client.Start();

            try
            {
                Debug.WriteLine(string.Format("sleep: {0} ms", sleepMilliseconds));
                while (!this.stop && VoluMIDI.Program.running)
                {
                    Thread.Sleep(sleepMilliseconds);
                    ReadNextPacket(capture);
                }

                client.Stop();

                if (RecordingStopped != null)
                {
                    RecordingStopped(this, new StoppedEventArgs());
                }
            }
            finally
            {
                if (capture != null)
                {
                    capture.Dispose();
                }
                if (client != null)
                {
                    client.Dispose();
                }

                client = null;
                capture = null;
            }

            System.Diagnostics.Debug.WriteLine("stop wasapi");
        }

        private void ReadNextPacket(AudioCaptureClient capture)
        {
            try
            {
                IntPtr buffer;
                int framesAvailable;
                AudioClientBufferFlags flags;
                int packetSize = capture.GetNextPacketSize();
                int recordBufferOffset = 0;
                //Debug.WriteLine(string.Format("packet size: {0} samples", packetSize / 4));

                while (packetSize != 0)
                {
                    buffer = capture.GetBuffer(out framesAvailable, out flags);

                    int bytesAvailable = framesAvailable * bytesPerFrame;

                    //Debug.WriteLine(string.Format("got buffer: {0} frames", framesAvailable));

                    // if not silence...
                    if ((flags & AudioClientBufferFlags.Silent) != AudioClientBufferFlags.Silent)
                    {
                        Marshal.Copy(buffer, recordBuffer, recordBufferOffset, bytesAvailable);
                    }
                    else
                    {
                        Array.Clear(recordBuffer, recordBufferOffset, bytesAvailable);
                    }
                    recordBufferOffset += bytesAvailable;
                    capture.ReleaseBuffer(framesAvailable);
                    packetSize = capture.GetNextPacketSize();
                }
                if (DataAvailable != null)
                {
                    DataAvailable(this, new WaveInEventArgs(recordBuffer, recordBufferOffset));
                }
            }catch
            {

            }
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            StopRecording();
        }
    }
}
