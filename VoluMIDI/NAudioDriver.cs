using System;
using System.Collections.Generic;

using System.Text;
using NAudio.Wave;
using NAudio.CoreAudioApi;

namespace HorribleAudio.SoundDrivers.NAudioInterface
{
    enum NAudioDriverType
    {
        WASAPI,
        DirectSound


    }
    class NAudioDriver : SoundDriver
    {
        List<NAudioDevice> theDevices = new List<NAudioDevice>();


        NAudioDriverType theType;
        public NAudioDriver(NAudioDriverType theType)
        {
            this.theType = theType;
            bufferLength = 32;
        }

        public override string driverName
        {
            get
            {
                return "NAudio";
            }
        }
        public override string ToString()
        {
            if (theType == NAudioDriverType.WASAPI)
                return "WASAPI:" + driverName;
            if (theType == NAudioDriverType.DirectSound)
                return "DirectSound:" + driverName;
            return "NAudio: " + driverName;
        }

        public override void configure()
        {

        }
        public override bool canConfigure
        {
            get
            {
                return false;
            }
        }
        public override void startUp()
        {

            started = true;
            lock (theDevices)
            {
                if (this.theType == NAudioDriverType.WASAPI)
                {
                    MMDeviceEnumerator theEnumerator = new MMDeviceEnumerator();
                    theDevices.Clear();
                    foreach (MMDevice dev in theEnumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.All))
                    {
                        try
                        {
                            if (dev.State == DeviceState.Active && dev.State == DeviceState.Active)
                            {
                                NAudioDevice d = new NAudioDevice(dev, theType, true);
                                theDevices.Add(d);
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                if (this.theType == NAudioDriverType.DirectSound)
                {
                    theDevices.Clear();
                    foreach (DirectSoundDeviceInfo d in DirectSoundOut.Devices)
                    {
                        try
                        {
                            theDevices.Add(new NAudioDevice(d, theType, false));
                        }
                        catch
                        {
                        }
                    }

                }
            }

        }
        public override SoundPort[] getPorts()
        {
            List<SoundPort> output = new List<SoundPort>();

            lock (theDevices)
                foreach (NAudioDevice d in theDevices)
                    output.AddRange(d.getPorts());
            return output.ToArray();
        }
        public override void packUp()
        {
            foreach (NAudioDevice d in theDevices)
                d.packUp();
        }
    }
}
