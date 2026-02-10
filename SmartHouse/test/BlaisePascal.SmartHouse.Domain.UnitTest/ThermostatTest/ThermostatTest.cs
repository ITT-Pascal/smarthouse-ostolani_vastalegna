using BlaisePascal.SmartHouse.Domain.TemperatureDevice;
using BlaisePascal.SmartHouse.Domain.TemperatureDevice.ThermostatDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.ThermostatTest
{
    public class ThermostatTest
    {
        
        // Set temperature

        [Fact]
        public void When_ThermostatIsOffAndSetTemperature_ShouldThrow()
        {
            Thermostat t = new Thermostat("Thermostat");
            Assert.Throws<InvalidOperationException>(() => t.SetTemperatureToReach(Temperature.MaxTemperature - 1));
        }

        [Fact]
        public void When_SettingTemperatureInRange_ShouldSetTemperature()
        {
            Thermostat t = new Thermostat("Thermostat");
            t.SwitchOn();
            t.SetTemperatureToReach(Temperature.MaxTemperature - 1);

            Assert.Equal(t.MaxTemperature - 1, t.TemperatureToReach);
        }

        [Fact]
        public void When_SettingTemperatureOutsideRange_ShouldThrow()
        {
            Thermostat t = new Thermostat("Thermostat");
            t.SwitchOn();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                t.SetTemperatureToReach(Temperature.MaxTemperature + 1));
        }


        // Increase temperature

        [Fact]
        public void When_ThermostatIsOffAndIncreaseTemperature_ShouldThrow()
        {
            Thermostat t = new Thermostat("Thermostat");
            Assert.Throws<InvalidOperationException>(() => t.IncreaseTemperatureToReach());
        }

        [Fact]
        public void When_ThermostatIsOnAndIncreaseTemperature_ShouldIncrease()
        {
            Thermostat t = new Thermostat("Thermostat");
            t.SwitchOn();

            Temperature tmp = t.TemperatureToReach;
            t.IncreaseTemperatureToReach();

            Assert.Equal(tmp + 1, t.TemperatureToReach);
        }

        [Fact]
        public void When_IncreasingTemperatureBeyondMax_ShouldBeMax()
        {
            Thermostat t = new Thermostat("Thermostat");
            t.SwitchOn();
            t.SetTemperatureToReach(Temperature.MaxTemperature);
            Assert.Throws<ArgumentOutOfRangeException>(() => t.IncreaseTemperatureToReach());
        }


        // Decrease temperature

        [Fact]
        public void When_ThermostatIsOffAndDecreaseTemperature_ShouldThrow()
        {
            Thermostat t = new Thermostat("Thermostat");
            Assert.Throws<InvalidOperationException>(() => t.DecreaseTemperatureToReach());
        }

        [Fact]
        public void When_ThermostatIsOnAndDecreaseTemperature_ShouldDecrease()
        {
            Thermostat t = new Thermostat("Thermostat");
            t.SwitchOn();

            Temperature tmp = t.TemperatureToReach;
            t.DecreaseTemperatureToReach();

            Assert.Equal(tmp - 1, t.TemperatureToReach);
        }

        [Fact]
        public void When_DecreasingTemperatureBeyondMin_ShouldThrow()
        {
            Thermostat t = new Thermostat("Thermostat");
            t.SwitchOn();
            t.SetTemperatureToReach(Temperature.MinTemperature);
            Assert.Throws<ArgumentOutOfRangeException>(() => t.DecreaseTemperatureToReach());
        }


    }
}
