using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class TwoLampDeviceTest
    {
        [Fact]
        public void TwoLampDevice_TurnOnOneLamp_SetsIsOnToTrue()
        {
            TwoLampDevice device = new TwoLampDevice(new Lamp(), new EcoLamp());
            device.TurnOnOneLamp(device.Lamp1);
            Assert.True(device.Lamp1.IsOn);
            Assert.False(device.Lamp2.IsOn);
        }
        [Fact]
        public void TwoLampDevice_TurnOffOneLamp_SetsIsOnToFalse()
        {
            TwoLampDevice device = new TwoLampDevice(new Lamp(), new EcoLamp());
            device.TurnBothOn();
            device.TurnOffOneLamp(device.Lamp1);
            Assert.False(device.Lamp1.IsOn);
            Assert.True(device.Lamp2.IsOn);
        }

        [Fact]
        public void TwoLampDevice_TurnOnBothLamps_SetsIsOnToTrue()
        {
            TwoLampDevice device = new TwoLampDevice(new Lamp(), new EcoLamp());
            device.TurnBothOn();
            Assert.True(device.Lamp1.IsOn);
            Assert.True(device.Lamp2.IsOn);
        }
        [Fact]
        public void TwoLampDevice_TurnOffBothLamps_SetsIsOnToFalse()
        {
            TwoLampDevice device = new TwoLampDevice(new Lamp(), new EcoLamp());
            device.TurnBothOn();
            device.TurnBothOff();
            Assert.False(device.Lamp1.IsOn);
            Assert.False(device.Lamp2.IsOn);
        }
        [Fact]
        public void TwoLampDevice_SetBothSameBrightness_SetsBrightnessLevel()
        {
            TwoLampDevice device = new TwoLampDevice(new Lamp(), new EcoLamp());
            device.SetBothSameBrightness(70);
            Assert.Equal(70, device.Lamp1.BrightnessLevel);
            Assert.Equal(70, device.Lamp2.BrightnessLevel);
        }
        [Fact]
        public void TwoLampDevice_SetOneBrightness_SetsBrightnessLevel()
        {
            TwoLampDevice device = new TwoLampDevice(new Lamp(), new EcoLamp());
            device.SetOneBrightness(device.Lamp1, 30);
            Assert.Equal(30, device.Lamp1.BrightnessLevel);
        }
        [Fact]
        public void TwoLampDevice_SetOneEcoLampBrightnessToEco_SetsBrightnessToEcoLevel()
        {
            TwoLampDevice device = new TwoLampDevice(new Lamp(), new EcoLamp());
            device.Lamp2.TurnOn();
            device.Lamp2.SetBrightness(80);
            device.SetOneEcoLampBrightnessToEco(device.Lamp2);
            Assert.Equal(40, device.Lamp2.BrightnessLevel);
        }
        [Fact]
        public void TwoLampDevice_SetBothEcoLampBrightnessToEco_SetsBrightnessToEcoLevel()
        {
            TwoLampDevice device = new TwoLampDevice(new EcoLamp(), new EcoLamp());
            device.Lamp1.TurnOn();
            device.Lamp2.TurnOn();
            device.Lamp1.SetBrightness(90);
            device.Lamp2.SetBrightness(70);
            device.SetBothEcoLampsBrightnessToEco();
            Assert.Equal(40, device.Lamp1.BrightnessLevel);
            Assert.Equal(40, device.Lamp2.BrightnessLevel);
        }
        [Fact]
        public void TwoLampDevice_TurnOneEcoLampOffAfterTime_SetsIsOnToFalse()
        {
            TwoLampDevice device = new TwoLampDevice(new Lamp(), new EcoLamp());
            device.Lamp2.TurnOn();
            //Si fa così per usare i metodi di EcoLamp?
            (device.Lamp2 as EcoLamp)?.SetOnTime(DateTime.UtcNow.AddMinutes(-51));
            (device.Lamp2 as EcoLamp)?.TurnOffAfterTime();
            Assert.False(device.Lamp2.IsOn);

        }

    }
}
