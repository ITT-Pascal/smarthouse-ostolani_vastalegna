using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class EcoLampTest
    {
        [Fact]
        public void EcoLamp_TurnOn_SetsIsOnToTrue()
        {
            Lamp lamp = new Lamp();
            lamp.TurnOn();
            Assert.True(lamp.IsOn);
        }
        [Fact]
        public void EcoLamp_TurnOff_SetsIsOnToFalse()
        {
            Lamp lamp = new Lamp();
            lamp.TurnOn();
            lamp.TurnOff();
            Assert.False(lamp.IsOn);
        }
        [Fact]
        public void EcoLamp_SetBrightness_ValidLevel_SetsBrightnessLevel()
        {
            Lamp lamp = new Lamp();
            lamp.SetBrightness(50);
            Assert.Equal(50, lamp.BrightnessLevel);
        }
        [Fact]
        public void EcoLamp_SetBrightness_NegativeLevel_ThrowsArgumentOutOfRangeException()
        {
            Lamp lamp = new Lamp();
            Assert.Throws<ArgumentOutOfRangeException>(() => lamp.SetBrightness(-5));
        }

        [Fact]
        public void EcoLamp_SetBrightness_AboveMaxLevel_ThrowsArgumentOutOfRangeException()
        {
            Lamp lamp = new Lamp();
            Assert.Throws<ArgumentOutOfRangeException>(() => lamp.SetBrightness(100 + 1));
        }


    }
}
