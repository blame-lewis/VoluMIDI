using System;
using System.Collections.Generic;

using System.Text;
using NAudio.Wave;
using NAudio.CoreAudioApi;

namespace HorribleAudio.SoundDrivers.NAudioInterface
{
    class NAudioDevice
    {
        IWavePlayer mainOutput;
        WaveChannel32 waveChan;
        MMDevice theDevice;
        List<NAudioLoopback> theLoopbacks = new List<NAudioLoopback>();
        public int numChannels = 0;
        NAudioDriverType theType;
        public string friendlyName;
        NAudio.CoreAudioApi.WasapiLoopbackCapture theCapture;

        public NAudioDevice(object theDevice, NAudioDriverType theType, bool captureMode)
        {

            this.theType = theType;
            if (theType == NAudioDriverType.WASAPI)
            {
                friendlyName = ((MMDevice)theDevice).FriendlyName;
                numChannels = ((MMDevice)theDevice).AudioClient.MixFormat.Channels;
                if(!captureMode)
                    mainOutput = new WasapiOut((MMDevice)theDevice, AudioClientShareMode.Shared, false, 0);

                
                this.theDevice = (MMDevice)theDevice;
            }
            else
            {
                MMDevice dev = null;
                MMDeviceEnumerator theEnumerator = new MMDeviceEnumerator();
                foreach (MMDevice d in theEnumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.All))
                    if (d.FriendlyName.Contains(((DirectSoundDeviceInfo)theDevice).Description) || ((DirectSoundDeviceInfo)theDevice).Description.Contains(d.FriendlyName))
                        dev = d;

                friendlyName = ((DirectSoundDeviceInfo)theDevice).Description;
                mainOutput = new DirectSoundOut(((DirectSoundDeviceInfo)theDevice).Guid, 0);
                if (dev != null)
                    numChannels = dev.AudioClient.MixFormat.Channels;
                else
                    numChannels = 2;

                
            }

                if (theType == NAudioDriverType.WASAPI)
                {

                    if (captureMode)
                    {
                        theCapture = new NAudio.CoreAudioApi.WasapiLoopbackCapture((MMDevice)theDevice);


                        lock (theLoopbacks)
                            for (int i = 0; i < numChannels; i++)
                            {
                                try
                                {
                                    NAudioLoopback n = new NAudioLoopback(this, i, theCapture);
                                    theLoopbacks.Add(n);
                                }
                                catch
                                {
                                }
                            }

                    }
                }
            foreach(NAudioLoopback n in theLoopbacks)
                try
                {

                    n.madeInUse();
                }
                catch
                {
                }
            

        }
        public void packUp()
        {
            lock (theLoopbacks)
                foreach (NAudioLoopback l in theLoopbacks)
                    l.packUp();
            try
            {
                mainOutput.Stop();
                mainOutput.Dispose();
            }
            catch (Exception)
            {
            }
            try
            {
                waveChan.Dispose();
            }
            catch (Exception)
            {
            }
            try
            {
                theCapture.StopRecording();
                theCapture.Dispose();
            }
            catch (Exception)
            {
            }
        }
        public SoundPort[] getPorts()
        {
            List<SoundPort> output = new List<SoundPort>();

            lock (theLoopbacks)
                output.AddRange(theLoopbacks.ToArray());

            return output.ToArray();
        }
    }
}
