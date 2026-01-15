using BlaisePascal.SmartHouse.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.LuminuosDevice
{
    public abstract class AbstractLamp: AbstractDevice, ILuminousDevice
    {
        //Constants
        public const int MaxBrightnessLevel = 100;
        public const int MinBrightnessLevel = 1;

        //Properties
        public int Brightness { get; protected set; }




        //Constructors
        protected AbstractLamp(string name): base(name)
        {
           Brightness = MaxBrightnessLevel;

        }
        public AbstractLamp(Guid guid, string name): base(guid, name)
        {
            Brightness = MaxBrightnessLevel;

        }

        

        public virtual void Dimmer(int amount)
        {
            OnValidator();
            if (amount < 1)
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount deve essere almeno 1.");

            Brightness = Math.Max(MinBrightnessLevel, Brightness - amount);

        }

        public virtual void Brighten(int amount)
        {
            OnValidator();
            if (amount < 1)
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount deve essere almeno 1.");

            Brightness = Math.Min(MaxBrightnessLevel, Brightness + amount);

        }

        public virtual void SetBrightness(int newBrightness)
        {
            if (newBrightness < MinBrightnessLevel || newBrightness > MaxBrightnessLevel)
            {
                throw new ArgumentOutOfRangeException($"Brightness level must be between {MinBrightnessLevel} and {MaxBrightnessLevel}.");
            }
            Brightness = newBrightness;
        }
    }
}
