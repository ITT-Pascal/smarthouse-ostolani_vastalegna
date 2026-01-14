using BlaisePascal.SmartHouse.Domain.Abstraction;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.LuminousDeviceTests
{
    public class LampTest
    {
        [Fact]
        public void Lamp_TurnOn_SetsIsOnToTrue()
        {
            Lamp lamp = new Lamp("lamp");
            lamp.SwitchOn();
            Assert.Equal(DeviceStatus.On, lamp.Status);
        }
        [Fact]
        public void Lamp_TurnOff_SetsIsOnToFalse()
        {
            Lamp lamp = new Lamp("lamp");
            lamp.SwitchOn();
            lamp.SwitchOff();
            Assert.Equal(DeviceStatus.Off, lamp.Status);
        }
        [Fact]
        public void Lamp_SetBrightness_ValidLevel_SetsBrightnessLevel()
        {
            Lamp lamp = new Lamp("lamp");
            lamp.SetBrightness(50);
            Assert.Equal(50, lamp.Brightness);
        }
        [Fact]
        public void Lamp_SetBrightness_NegativeLevel_ThrowsArgumentOutOfRangeException()
        {
            Lamp lamp = new Lamp("lamp");
            Assert.Throws<ArgumentOutOfRangeException>(() =>lamp.SetBrightness(-5));
        }

        [Fact]
        public void Lamp_SetBrightness_AboveMaxLevel_ThrowsArgumentOutOfRangeException()
        {
            Lamp lamp = new Lamp("lamp");

            Assert.Throws<ArgumentOutOfRangeException>(() => lamp.SetBrightness(AbstractLamp.MaxBrightnessLevel+1));
        }
    }
}