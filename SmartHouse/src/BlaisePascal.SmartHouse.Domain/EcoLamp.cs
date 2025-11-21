using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public class EcoLamp: AbstractLamp
    {
        //Constant
        public const int DefaultAutoOffMinutes = 50;
        public const int EcoModeBrightnessValue = 40;

        
        //TODO: Resolve the OnTime test issue
        //ONLY FOR TESTING PURPOSES
        public void SetOnTime(DateTime time)
        {
            LastStatusChangeTime = time;
        }

        //Constructor
        public EcoLamp(Guid guid, string name): base(guid, name) { }
        public EcoLamp(string name): base(name) { }
        

        //Methods
        public void SetEcoModeBrightness()
        {
            if (Status == DeviceStatus.On && BrightnessLevel>EcoModeBrightnessValue) {
                BrightnessLevel = EcoModeBrightnessValue;
            }
        }

        public void TurnOffAfterTime()
        {
            if (Status == DeviceStatus.On)
            {
                if (DateTime.Now - LastStatusChangeTime > TimeSpan.FromMinutes(DefaultAutoOffMinutes))
                {
                    SwitchOff();
                }
            }
                
        }
    }
}
