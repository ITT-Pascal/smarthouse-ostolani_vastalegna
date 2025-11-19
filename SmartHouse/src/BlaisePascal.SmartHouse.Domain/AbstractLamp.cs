using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public abstract class AbstractLamp
    {
        public bool IsOn {  get; protected set; }
        public int BrightnessLevel { get; protected set; }
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public DeviceStatus Status { get; protected set; }
        public DateTime CreationTime { get; protected set; }
        public DateTime LastModifiedTime { get; protected set; }


        public abstract void TurnOff();
        public abstract void TurnOn();
        public abstract void SetBrightness(int newBrightness);

        protected AbstractLamp(string name) 
        {
            Id = Guid.NewGuid();
            Name = name;
            Status = DeviceStatus.Off;
            CreationTime = DateTime.Now;
            LastModifiedTime = DateTime.Now;

        }

        public void Toggle()
        {
            if (IsOn)
                TurnOff();
            else
                TurnOn();
            LastModifiedTime = DateTime.Now;

        }

        public void Dimmer(int amount)
        {
            if (Stutus == DeviceStatus.Off)
        }
    }
}
