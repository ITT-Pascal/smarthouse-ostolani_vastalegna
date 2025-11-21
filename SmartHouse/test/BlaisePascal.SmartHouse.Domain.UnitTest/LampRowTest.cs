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
            LampRow row = new LampRow();
            Lamp lamp1 = new Lamp("lamp");
            Lamp lamp2 = new Lamp("lamp");
            row.AddLamp(lamp1);
            row.AddLamp(lamp2);

            row.TurnAllOn();

            Assert.True(lamp1.IsOn);
            Assert.True(lamp2.IsOn);
        }

        [Fact]
        public void LampRow_TurnAllOff_SetsAllIsOnToFalse()
        {
            LampRow row = new LampRow();
            Lamp lamp1 = new Lamp("lamp");
            Lamp lamp2 = new Lamp("lamp");
            row.AddLamp(lamp1);
            row.AddLamp(lamp2);

            row.TurnAllOn();
            row.TurnAllOff();

            Assert.False(lamp1.IsOn);
            Assert.False(lamp2.IsOn);
        }

        [Fact]
        public void LampRow_TurnOnOneLamp_SetsOnlyOneToTrue()
        {
            LampRow row = new LampRow();
            Lamp lamp1 = new Lamp("lamp");
            Lamp lamp2 = new Lamp("lamp");
            row.AddLamp(lamp1);
            row.AddLamp(lamp2);

            row.TurnOnOneLamp("lamp");

            Assert.True(lamp1.IsOn);
            Assert.False(lamp2.IsOn);
        }

        [Fact]
        public void LampRow_TurnOffOneLamp_SetsOnlyOneToFalse()
        {
            LampRow row = new LampRow();
            Lamp lamp1 = new Lamp("lamp");
            Lamp lamp2 = new Lamp("lamp");
            row.AddLamp(lamp1);
            row.AddLamp(lamp2);

            row.TurnAllOn();
            row.TurnOffOneLamp(lamp1);

            Assert.False(lamp1.IsOn);
            Assert.True(lamp2.IsOn);
        }

        [Fact]
        public void LampRow_SetOneBrightness_SetsCorrectValue()
        {
            LampRow row = new LampRow();
            Lamp lamp1 = new Lamp("lamp");
            row.AddLamp(lamp1);

            row.SetOneBrightness(lamp1, 55);

            Assert.Equal(55, lamp1.BrightnessLevel);
        }

        [Fact]
        public void LampRow_SetAllSameBrightness_SetsAllEqual()
        {
            LampRow row = new LampRow();
            Lamp lamp1 = new Lamp("lamp");
            Lamp lamp2 = new Lamp("lamp");
            row.AddLamp(lamp1);
            row.AddLamp(lamp2);

            row.SetAllSameBrightness(70);

            Assert.Equal(70, lamp1.BrightnessLevel);
            Assert.Equal(70, lamp2.BrightnessLevel);
        }
        [Fact]
        public void LampRow_SetOneEcoLampBrightnessToEco_SetsEcoBrightness()
        {
            LampRow row = new LampRow();
            EcoLamp ecoLamp = new EcoLamp("lamp");
            ecoLamp.TurnOn();
            ecoLamp.SetBrightness(90);
            row.AddLamp(ecoLamp);

            row.SetOneEcoLampBrightnessToEco(ecoLamp);

            Assert.Equal(40, ecoLamp.BrightnessLevel); 
        }

        [Fact]
        public void LampRow_SetAllEcoLampsBrightnessToEco_SetsAllToEcoLevel()
        {
            LampRow row = new LampRow();
            EcoLamp eco1 = new EcoLamp("lamp");
            EcoLamp eco2 = new EcoLamp("lamp");
            eco1.TurnOn();
            eco2.TurnOn();
            eco1.SetBrightness(90);
            eco2.SetBrightness(75);
            row.AddLamp(eco1);
            row.AddLamp(eco2);

            row.SetAllEcoLampsBrightnessToEco();

            Assert.Equal(40, eco1.BrightnessLevel);
            Assert.Equal(40, eco2.BrightnessLevel);
        }

        [Fact]
        public void LampRow_TurnOneEcoLampOffAfterTime_SetsIsOnToFalseIfExpired()
        {
            LampRow row = new LampRow();
            EcoLamp eco = new EcoLamp("lamp");
            eco.TurnOn();
            eco.SetOnTime(DateTime.UtcNow.AddMinutes(-60)); 
            row.AddLamp(eco);

            row.TurnOneEcoLampOffAfterTime(eco);

            Assert.False(eco.IsOn);
        }

        [Fact]
        public void LampRow_TurnAllEcoLampsOffAfterTime_SetsAllToFalseIfExpired()
        {
            LampRow row = new LampRow();
            EcoLamp eco1 = new EcoLamp("lamp");
            EcoLamp eco2 = new EcoLamp("lamp");
            eco1.TurnOn();
            eco2.TurnOn();
            eco1.SetOnTime(DateTime.UtcNow.AddMinutes(-51));
            eco2.SetOnTime(DateTime.UtcNow.AddMinutes(-53));
            row.AddLamp(eco1);
            row.AddLamp(eco2);

            row.TurnAllEcoLampsOffAfterTime();

            Assert.False(eco1.IsOn);
            Assert.False(eco2.IsOn);
        }
    }
}
