using System;
using System.Collections.Generic;

using System.Text;
using NAudio.Wave;

namespace HorribleAudio.SoundDrivers.NAudioInterface
{
    class NAudioLoopback : SoundInput
    {
        int channelNum;
        NAudioDevice theDevice;
        NAudio.CoreAudioApi.WasapiLoopbackCapture theCapture;
        public NAudioLoopback(NAudioDevice theDevice, int channelNum, NAudio.CoreAudioApi.WasapiLoopbackCapture theCapture)
        {
            this.sampleRate = theCapture.WaveFormat.SampleRate;
            this.channelNum = channelNum;
            this.theCapture = theCapture;
            this.theDevice = theDevice;
            theCapture.DataAvailable += dataAvailable;
        }
        public void packUp()
        {
            theCapture.StopRecording();
            theCapture.DataAvailable -= dataAvailable;
        }
        public override string shortName
        {
            get
            {
                if (theDevice.numChannels == 2)
                {
                    if (channelNum == 0)
                        return theDevice.friendlyName + ".LEFT";
                    else
                        return theDevice.friendlyName + ".RIGHT";

                }
                return theDevice.friendlyName + ".CHAN" + channelNum.ToString();

            }
        }
        public override void madeInUse()
        {
            theCapture.StartRecording();
        }
        public override void madeNotInUse()
        {

        }
        string name
        {
            get
            {
                if (theDevice.numChannels == 2)
                {
                    if (channelNum == 0)
                        return "Loopback: " +  theDevice.friendlyName + ".LEFT";
                    else
                        return "Loopback: " + theDevice.friendlyName + ".RIGHT";

                }
                return "Loopback: " + theDevice.friendlyName + ".CHAN" + channelNum.ToString();

            }
        }
        List<float> output = new List<float>();
        public new void dataAvailable(object sender, WaveInEventArgs args)
        {
            lock (output)
            {
                try
                {
                    for (int i = channelNum; i < args.BytesRecorded / 4; i += theDevice.numChannels)
                    {
                        float f = BitConverter.ToSingle(args.Buffer, i * 4);
                        output.Add(f);
                    }
                }
                catch
                {

                }
                //if (output.Count > 2048)
                {
                    try
                    {
                        int i = output.Count;
                        doRefillEvent(output.ToArray());
                        output.Clear();
                    }
                    catch
                    {

                    }
                }
            }
        }
        public override bool isLoopback
        {
            get
            {
                return true;
            }
        }
        public override bool input
        {
            get
            {
                return true;
            }
        }
        public override string ToString()
        {
            return "WASAPI.Loopback." + name;

        }
        public override string driverType
        {
            get
            {
                return "WASAPI.Loopback";
            }
        }
        public override string driverName
        {
            get
            {
                return "NAudio Interface";
            }
        }
    }
}
