using BlaisePascal.SmartHouse.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.ACDevice
{
    public class AirConditioner: AbstractDevice, ITemperatureDevice
    {
        //Constant
        public const int DefaultTemperature = 24;
        public const int MinTemperature = 15;
        public const int MaxTemperature = 35;
        private const int TemperatureStep = 1;

        //Properties
        public int TemperatureToReach { get; private set; }
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
            if (temperature < MinTemperature || temperature > MaxTemperature)
                throw new ArgumentOutOfRangeException($"Temperatere must be between {MinTemperature} and {MaxTemperature}");
            TemperatureToReach = temperature;
            LastStatusChangeTime = DateTime.UtcNow;
        }

        public void IncreaseTemperatureToReach()
        {
            OnValidator();
            TemperatureToReach = Math.Min(MaxTemperature, TemperatureToReach + TemperatureStep);
            LastStatusChangeTime = DateTime.UtcNow;
        }
        public void DecreaseTemperatureToReach()
        {
            OnValidator();
            TemperatureToReach = Math.Max(MinTemperature, TemperatureToReach - TemperatureStep);
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
        public int GetMaxTemperature() => MaxTemperature;
        public int GetMinTemperature() => MinTemperature;
        

    }
}
