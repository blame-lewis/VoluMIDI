using System;
using System.Collections.Generic;

using System.Text;

namespace HorribleAudio.SoundDrivers
{
    delegate void BufferRefillEvent(float[] theBuffer);
    abstract class SoundPort
    {

        public abstract string shortName
        {
            get;
        }
        public abstract bool input
        {
            get;
        }
        public abstract string driverType
        {
            get;
        }
        public abstract bool isLoopback
        {
            get;
        }
        public abstract string driverName
        {
            get;
        }
        public int sampleRate = 0;
        public bool enabled = true;
        public abstract void madeInUse();
        public abstract void madeNotInUse();

        public abstract bool dataAvailable
        {
            get;
        }
        bool _inUse = false;
        public bool inUse
        {
            get
            {
                return _inUse;
            }
            set
            {
                if (value != _inUse)
                    if (value == true)
                        madeInUse();
                    else
                        madeNotInUse();
                _inUse = value;

            }
        }
        public abstract void purge();
        public event BufferRefillEvent theRefillEvent;

        public bool refillEventNull
        {
            get
            {
                return theRefillEvent == null;
            }
        }
        public void clearRefillEvent()
        {
            theRefillEvent = null;
        }
        public void doRefillEvent(float[] theBuffer)
        {
            if (theRefillEvent != null)
            {

                theRefillEvent(theBuffer);
            }
        }

    }
}
