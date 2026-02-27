using BlaisePascal.SmartHouse.Domain.TemperatureDevice;
using BlaisePascal.SmartHouse.Domain.TemperatureDevice.AirConditionerDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.ACTest
{
    public class AirConditionerTest
    {

        //  Set temperature

        [Fact]
        public void When_ACIsOffAndSetTemperature_ShouldThrow()
        {
            AirConditioner ac = new AirConditioner("AC");
            Assert.Throws<InvalidOperationException>(() => ac.SetTemperatureToReach(Temperature.MaxTemperature - 1));
        }

        [Fact]
        public void When_SettingTemperatureInRange_ShouldSetTemperature()
        {
            AirConditioner ac = new AirConditioner("AC");
            ac.SwitchOn();
            ac.SetTemperatureToReach(Temperature.MaxTemperature-1);

            Assert.Equal(ac.MaxTemperature - 1, ac.TemperatureToReach);
        }

        [Fact]
        
        public void When_SettingTemperatureOutsideRange_ShouldThrow()
        {
            AirConditioner ac = new AirConditioner("AC");
            ac.SwitchOn();

            Assert.Throws<ArgumentOutOfRangeException>(() => ac.SetTemperatureToReach(Temperature.MaxTemperature +1));
        }


        // Increase temperature

        [Fact]
        public void When_ACIsOffAndIncreaseTemperature_ShouldThrow()
        {
            AirConditioner ac = new AirConditioner("AC");
            Assert.Throws<InvalidOperationException>(() => ac.IncreaseTemperatureToReach());
        }

        [Fact]
        public void When_ACIsOnAndIncreaseTemperature_ShouldIncrease()
        {
            AirConditioner ac = new AirConditioner("AC");
            ac.SwitchOn();

            Temperature tmp = ac.TemperatureToReach;
            ac.IncreaseTemperatureToReach();

            Assert.Equal(tmp + 1, ac.TemperatureToReach);
        }

        [Fact]
        public void When_IncreasingTemperatureBeyondMax_ShouldBeMax()
        {
            AirConditioner ac = new AirConditioner("AC");
            ac.SwitchOn();
            ac.SetTemperatureToReach(Temperature.MaxTemperature);
            Assert.Throws<ArgumentOutOfRangeException>(() => ac.IncreaseTemperatureToReach());
        }

        // Decrease temperature

        [Fact]
        public void When_ACIsOffAndDecreaseTemperature_ShouldThrow()
        {
            AirConditioner ac = new AirConditioner("AC");
            Assert.Throws<InvalidOperationException>(() => ac.DecreaseTemperatureToReach());
        }

        [Fact]
        public void When_ACIsOnAndDecreaseTemperature_ShouldDecrease()
        {
            AirConditioner ac = new AirConditioner("AC");
            ac.SwitchOn();

            Temperature tmp = ac.TemperatureToReach;
            ac.DecreaseTemperatureToReach();

            Assert.Equal(tmp - 1, ac.TemperatureToReach);
        }

        [Fact]
        public void When_DecreasingTemperatureBeyondMin_ShouldThrow()
        {
            AirConditioner ac = new AirConditioner("AC");
            ac.SwitchOn();
            ac.SetTemperatureToReach(Temperature.MinTemperature);
            Assert.Throws<ArgumentOutOfRangeException>(() => ac.DecreaseTemperatureToReach());
        }

        // Fan speed 

        [Fact]
        public void When_TheAirConditionerIsOffAndWantToChangeFanSpeed_CannotDoIt()
        {
            AirConditioner ac = new AirConditioner("AC");
            Assert.Throws<InvalidOperationException>(() => ac.SetFanSpeed(FanSpeed.Low));
        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToChangeFanSpeed_CanDoIt()
        {
            AirConditioner ac = new AirConditioner("AC");
            ac.SwitchOn();
            ac.SetFanSpeed(FanSpeed.Low);

            Assert.Equal(FanSpeed.Low, ac.FanSpeed);
        }


        // AC Mode

        [Fact]
        public void When_ACIsOffAndWantToChangeMode_ShouldThrow()
        {
            AirConditioner ac = new AirConditioner("AC");

            Assert.Throws<InvalidOperationException>(() => ac.SetMode(ACMode.Cold));
        }

        [Fact]
        public void When_ACIsOnAndWantToChangeMode_CanDoIt()
        {
            AirConditioner ac = new AirConditioner("AC");
            ac.SwitchOn();
            ac.SetMode(ACMode.Hot);

            Assert.Equal(ACMode.Hot, ac.Mode);
        }

    }
}
