namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Lamp_TurnOn_SetsIsOnToTrue()
        {
            var lamp = new Lamp();
            lamp.TurnOn();
            Assert.True(lamp.IsOn);
        }
        [Fact]
        public void Lamp_TurnOff_SetsIsOnToFalse()
        {
            var lamp = new Lamp();
            lamp.TurnOn();
            lamp.TurnOff();
            Assert.False(lamp.IsOn);
        }
        [Fact]
        public void Lamp_SetBrightness_ValidLevel_SetsBrightnessLevel()
        {
            var lamp = new Lamp();
            lamp.SetBrightness(50);
            Assert.Equal(50, lamp.BrightnessLevel);
        }
        [Fact]
        public void Lamp_SetBrightness_NegativeLevel_ThrowsArgumentOutOfRangeException()
        {
            var lamp = new Lamp();
            Assert.Throws<ArgumentOutOfRangeException>(() =>lamp.SetBrightness(-5));
        }

        [Fact]
        public void Lamp_SetBrightness_AboveMaxLevel_ThrowsArgumentOutOfRangeException()
        {
            var lamp = new Lamp();
            Assert.Throws<ArgumentOutOfRangeException>(() => lamp.SetBrightness(lamp.MaxBrightnessLevel+1));
        }
    }
}