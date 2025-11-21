using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public abstract class AbstractLamp: AbstactDevice
    {
        //Constants
        public const int MaxBrightnessLevel = 100;
        public const int MinBrightnessLevel = 1;

        //Properties
        public int BrightnessLevel { get; protected set; }




        //Constructors
        protected AbstractLamp(string name): base(name)
        {
           BrightnessLevel = MaxBrightnessLevel;

        }
        public AbstractLamp(Guid guid, string name): base(guid, name)
        {
            BrightnessLevel = MaxBrightnessLevel;

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
