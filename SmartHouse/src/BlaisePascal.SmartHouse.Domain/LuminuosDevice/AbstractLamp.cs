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
        public Brightness DefaultBrightnessStep = Brightness.Create(5);

        //Properties
        public Brightness Brightness { get; protected set; }




        //Constructors
        protected AbstractLamp(DeviceName name): base(name)
        {
           Brightness = MaxBrightness;

        }
        public AbstractLamp(Guid guid, DeviceName name): base(guid, name)
        {
            Brightness = MinBrightness;

        }

        public AbstractLamp(Guid guid, DeviceName name, DeviceStatus deviceStatus, Brightness brightness, DateTime creationTime, DateTime lastUpdateTime) : base(guid, name, deviceStatus, creationTime, lastUpdateTime)
        {
            Brightness = brightness;
        }


        public virtual void Dimmer()
        {
            OnValidator();
            Brightness = Brightness.Create(Math.Max(MinBrightness.Value, Brightness.Value - DefaultBrightnessStep.Value));


        }

        public virtual void Brighten()
        {
            OnValidator();

            Brightness = Brightness.Create(Math.Min(MaxBrightness.Value, Brightness.Value + DefaultBrightnessStep.Value));

        }

        public virtual void SetBrightness(Brightness newBrightness) 
        {
            OnValidator();
            Brightness = newBrightness;
        }

    }
}
