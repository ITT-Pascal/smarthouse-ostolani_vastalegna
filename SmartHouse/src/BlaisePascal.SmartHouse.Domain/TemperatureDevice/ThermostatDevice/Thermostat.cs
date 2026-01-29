using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.TemperatureDevice.ThermostatDevice
{
    public class Thermostat: AbstractDevice, ITemperatureDevice
    {
        //Constant
        public Temperature DefaultTemperature = Temperature.Create(24);
        public Temperature MinTemperature = Temperature.Create(15);
        public Temperature MaxTemperature = Temperature.Create(35);
        private const int TemperatureStep = 1;

        //Properties
        public Temperature TemperatureToReach { get; private set; }
        

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
            TemperatureToReach = Temperature.Create(temperature);
        }

        public void IncreaseTemperatureToReach()
        {
            OnValidator();
            if(TemperatureToReach + TemperatureStep  > MaxTemperature)
                TemperatureToReach = MaxTemperature;
            else
                TemperatureToReach = TemperatureToReach + TemperatureStep;
        }
        public void DecreaseTemperatureToReach()
        {
            OnValidator();
            if (TemperatureToReach - TemperatureStep < MinTemperature)
                TemperatureToReach = MinTemperature;
            else
                TemperatureToReach = TemperatureToReach - TemperatureStep;
        }



        //Get const
        public Temperature GetMaxTemperature() => MaxTemperature;
        public Temperature GetMinTemperature() => MinTemperature;


    }
}

