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
        public int CurrentTemperature { get; private set; }
        public int TemperatureToReach { get; private set; }
        public FanSpeed FanSpeed { get; private set; }
        public ACMode Mode { get; private set; }

        //Constructor
        public AirConditioner(string name) : base(name)
        {
            CurrentTemperature = DefaultTemperature;
            TemperatureToReach = DefaultTemperature;
            FanSpeed = FanSpeed.Medium;
        }
        public AirConditioner(string name, int temperature): base (name)
        {
            CurrentTemperature = temperature;
            TemperatureToReach = DefaultTemperature;
            FanSpeed = FanSpeed.Medium;
        }
        public AirConditioner(Guid guid, string name, int temperature): base (guid, name)
        {
            CurrentTemperature = temperature;
            TemperatureToReach = DefaultTemperature;
            FanSpeed = FanSpeed.Medium;
        }
        
        public override void SwitchOn()
        {
            base.SwitchOn();
            CurrentTemperature = TemperatureToReach;
        }


        public void SetTemperatureToReach(int temperature)
        {
            if (temperature < MinTemperature || temperature > MaxTemperature)
                throw new ArgumentOutOfRangeException($"La temperatura deve essere compresa tra {MinTemperature} e {MaxTemperature} gradi Celsius.");
            TemperatureToReach = temperature;
        }

        public void IncreaseTemperatureToReach()
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("Il condizionatore è spento.");
            CurrentTemperature = Math.Max(MinTemperature, CurrentTemperature + TemperatureStep);
        }
        public void DecreaseTemperatureToReach()
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("Il condizionatore è spento.");
            CurrentTemperature = Math.Max(MinTemperature, CurrentTemperature - TemperatureStep);
        }
        public void SetFanSpeed(FanSpeed speed) 
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("Cannot change fan speed when AC is off.");

            FanSpeed = speed;
        }
        public void SetMode(ACMode mode)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("Cannot change fan speed when AC is off.");

            Mode = mode;
        }
    }
}
