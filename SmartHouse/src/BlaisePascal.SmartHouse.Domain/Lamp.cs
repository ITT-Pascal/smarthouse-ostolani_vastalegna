namespace BlaisePascal.SmartHouse.Domain
{
    public class Lamp: LampModel
    {
        public const int MaxBrightnessLevel = 100;
        public const int MinBrightnessLevel = 1;


        public Lamp(Guid guid, string name)
        {
            IsOn = false;
            CreationTime = DateTime.UtcNow;
            BrightnessLevel = MaxBrightnessLevel;
            Id = guid;
            Name = name;
        }
        public Lamp(string name)
        {
            IsOn = false;
            CreationTime = DateTime.UtcNow;
            BrightnessLevel = MaxBrightnessLevel;
            Id = Guid.NewGuid();
            Name = name;
        }

        public override void TurnOff()
        {
            if (IsOn)
            {
                IsOn = false;
                LastModifiedTime = DateTime.UtcNow;
            }
        }
        public override void TurnOn()
        {
            if (!IsOn)
            {
                IsOn = true;
                LastModifiedTime = DateTime.UtcNow;
            }
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