using BlaisePascal.SmartHouse.Domain.Abstraction;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.LuminousDeviceTests
{
    public class TwoLampDeviceTest
    {
        [Fact]
        public void TwoLampDevice_TurnOnOneLamp_SetsIsOnToTrue()
        {
            TwoLampDevice device = new TwoLampDevice(new Lamp("lamp"), new EcoLamp("ecolamp"));
            device.TurnOnOneLamp(device.Lamp1);
            Assert.Equal(DeviceStatus.On, device.Lamp1.Status);
            Assert.Equal(DeviceStatus.Off, device.Lamp2.Status);
        }
        [Fact]
        public void TwoLampDevice_TurnOffOneLamp_SetsIsOnToFalse()
        {
            TwoLampDevice device = new TwoLampDevice(new Lamp("lamp"), new EcoLamp("ecolamp"));
            device.TurnBothOn();
            device.TurnOffOneLamp(device.Lamp1);
            Assert.Equal(DeviceStatus.Off, device.Lamp1.Status);
            Assert.Equal(DeviceStatus.On, device.Lamp2.Status);
        }

        [Fact]
        public void TwoLampDevice_TurnOnBothLamps_SetsIsOnToTrue()
        {
            TwoLampDevice device = new TwoLampDevice(new Lamp("lamp"), new EcoLamp("ecolamp"));
            device.TurnBothOn();
            Assert.Equal(DeviceStatus.On, device.Lamp1.Status);
            Assert.Equal(DeviceStatus.On, device.Lamp2.Status);
        }
        [Fact]
        public void TwoLampDevice_TurnOffBothLamps_SetsIsOnToFalse()
        {
            TwoLampDevice device = new TwoLampDevice(new Lamp("lamp"), new EcoLamp("ecolamp"));
            device.TurnBothOn();
            device.TurnBothOff();
            Assert.Equal(DeviceStatus.Off, device.Lamp1.Status);
            Assert.Equal(DeviceStatus.Off, device.Lamp2.Status);
        }
        [Fact]
        public void TwoLampDevice_SetBothSameBrightness_SetsBrightnessLevel()
        {
            TwoLampDevice device = new TwoLampDevice(new Lamp("lamp"), new EcoLamp("ecolamp"));
            device.SetBothSameBrightness(70);
            Assert.Equal(70, device.Lamp1.Brightness);
            Assert.Equal(70, device.Lamp2.Brightness);
        }
        [Fact]
        public void TwoLampDevice_SetOneBrightness_SetsBrightnessLevel()
        {
            TwoLampDevice device = new TwoLampDevice(new Lamp("lamp"), new EcoLamp("ecolamp"));
            device.SetOneBrightness(device.Lamp1, 30);
            Assert.Equal(30, device.Lamp1.Brightness);
        }
        [Fact]
        public void TwoLampDevice_SetOneEcoLampBrightnessToEco_SetsBrightnessToEcoLevel()
        {
            TwoLampDevice device = new TwoLampDevice(new Lamp("lamp"), new EcoLamp("ecolamp"));
            device.Lamp2.SwitchOn();
            device.Lamp2.SetBrightness(80);
            device.SetOneEcoLampBrightnessToEco(device.Lamp2);
            Assert.Equal(40, device.Lamp2.Brightness);
        }
        [Fact]
        public void TwoLampDevice_SetBothEcoLampBrightnessToEco_SetsBrightnessToEcoLevel()
        {
            TwoLampDevice device = new TwoLampDevice(new EcoLamp("ecolamp"), new EcoLamp("ecolamp"));
            device.Lamp1.SwitchOn();
            device.Lamp2.SwitchOn();
            device.Lamp1.SetBrightness(90);
            device.Lamp2.SetBrightness(70);
            device.SetBothEcoLampsBrightnessToEco();
            Assert.Equal(40, device.Lamp1.Brightness);
            Assert.Equal(40, device.Lamp2.Brightness);
        }
        [Fact]
        public void TwoLampDevice_TurnOneEcoLampOffAfterTime_SetsIsOnToFalse()
        {
            TwoLampDevice device = new TwoLampDevice(new Lamp("lamp"), new EcoLamp("ecolamp"));
            device.Lamp2.SwitchOn();
            //Si fa così per usare i metodi di EcoLamp?
            (device.Lamp2 as EcoLamp)?.SetOnTime(DateTime.UtcNow.AddMinutes(-51));
            (device.Lamp2 as EcoLamp)?.TurnOffAfterTime();
            Assert.Equal(DeviceStatus.Off, device.Lamp2.Status);

        }

    }
}
