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
        public int FanSpeed { get; private set; }

        public AirConditioner(string name, int temperature): base (name)
        {
            CurrentTemperature = temperature;
            TemperatureToReach = DefaultTemperature;
        }
        public AirConditioner(Guid guid, string name, int temperature): base (guid, name)
        {
            CurrentTemperature = temperature;
            TemperatureToReach = DefaultTemperature;
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
        public void SetFanSpeed(int speed)
        {
            if (speed < 1 || speed > 5)
                throw new ArgumentOutOfRangeException("La velocità della ventola deve essere compresa tra 1 e 5");
            FanSpeed = speed;
        }

    }
}
