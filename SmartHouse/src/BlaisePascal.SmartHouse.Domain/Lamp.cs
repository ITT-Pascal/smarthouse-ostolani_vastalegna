namespace BlaisePascal.SmartHouse.Domain
{
    public class Lamp
    {
        const int MaxBrightnessLevel = 100;

        public bool IsOn { get; private set; }
        public int BrightnessLevel { get; private set; }
        
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

        public void SetBrightness(int newBrightness)
        {
            if (newBrightness < 0 || newBrightness > MaxBrightnessLevel)
            {
                throw new ArgumentOutOfRangeException("Brightness level must be between 0 and MaxBrightnessLevel.");
            }
            BrightnessLevel = newBrightness;
        }
    }
}