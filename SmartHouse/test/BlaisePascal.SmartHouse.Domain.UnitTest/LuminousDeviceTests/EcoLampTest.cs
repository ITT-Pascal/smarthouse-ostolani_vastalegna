using BlaisePascal.SmartHouse.Domain.LuminuosDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.LuminousDeviceTests
{
    public class EcoLampTest
    {
        [Fact]
        public void EcoLamp_TurnOn_SetsIsOnToTrue()
        {
            EcoLamp lamp = new EcoLamp("lamp");
            lamp.SwitchOn();
            Assert.Equal(DeviceStatus.On, lamp.Status);
        }
        [Fact]
        public void EcoLamp_TurnOff_SetsIsOnToFalse()
        {
            EcoLamp lamp = new EcoLamp("lamp");
            lamp.SwitchOn();
            lamp.SwitchOff();
            Assert.Equal(DeviceStatus.Off, lamp.Status);
        }
        [Fact]
        public void EcoLamp_SetBrightness_ValidLevel_SetsBrightnessLevel()
        {
            EcoLamp lamp = new EcoLamp("lamp");
            lamp.SetBrightness(Brightness.Create(50));
            Assert.Equal(Brightness.Create(50), lamp.Brightness);
        }

        [Fact]
        public void EcoLamp_EcoModeBrightness_SetsBrightnessToEcoLevel()
        {
            EcoLamp lamp = new EcoLamp("lamp");
            lamp.SwitchOn();
            lamp.SetBrightness(Brightness.Create(80));
            lamp.SetEcoModeBrightness();
            Assert.Equal(Brightness.Create(40), lamp.Brightness);
        }
        [Fact]
        public void EcoLamp_EcoModeBrightness_DoesNotChangeBrightnessIfBelowEcoLevel()
        {
            EcoLamp lamp = new EcoLamp("lamp");
            lamp.SwitchOn();
            lamp.SetBrightness(Brightness.Create(30));
            lamp.SetEcoModeBrightness();
            Assert.Equal(Brightness.Create(30), lamp.Brightness);
        }

        [Fact]
        public void EcoLamp_TurnOffAfterTime_TurnsOffLampAfter50Minutes()
        {
            EcoLamp lamp = new EcoLamp("lamp");

            lamp.SwitchOn();
            lamp.SetOnTime(DateTime.UtcNow.AddMinutes(-51));
            lamp.TurnOffAfterTime();
            Assert.Equal(DeviceStatus.Off, lamp.Status);
        }

    }
}
