using BlaisePascal.SmartHouse.Domain.ACDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class AirConditionerTest
    {


        [Fact]
        public void When_TheAirConditionerIsOffAndWantToChangeFanSpeed_CannotDoIt()
        {
            AirConditioner ac = new AirConditioner("AC", 24);
            Assert.Throws<InvalidOperationException>(() => ac.SetFanSpeed(FanSpeed.Low));

        }

        [Fact]
        public void When_TheAirConditionerIsOnAndWantToChangeFanSpeed_CanDoIt()
        {
            AirConditioner ac = new AirConditioner("AC", 24);
            ac.SwitchOn();
            ac.SetFanSpeed(FanSpeed.Low);

            Assert.Equal(FanSpeed.Low, ac.FanSpeed);
        }

    }
}
