using BlaisePascal.SmartHouse.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.TemperatureDevice.AirConditionerDevice
{
    public class AirConditioner: AbstractDevice, ITemperatureDevice
    {
        //Constant
        public Temperature DefaultTemperature = Temperature.Create(24);
        public Temperature MinTemperature = Temperature.Create(Temperature.MinTemperature);
        public Temperature MaxTemperature = Temperature.Create(Temperature.MaxTemperature);
        private const int TemperatureStep = 1;

        //Properties
        public Temperature TemperatureToReach { get; private set; }
        public FanSpeed FanSpeed { get; private set; }
        public ACMode Mode { get; private set; }

        //Constructor
        public AirConditioner(DeviceName name) : base(name)
        {
            TemperatureToReach = DefaultTemperature;
            FanSpeed = FanSpeed.Medium;
        }

        public AirConditioner(Guid guid, DeviceName name): base (guid, name)
        {
            TemperatureToReach = DefaultTemperature;
            FanSpeed = FanSpeed.Medium;
        }
        

        public void SetTemperatureToReach(int temperature)
        {
            OnValidator();
            TemperatureToReach = Temperature.Create(temperature);
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public void IncreaseTemperatureToReach()
        {
            OnValidator();
            TemperatureToReach = Temperature.Increase(TemperatureToReach, TemperatureStep);
            LastModifiedAtUtc = DateTime.UtcNow;
        }
        public void DecreaseTemperatureToReach()
        {
            OnValidator();
            TemperatureToReach = Temperature.Decrease(TemperatureToReach, TemperatureStep);
            LastModifiedAtUtc = DateTime.UtcNow;
        }
        public void SetFanSpeed(FanSpeed speed) 
        {
            OnValidator();
            FanSpeed = speed;
            LastModifiedAtUtc = DateTime.UtcNow;
        }
        public void SetMode(ACMode mode)
        {
            OnValidator();
            Mode = mode;
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        

    }
}
