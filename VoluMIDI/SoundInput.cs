using System;
using System.Collections.Generic;
using System.Text;

namespace HorribleAudio.SoundDrivers
{
    abstract class SoundInput : SoundPort
    {
        List<float> queuedData = new List<float>();
        List<int> queuedTimings = new List<int>();

        int currentTiming = 0;
        public SoundInput()
        {
            theRefillEvent += dataReceived;
        }
        public int dataAmount
        {
            get
            {
                return 0;
            }
        }
        public override void purge()
        {

        }
        static object sendLock = new object();
        void dataReceived(float[] theData)
        {
        }
        public override bool dataAvailable
        {
            get
            {
                return false;
            }
        }
    }
}
