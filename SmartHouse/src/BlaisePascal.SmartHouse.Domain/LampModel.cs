using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public abstract class LampModel
    {
        public bool IsOn {  get; protected set; }
        public int BrightnessLevel { get; protected set; }
        public abstract void TurnOff();
        public abstract void TurnOn();

        public abstract void SetBrightness(int newBrightness);


    }
}
