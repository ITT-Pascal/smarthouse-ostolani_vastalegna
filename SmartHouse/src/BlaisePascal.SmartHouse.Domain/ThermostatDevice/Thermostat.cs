using BlaisePascal.SmartHouse.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.ThermostatDevice
{
    public class Thermostat: AbstractDevice
    {
        //Constant
        public const int DefaultTemperature = 24;
        public const int MinTemperature = 15;
        public const int MaxTemperature = 35;
        private const int TemperatureStep = 1;

        //Properties
        public int TemperatureToReach { get; private set; }
        

        //Constructor
        public Thermostat(string name) : base(name)
        {
            TemperatureToReach = DefaultTemperature; 
        }

        public Thermostat(Guid guid, string name) : base(guid, name)
        {
            TemperatureToReach = DefaultTemperature;
        }


        public void SetTemperatureToReach(int temperature)
        {
            OnValidator();
            if (temperature < MinTemperature || temperature > MaxTemperature)
                throw new ArgumentOutOfRangeException($"Temperatere must be between {MinTemperature} and {MaxTemperature}");
            TemperatureToReach = temperature;
        }

        public void IncreaseTemperatureToReach()
        {
            OnValidator();
            TemperatureToReach = Math.Min(MaxTemperature, TemperatureToReach + TemperatureStep);
        }
        public void DecreaseTemperatureToReach()
        {
            OnValidator();
            TemperatureToReach = Math.Max(MinTemperature, TemperatureToReach - TemperatureStep);
        }



        //Get const
        public int GetMaxTemperature() => MaxTemperature;
        public int GetMinTemperature() => MinTemperature;


    }
}

