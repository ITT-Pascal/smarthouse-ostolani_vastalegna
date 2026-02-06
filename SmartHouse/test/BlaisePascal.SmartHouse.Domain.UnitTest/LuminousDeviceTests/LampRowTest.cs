using BlaisePascal.SmartHouse.Domain.Abstraction;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.LuminousDeviceTests
{
    public class LampRowTest
    {
        // ON - OFF
        [Fact]
        public void LampRow_TurnAllOn_SetsAllIsOnToTrue()
        {
            LampRow row = new LampRow("LampsRow");
            Lamp lamp1 = new Lamp("lamp1");
            Lamp lamp2 = new Lamp("lamp2");
            row.AddLamp(lamp1);
            row.AddLamp(lamp2);

            row.SwitchOn();

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

            row.SwitchOn();
            row.SwitchOff();

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

            row.SwitchOneOneLamp("lamp1");

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

            row.SwitchOn();
            row.SwitchOffOneLamp("lamp2");

            Assert.Equal(DeviceStatus.On, lamp1.Status);
            Assert.Equal(DeviceStatus.Off, lamp2.Status);
        }


        [Fact]
        public void LampRow_TurnOnOneLampByGuid_ThrowsExceptionIfNotFound()
        {
            var row = new LampRow("Row");
            var lamp1 = new Lamp("l1");
            row.AddLamp(lamp1);

            Assert.Throws<ArgumentException>(() => row.SwitchOneOneLamp(Guid.NewGuid()));
        }

        [Fact]
        public void LampRow_TurnOnOneLampByName_ThrowsExceptionIfNotFound()
        {
            var row = new LampRow("Row");
            var lamp1 = new Lamp("l1");
            row.AddLamp(lamp1);

            Assert.Throws<ArgumentException>(() => row.SwitchOneOneLamp("prova"));
        }

        // BRIGHTNESS
        [Fact]
        public void LampRow_SetOneBrightness_SetsCorrectValue()
        {
            LampRow row = new LampRow("LampsRow");
            Lamp lamp1 = new Lamp("lamp1");
            row.AddLamp(lamp1);

            row.SetBrightnessOneLamp(55, "lamp1");

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

            row.SetBrightness(70);

            Assert.Equal(70, lamp1.Brightness);
            Assert.Equal(70, lamp2.Brightness);
        }

        // ECO METHODS
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

        
        // LAMP MANAGING

        [Fact]
        public void LampRow_AddLampInPosition_InsertsLampCorrectly()
        {
            var row = new LampRow("Row");
            var lamp1 = new Lamp("l1");
            var lamp2 = new Lamp("l2");
            var lamp3 = new Lamp("l3");

            row.AddLamp(lamp1); 
            row.AddLamp(lamp3);
            row.AddLampInPosition(lamp2, 1); 

            Assert.Equal(3, row.Lamps.Count);
            Assert.Equal("l2", row.Lamps[1].Name);
        }

        [Fact]
        public void LampRow_RemoveLampById_RemovesCorrectLamp()
        {
            var row = new LampRow("Row");
            var lamp1 = new Lamp("l1");
            var lamp2 = new Lamp("l2");
            row.AddLamp(lamp1);
            row.AddLamp(lamp2);

            row.RemoveLamp(lamp1.Id);

            Assert.Single(row.Lamps);
            Assert.Equal("l2", row.Lamps[0].Name);
        }

        [Fact]
        public void LampRow_RemoveLampInPosition_RemovesCorrectLamp()
        {
            var row = new LampRow("Row");
            var lamp1 = new Lamp("l1");
            var lamp2 = new Lamp("l2");
            row.AddLamp(lamp1);
            row.AddLamp(lamp2);

            row.RemoveLampInPosition(0);

            Assert.Single(row.Lamps);
            Assert.Equal("l2", row.Lamps[0].Name);
        }
        

        // INFO
        [Fact]
        public void LampRow_Status_ReturnsOnIfAnyLampIsOn()
        {
            var row = new LampRow("Row");
            var lamp1 = new Lamp("l1");
            var lamp2 = new Lamp("l2");
            row.AddLamp(lamp1);
            row.AddLamp(lamp2);
            lamp2.SwitchOn();

            Assert.Equal(DeviceStatus.On, row.GetStatus());
        }

        [Fact]
        public void LampRow_Status_ReturnsOffIfAllLampsAreOff()
        {
            var row = new LampRow("Row");
            var lamp1 = new Lamp("l1");
            var lamp2 = new Lamp("l2");
            row.AddLamp(lamp1);
            row.AddLamp(lamp2);

            Assert.Equal(DeviceStatus.Off, row.GetStatus());
        }

        // BRIGHTEN - DIMMER
        [Fact]
        public void LampRow_BrightenByPosition_ThrowsExceptionIfOutOfRange()
        {
            var row = new LampRow("Row");
            var lamp1 = new Lamp("l1");
            row.AddLamp(lamp1);

            Assert.Throws<ArgumentOutOfRangeException>(() => row.Brighten(1, 10));
            Assert.Throws<ArgumentOutOfRangeException>(() => row.Dimmer(-1, 10));
        }

        [Fact]
        public void LampRow_Brighten_IncreasesBrightness()
        {
            var row = new LampRow("Row");
            var lamp = new Lamp("l1");
            lamp.SetBrightness(Brightness.Create(50));
            row.AddLamp(lamp);
            lamp.SwitchOn();
            row.Brighten(0, 10);

            Assert.Equal(60, lamp.Brightness);
        }

        [Fact]
        public void LampRow_Dimmer_DecreasesBrightness()
        {
            var row = new LampRow("Row");
            var lamp = new Lamp("l1");
            lamp.SetBrightness(50);
            lamp.SwitchOn();
            row.AddLamp(lamp);
            row.Dimmer(0, 10);

            Assert.Equal(40, lamp.Brightness);
        }


        // SEARCH

        [Fact]
        public void LampRow_FindLampWithMaxBrightness_ReturnsCorrectLamp()
        {
            var row = new LampRow("Row");
            var lamp1 = new Lamp("l1"); lamp1.SetBrightness(10);
            var lamp2 = new Lamp("l2"); lamp2.SetBrightness(90);
            var lamp3 = new Lamp("l3"); lamp3.SetBrightness(50);
            row.AddLamp(lamp1);
            row.AddLamp(lamp2);
            row.AddLamp(lamp3);

            var maxLamp = row.FindLampWithMaxBrightness();

            Assert.Equal("l2", maxLamp.Name);
            Assert.Equal(90, maxLamp.Brightness);
        }

        [Fact]
        public void LampRow_FindLampWithMinBrightness_ReturnsCorrectLamp()
        {
            var row = new LampRow("Row");
            var lamp1 = new Lamp("l1"); lamp1.SetBrightness(10);
            var lamp2 = new Lamp("l2"); lamp2.SetBrightness(90);
            var lamp3 = new Lamp("l3"); lamp3.SetBrightness(5);
            row.AddLamp(lamp1);
            row.AddLamp(lamp2);
            row.AddLamp(lamp3);

            var minLamp = row.FindLampWithMinBrightness();

            Assert.Equal("l3", minLamp.Name);
            Assert.Equal(5, minLamp.Brightness);
        }

        [Fact]
        public void LampRow_FindLampsByIntensityRange_ReturnsCorrectLamps()
        {
            var row = new LampRow("Row");
            var lamp1 = new Lamp("l1"); lamp1.SetBrightness(10);
            var lamp2 = new Lamp("l2"); lamp2.SetBrightness(60);
            var lamp3 = new Lamp("l3"); lamp3.SetBrightness(90);
            row.AddLamp(lamp1);
            row.AddLamp(lamp2);
            row.AddLamp(lamp3);

            var result = row.FindLampsByIntensityRange(50, 80);

            Assert.Single(result);
            Assert.Equal("l2", result[0].Name);
        }

        [Fact]
        public void LampRow_FindAllOn_ReturnsOnlyOnLamps()
        {
            var row = new LampRow("Row");
            var lamp1 = new Lamp("l1"); lamp1.SwitchOn();
            var lamp2 = new Lamp("l2"); // Off
            var lamp3 = new Lamp("l3"); lamp3.SwitchOn();
            row.AddLamp(lamp1);
            row.AddLamp(lamp2);
            row.AddLamp(lamp3);

            var onLamps = row.FindAllOn();

            Assert.Equal(2, onLamps.Count);
            Assert.True(onLamps.All(l => l.Status == DeviceStatus.On));
        }

        [Fact]
        public void LampRow_FindAllOff_ReturnsOnlyOffLamps()
        {
            var row = new LampRow("Row");
            var lamp1 = new Lamp("l1"); lamp1.SwitchOn();
            var lamp2 = new Lamp("l2"); // Off
            var lamp3 = new Lamp("l3"); lamp3.SwitchOn();
            var lamp4 = new Lamp("l4"); // Off
            row.AddLamp(lamp1);
            row.AddLamp(lamp2);
            row.AddLamp(lamp3);
            row.AddLamp(lamp4);

            var offLamps = row.FindAllOff();

            Assert.Equal(2, offLamps.Count);
            Assert.True(offLamps.All(l => l.Status == DeviceStatus.Off));
        }

        [Fact]
        public void LampRow_FindLampById_ReturnsCorrectLamp()
        {
            var row = new LampRow("Row");
            var lamp1 = new Lamp("l1");
            var lamp2 = new Lamp("l2");
            row.AddLamp(lamp1);
            row.AddLamp(lamp2);

            var found = row.FindLampById(lamp1.Id);

            Assert.NotNull(found);
            Assert.Equal(lamp1.Name, found.Name);
        }

        [Fact]
        public void LampRow_FindLampById_ReturnsNullIfNotFound()
        {
            var row = new LampRow("Row");
            var lamp1 = new Lamp("l1");
            row.AddLamp(lamp1);

            var found = row.FindLampById(Guid.NewGuid());

            Assert.Null(found);
        }


        // SORT
        [Fact]
        public void LampRow_SortByBrightness_Ascending()
        {
            var row = new LampRow("Row");
            var lamp1 = new Lamp("l1"); lamp1.SetBrightness(50);
            var lamp2 = new Lamp("l2"); lamp2.SetBrightness(10);
            var lamp3 = new Lamp("l3"); lamp3.SetBrightness(90);
            row.AddLamp(lamp1);
            row.AddLamp(lamp2);
            row.AddLamp(lamp3);

            var sorted = row.SortByBrightness(false); // false = crescente

            Assert.Equal(3, sorted.Count);
            Assert.Equal(10, sorted[0].Brightness);
            Assert.Equal(50, sorted[1].Brightness);
            Assert.Equal(90, sorted[2].Brightness);
        }

        [Fact]
        public void LampRow_SortByBrightness_Descending()
        {
            var row = new LampRow("Row");
            var lamp1 = new Lamp("l1"); lamp1.SetBrightness(50);
            var lamp2 = new Lamp("l2"); lamp2.SetBrightness(10);
            var lamp3 = new Lamp("l3"); lamp3.SetBrightness(90);
            row.AddLamp(lamp1);
            row.AddLamp(lamp2);
            row.AddLamp(lamp3);

            var sorted = row.SortByBrightness(true); // true = decrescente

            Assert.Equal(3, sorted.Count);
            Assert.Equal(90, sorted[0].Brightness);
            Assert.Equal(50, sorted[1].Brightness);
            Assert.Equal(10, sorted[2].Brightness);
        }

        

        
    }
}
