using BlaisePascal.SmartHouse.Domain.LuminuosDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class LampRowTest
    {
        [Fact]
        public void LampRow_TurnAllOn_SetsAllIsOnToTrue()
        {
            LampRow row = new LampRow("LampsRow");
            Lamp lamp1 = new Lamp("lamp1");
            Lamp lamp2 = new Lamp("lamp2");
            row.AddLamp(lamp1);
            row.AddLamp(lamp2);

            row.TurnAllOn();

            Assert.Equal(DeviceStatus.On, lamp1.Status);
            Assert.Equal(DeviceStatus.On, lamp2.Status);
        }

        [Fact]
        public void LampRow_TurnAllOff_SetsAllIsOnToFalse()
        {
            LampRow row = new LampRow("LampsRow");
            Lamp lamp1 = new Lamp("lamp1");
            Lamp lamp2 = new Lamp("lamp2");
            row.AddLamp(lamp1);
            row.AddLamp(lamp2);

            row.TurnAllOn();
            row.TurnAllOff();

            Assert.Equal(DeviceStatus.Off, lamp1.Status);
            Assert.Equal(DeviceStatus.Off, lamp2.Status);
        }

        [Fact]
        public void LampRow_TurnOnOneLamp_SetsOnlyOneToTrue()
        {
            LampRow row = new LampRow("LampsRow");
            Lamp lamp1 = new Lamp("lamp1");
            Lamp lamp2 = new Lamp("lamp2");
            row.AddLamp(lamp1);
            row.AddLamp(lamp2);

            row.TurnOnOneLamp("lamp1");

            Assert.Equal(DeviceStatus.On, lamp1.Status);
            Assert.Equal(DeviceStatus.Off, lamp2.Status);
        }

        [Fact]
        public void LampRow_TurnOffOneLamp_SetsOnlyOneToFalse()
        {
            LampRow row = new LampRow("LampsRow");
            Lamp lamp1 = new Lamp("lamp1");
            Lamp lamp2 = new Lamp("lamp2");
            row.AddLamp(lamp1);
            row.AddLamp(lamp2);

            row.TurnAllOn();
            row.TurnOffOneLamp("lamp2");

            Assert.Equal(DeviceStatus.On, lamp1.Status);
            Assert.Equal(DeviceStatus.Off, lamp2.Status);
        }

        [Fact]
        public void LampRow_SetOneBrightness_SetsCorrectValue()
        {
            LampRow row = new LampRow("LampsRow");
            Lamp lamp1 = new Lamp("lamp1");
            row.AddLamp(lamp1);

            row.SetOneBrightness("lamp1", 55);

            Assert.Equal(55, lamp1.Brightness);
        }

        [Fact]
        public void LampRow_SetAllSameBrightness_SetsAllEqual()
        {
            LampRow row = new LampRow("LampsRow");
            Lamp lamp1 = new Lamp("lamp1");
            Lamp lamp2 = new Lamp("lamp2");
            row.AddLamp(lamp1);
            row.AddLamp(lamp2);

            row.SetAllSameBrightness(70);

            Assert.Equal(70, lamp1.Brightness);
            Assert.Equal(70, lamp2.Brightness);
        }
        [Fact]
        public void LampRow_SetOneEcoLampBrightnessToEco_SetsEcoBrightness()
        {
            LampRow row = new LampRow("LampsRow");
            EcoLamp ecoLamp = new EcoLamp("ecolamp1");
            ecoLamp.SwitchOn();
            ecoLamp.SetBrightness(90);
            row.AddLamp(ecoLamp);

            row.SetOneEcoLampBrightnessToEco("ecolamp1");

            Assert.Equal(40, ecoLamp.Brightness); 
        }

        [Fact]
        public void LampRow_SetAllEcoLampsBrightnessToEco_SetsAllToEcoLevel()
        {
            LampRow row = new LampRow("LampsRow");
            EcoLamp eco1 = new EcoLamp("ecolamp1");
            EcoLamp eco2 = new EcoLamp("ecolamp2");
            eco1.SwitchOn();
            eco2.SwitchOn();
            eco1.SetBrightness(90);
            eco2.SetBrightness(75);
            row.AddLamp(eco1);
            row.AddLamp(eco2);

            row.SetAllEcoLampsBrightnessToEco();

            Assert.Equal(40, eco1.Brightness);
            Assert.Equal(40, eco2.Brightness);
        }

        [Fact]
        public void LampRow_TurnOneEcoLampOffAfterTime_SetsIsOnToFalseIfExpired()
        {
            LampRow row = new LampRow("LampsRow");
            EcoLamp eco = new EcoLamp("ecolamp1");
            eco.SwitchOn();
            eco.SetOnTime(DateTime.UtcNow.AddMinutes(-60)); 
            row.AddLamp(eco);

            row.TurnOneEcoLampOffAfterTime("ecolamp1");

            Assert.Equal(DeviceStatus.Off, eco.Status);
        }

        [Fact]
        public void LampRow_TurnAllEcoLampsOffAfterTime_SetsAllToFalseIfExpired()
        {
            LampRow row = new LampRow("LampsRow");
            EcoLamp eco1 = new EcoLamp("ecolamp1");
            EcoLamp eco2 = new EcoLamp("ecolamp2");
            eco1.SwitchOn();
            eco2.SwitchOn();
            eco1.SetOnTime(DateTime.UtcNow.AddMinutes(-51));
            eco2.SetOnTime(DateTime.UtcNow.AddMinutes(-53));
            row.AddLamp(eco1);
            row.AddLamp(eco2);

            row.TurnAllEcoLampsOffAfterTime();

            Assert.Equal(DeviceStatus.Off, eco1.Status);
            Assert.Equal(DeviceStatus.Off, eco2.Status);
        }
    }
}
