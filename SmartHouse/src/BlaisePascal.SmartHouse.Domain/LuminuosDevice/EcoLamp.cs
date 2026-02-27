using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.LuminuosDevice
{
    public class EcoLamp: AbstractLamp
    {
        //Constant
        public const int DefaultAutoOffMinutes = 50;
        public Brightness EcoModeBrightnessValue = Brightness.Create(40);

        //Constructor
        public EcoLamp(Guid guid, string name): base(guid, name) { }
        public EcoLamp(string name): base(name) { }
        
        //Methods
        public void SetEcoModeBrightness()
        {
            OnValidator();
            if (Brightness>EcoModeBrightnessValue) {
                Brightness = EcoModeBrightnessValue;
            }
        }

        public void TurnOffAfterTime()
        {
            OnValidator();
            if (DateTime.Now - LastStatusChangeTime > TimeSpan.FromMinutes(DefaultAutoOffMinutes))
            {
                SwitchOff();
            }

        }

        //ONLY FOR TESTING PURPOSES
        public void SetOnTime(DateTime time)
        {
            LastStatusChangeTime = time;
        }
    }
}
