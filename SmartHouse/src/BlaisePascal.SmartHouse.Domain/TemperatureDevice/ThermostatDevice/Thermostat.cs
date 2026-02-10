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
        public Temperature MinTemperature = Temperature.Create(Temperature.MinTemperature);
        public Temperature MaxTemperature = Temperature.Create(Temperature.MaxTemperature);
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
            TemperatureToReach = Temperature.Create(temperature);
        }

        public void IncreaseTemperatureToReach()
        {
            OnValidator();
            TemperatureToReach = Temperature.Increase(TemperatureToReach, TemperatureStep);

        }
        public void DecreaseTemperatureToReach()
        {
            OnValidator();
            TemperatureToReach = Temperature.Decrease(TemperatureToReach, TemperatureStep);
        }




    }
}

