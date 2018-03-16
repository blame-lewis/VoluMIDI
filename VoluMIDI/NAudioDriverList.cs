using System;
using System.Collections.Generic;

using System.Text;

namespace HorribleAudio.SoundDrivers.NAudioInterface
{
    class NAudioDriverList
    {
        NAudioDriver wasapiDriver;


        public NAudioDriverList()
        {
            wasapiDriver = new NAudioDriver(NAudioDriverType.WASAPI);
            //directSoundDriver = new NAudioDriver(NAudioDriverType.DirectSound);
            wasapiDriver.enabled = true;
            wasapiDriver.startUp();
        }
        public NAudioDriver[] getDrivers()
        {
            List<NAudioDriver> output = new List<NAudioDriver>();
            if (wasapiDriver != null)
                output.Add(wasapiDriver);
            return output.ToArray() ;
        }

    }
}
