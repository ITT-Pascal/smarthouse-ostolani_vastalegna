namespace BlaisePascal.SmartHouse.Domain
{
    public class Lamp: LampModel
    {
        public const int MaxBrightnessLevel = 100;
        public const int MinBrightnessLevel = 1;


        public DateTime CreationTime { get; private set; }
        public DateTime OnTime { get; private set; }

        
        public Lamp(Guid guid)
        {
            IsOn = false;
            CreationTime = DateTime.UtcNow;
            BrightnessLevel = MaxBrightnessLevel;
            Id = guid;
        }
        public Lamp()
        {
            IsOn = false;
            CreationTime = DateTime.UtcNow;
            BrightnessLevel = MaxBrightnessLevel;
            Id = new Guid();
        }

        public override void TurnOff()
        {
            if (IsOn)
                IsOn = false;
                OnTime = DateTime.MinValue;

        }
        public override void TurnOn()
        {
            if (!IsOn)
                IsOn = true;
                OnTime = DateTime.UtcNow;
        }

        public override void SetBrightness(int newBrightness)
        {
            if (newBrightness < MinBrightnessLevel || newBrightness > MaxBrightnessLevel)
            {
                throw new ArgumentOutOfRangeException($"Brightness level must be between {MinBrightnessLevel} and {MaxBrightnessLevel}.");
            }
            BrightnessLevel = newBrightness;
        }
    }
}