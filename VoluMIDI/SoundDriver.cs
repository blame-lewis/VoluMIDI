using System;
using System.Collections.Generic;

using System.Text;

namespace HorribleAudio.SoundDrivers
{
    abstract class SoundDriver
    {
        public abstract string driverName
        {
            get;
        }
        public int priority = 0;
        public bool enabled = false;
        public bool started = false;
        public abstract void configure();
        public abstract bool canConfigure
        {
            get;
        }
        public abstract void startUp();
        public abstract SoundPort[] getPorts();
        public abstract void packUp();
        public int bufferLength = 1024;
    }
}
