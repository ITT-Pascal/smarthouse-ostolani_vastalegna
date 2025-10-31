namespace BlaisePascal.SmartHouse.Domain
{
    public class Lamp
    {
        public bool IsOn { get; private set; }
        public int BrightnessLevel { get; private set; }
        public int MaxBrightnessLevel { get; private set; } = 100;

        public Lamp()
        {
            IsOn = false;
        }

        public void TurnOff()
        {
            IsOn = false;
        }
        public void TurnOn()
        {
            IsOn = true;
        }

        public void SetBrightness(int levelOfBrightness)
        {
            if (levelOfBrightness < 0 || levelOfBrightness > MaxBrightnessLevel)
            {
                throw new ArgumentOutOfRangeException("Brightness level must be between 0 and MaxBrightnessLevel.");
            }
            BrightnessLevel = levelOfBrightness;
        }
    }
}