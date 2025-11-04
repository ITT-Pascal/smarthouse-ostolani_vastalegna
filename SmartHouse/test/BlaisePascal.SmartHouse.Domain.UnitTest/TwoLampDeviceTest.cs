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
            TwoLampDevice device = new TwoLampDevice();
            device.TurnOnOneLamp(device.lamp1);
            Assert.True(device.lamp1.IsOn);
            Assert.False(device.lamp2.IsOn);
        }
        [Fact]
        public void TwoLampDevice_TurnOffOneLamp_SetsIsOnToFalse()
        {
            TwoLampDevice device = new TwoLampDevice();
            device.TurnBothOn();
            device.TurnOffOneLamp(device.lamp1);
            Assert.False(device.lamp1.IsOn);
            Assert.True(device.lamp2.IsOn);
        }

        [Fact]
        public void TwoLampDevice_TurnOnBothLamps_SetsIsOnToTrue()
        {
            TwoLampDevice device = new TwoLampDevice();
            device.TurnBothOn();
            Assert.True(device.lamp1.IsOn);
            Assert.True(device.lamp2.IsOn);
        }
        [Fact]
        public void TwoLampDevice_TurnOffBothLamps_SetsIsOnToFalse()
        {
            TwoLampDevice device = new TwoLampDevice();
            device.TurnBothOn();
            device.TurnBothOff();
            Assert.False(device.lamp1.IsOn);
            Assert.False(device.lamp2.IsOn);
        }
        [Fact]
        public void TwoLampDevice_SetBothSameBrightness_SetsBrightnessLevel()
        {
            TwoLampDevice device = new TwoLampDevice();
            device.SetBothSameBrightness(70);
            Assert.Equal(70, device.lamp1.BrightnessLevel);
            Assert.Equal(70, device.lamp2.BrightnessLevel);
        }
        [Fact]
        public void TwoLampDevice_SetOneBrightness_SetsBrightnessLevel()
        {
            TwoLampDevice device = new TwoLampDevice();
            device.SetOneBrightness(device.lamp1, 30);
            Assert.Equal(30, device.lamp1.BrightnessLevel);
        }
        
        
    }
}
