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
            EcoLamp lamp = new EcoLamp();
            lamp.TurnOn();
            Assert.True(lamp.IsOn);
        }
        [Fact]
        public void EcoLamp_TurnOff_SetsIsOnToFalse()
        {
            EcoLamp lamp = new EcoLamp();
            lamp.TurnOn();
            lamp.TurnOff();
            Assert.False(lamp.IsOn);
        }
        [Fact]
        public void EcoLamp_SetBrightness_ValidLevel_SetsBrightnessLevel()
        {
            EcoLamp lamp = new EcoLamp();
            lamp.SetBrightness(50);
            Assert.Equal(50, lamp.BrightnessLevel);
        }
        [Fact]
        public void EcoLamp_SetBrightness_NegativeLevel_ThrowsArgumentOutOfRangeException()
        {
            EcoLamp lamp = new EcoLamp();
            Assert.Throws<ArgumentOutOfRangeException>(() => lamp.SetBrightness(-5));
        }

        [Fact]
        public void EcoLamp_SetBrightness_AboveMaxLevel_ThrowsArgumentOutOfRangeException()
        {
            EcoLamp lamp = new EcoLamp();
            Assert.Throws<ArgumentOutOfRangeException>(() => lamp.SetBrightness(100 + 1));
        }
        [Fact]
        public void EcoLamp_EcoModeBrightness_SetsBrightnessToEcoLevel()
        {
            EcoLamp lamp = new EcoLamp();
            lamp.TurnOn();
            lamp.SetBrightness(80);
            lamp.SetEcoModeBrightness();
            Assert.Equal(40, lamp.BrightnessLevel);
        }
        [Fact]
        public void EcoLamp_EcoModeBrightness_DoesNotChangeBrightnessIfBelowEcoLevel()
        {
            EcoLamp lamp = new EcoLamp();
            lamp.TurnOn();
            lamp.SetBrightness(30);
            lamp.SetEcoModeBrightness();
            Assert.Equal(30, lamp.BrightnessLevel);
        }

        [Fact]
        public void EcoLamp_TurnOffAfterTime_TurnsOffLampAfter50Minutes()
        {
            EcoLamp lamp = new EcoLamp();

            lamp.TurnOn();
            lamp.SetOnTime(DateTime.UtcNow.AddMinutes(-51));
            lamp.TurnOffAfterTime();
            Assert.False(lamp.IsOn);
        }

    }
}
