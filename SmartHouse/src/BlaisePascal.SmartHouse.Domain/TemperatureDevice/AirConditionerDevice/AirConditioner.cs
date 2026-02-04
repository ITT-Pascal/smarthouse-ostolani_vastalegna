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
        public Temperature MinTemperature = Temperature.Create(15);
        public Temperature MaxTemperature = Temperature.Create(35);
        private const int TemperatureStep = 1;

        //Properties
        public Temperature TemperatureToReach { get; private set; }
        public FanSpeed FanSpeed { get; private set; }
        public ACMode Mode { get; private set; }

        //Constructor
        public AirConditioner(string name) : base(name)
        {
            TemperatureToReach = DefaultTemperature;
            FanSpeed = FanSpeed.Medium;
        }

        public AirConditioner(Guid guid, string name): base (guid, name)
        {
            TemperatureToReach = DefaultTemperature;
            FanSpeed = FanSpeed.Medium;
        }
        

        public void SetTemperatureToReach(int temperature)
        {
            OnValidator();
            if (MinTemperature > temperature || MinTemperature < temperature)
                throw new ArgumentOutOfRangeException($"Temperatere must be between {MinTemperature} and {MaxTemperature}");
            TemperatureToReach = Temperature.Create(temperature);
            LastStatusChangeTime = DateTime.UtcNow;
        }

        public void IncreaseTemperatureToReach()
        {
            OnValidator();
            TemperatureToReach = Temperature.Increase(TemperatureToReach - TemperatureStep);
            LastStatusChangeTime = DateTime.UtcNow;
        }
        public void DecreaseTemperatureToReach()
        {
            OnValidator();
            TemperatureToReach = Temperature.Decrease(TemperatureToReach - TemperatureStep);
            LastStatusChangeTime = DateTime.UtcNow;
        }
        public void SetFanSpeed(FanSpeed speed) 
        {
            OnValidator();
            FanSpeed = speed;
            LastStatusChangeTime = DateTime.UtcNow;
        }
        public void SetMode(ACMode mode)
        {
            OnValidator();
            Mode = mode;
            LastStatusChangeTime = DateTime.UtcNow;
        }

        //Get const
        public Temperature GetMaxTemperature() => MaxTemperature;
        public Temperature GetMinTemperature() => MinTemperature;
        

    }
}
