using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public abstract class AbstractLamp
    {

        public const int MaxBrightnessLevel = 100;
        public const int MinBrightnessLevel = 1;

        public int BrightnessLevel { get; protected set; }
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public DeviceStatus Status { get; protected set; }
        public DateTime CreationTime { get; protected set; }
        public DateTime LastModifiedTime { get; protected set; }



        protected AbstractLamp(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Status = DeviceStatus.Off;
            CreationTime = DateTime.Now;
            LastModifiedTime = DateTime.Now;
            BrightnessLevel = MaxBrightnessLevel;

        }
        public AbstractLamp(Guid guid, string name)
        {
            CreationTime = DateTime.UtcNow;
            LastModifiedTime = DateTime.Now;
            BrightnessLevel = MaxBrightnessLevel;
            Status = DeviceStatus.Off;
            Id = guid;
            Name = name;
        }

        
        public virtual void SwitchOn()
        {
            if (Status == DeviceStatus.On)
                throw new InvalidOperationException("Lamp è già accesa.");

            Status = DeviceStatus.On;
            LastModifiedTime = DateTime.UtcNow;
        }

        public virtual void SwitchOff()
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("Lamp è già spenta.");

            Status = DeviceStatus.Off;
            LastModifiedTime = DateTime.UtcNow;
        }

        public virtual void Dimmer(int amount)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("La lampada è spenta.");

            if (amount < 1)
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount deve essere almeno 1.");

            BrightnessLevel = Math.Max(MinBrightnessLevel, BrightnessLevel - amount);

        }

        public virtual void Brighten(int amount)
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("La lampada è spenta.");

            if (amount < 1)
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount deve essere almeno 1.");

            BrightnessLevel = Math.Min(MaxBrightnessLevel, BrightnessLevel + amount);

        }

        public virtual void SetBrightness(int levelOfBrightness)
        {
            if (levelOfBrightness < MinBrightnessLevel || levelOfBrightness > MaxBrightnessLevel)
            {
                throw new ArgumentOutOfRangeException($"Brightness level must be between {MinBrightnessLevel} and {MaxBrightnessLevel}.");
            }
            BrightnessLevel = levelOfBrightness;
        }
    }
}
