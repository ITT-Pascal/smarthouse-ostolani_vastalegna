using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.ACDevice
{
    public class AirConditioner: AbstractDevice
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
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("AC is off");
            if (temperature < MinTemperature || temperature > MaxTemperature)
                throw new ArgumentOutOfRangeException($"Temperatere must be between {MinTemperature} and {MaxTemperature}");
            TemperatureToReach = temperature;
        }

        public void IncreaseTemperatureToReach()
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("AC is off");
            TemperatureToReach = Math.Min(MaxTemperature, TemperatureToReach + TemperatureStep);
        }
        public void DecreaseTemperatureToReach()
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("AC is off");
            TemperatureToReach = Math.Max(MinTemperature, TemperatureToReach - TemperatureStep);
        }
        public void SetFanSpeed(FanSpeed speed) 
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("AC is off");

            FanSpeed = speed;
        }
        public void SetMode(ACMode mode)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("AC is off");

            Mode = mode;
        }

        //Get const
        public int GetMaxTemperature() => MaxTemperature;
        public int GetMinTemperature() => MaxTemperature;
        

    }
}
