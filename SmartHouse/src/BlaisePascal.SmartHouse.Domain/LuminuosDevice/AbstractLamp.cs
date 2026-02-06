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
        public Brightness MinBrightness = Brightness.Create(Brightness.MinBrightness);
        public Brightness MaxBrightness = Brightness.Create(Brightness.MaxBrightness);

        //Properties
        public Brightness Brightness { get; protected set; }




        //Constructors
        protected AbstractLamp(string name): base(name)
        {
           Brightness = MaxBrightness;

        }
        public AbstractLamp(Guid guid, string name): base(guid, name)
        {
            Brightness = MinBrightness;

        }

        

        public virtual void Dimmer(int amount)
        {
            OnValidator();
            if (amount < 1)
                throw new ArgumentOutOfRangeException("Amount deve essere almeno 1.");

            Brightness = Brightness.Create(Math.Max(MinBrightness.Value, Brightness.Value - amount));


        }

        public virtual void Brighten(int amount)
        {
            OnValidator();
            if (amount < 1)
                throw new ArgumentOutOfRangeException("Amount deve essere almeno 1.");

            Brightness = new Brightness(Math.Min(MaxBrightness.Value, Brightness.Value + amount));

        }

        public virtual void SetBrightness(Brightness newBrightness) => Brightness = newBrightness;

    }
}
