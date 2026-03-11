using BlaisePascal.SmartHouse.Domain.Abstraction;
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
        public EcoLamp(Guid guid, DeviceName name): base(guid, name) { }
        public EcoLamp(DeviceName name): base(name) { }
        public EcoLamp(Guid guid, DeviceName name, DeviceStatus deviceStatus, Brightness brightness, DateTime creationTime, DateTime lastUpdateTime) : base(guid, name, deviceStatus, brightness, creationTime, lastUpdateTime) { }
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
            if (DateTime.Now - LastModifiedAtUtc > TimeSpan.FromMinutes(DefaultAutoOffMinutes))
            {
                SwitchOff();
            }

        }

        //ONLY FOR TESTING PURPOSES
        public void SetOnTime(DateTime time)
        {
            LastModifiedAtUtc = time;
        }
    }
}
