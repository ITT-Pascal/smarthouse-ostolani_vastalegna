namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class LampTest
    {
        [Fact]
        public void Lamp_TurnOn_SetsIsOnToTrue()
        {
            Lamp lamp = new Lamp();
            lamp.TurnOn();
            Assert.True(lamp.IsOn);
        }
        [Fact]
        public void Lamp_TurnOff_SetsIsOnToFalse()
        {
            Lamp lamp = new Lamp();
            lamp.TurnOn();
            lamp.TurnOff();
            Assert.False(lamp.IsOn);
        }
        [Fact]
        public void Lamp_SetBrightness_ValidLevel_SetsBrightnessLevel()
        {
            Lamp lamp = new Lamp();
            lamp.SetBrightness(50);
            Assert.Equal(50, lamp.BrightnessLevel);
        }
        [Fact]
        public void Lamp_SetBrightness_NegativeLevel_ThrowsArgumentOutOfRangeException()
        {
            Lamp lamp = new Lamp();
            Assert.Throws<ArgumentOutOfRangeException>(() =>lamp.SetBrightness(-5));
        }

        [Fact]
        public void Lamp_SetBrightness_AboveMaxLevel_ThrowsArgumentOutOfRangeException()
        {
            Lamp lamp = new Lamp();

            Assert.Throws<ArgumentOutOfRangeException>(() => lamp.SetBrightness(Lamp.MaxBrightnessLevel+1));
        }
    }
}