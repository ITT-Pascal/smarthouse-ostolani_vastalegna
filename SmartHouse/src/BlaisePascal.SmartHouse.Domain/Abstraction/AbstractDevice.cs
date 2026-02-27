using BlaisePascal.SmartHouse.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public abstract class AbstractDevice: ISwitchable
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public DeviceStatus Status { get; protected set; }
        public DateTime CreationTime { get; protected set; }
        public DateTime LastStatusChangeTime { get; protected set; }

        protected AbstractDevice(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Status = DeviceStatus.Off;
            CreationTime = DateTime.Now;
            LastStatusChangeTime = DateTime.Now;
        }
        public AbstractDevice(Guid guid, string name)
        {
            CreationTime = DateTime.UtcNow;
            LastStatusChangeTime = DateTime.Now;
            Status = DeviceStatus.Off;
            Id = guid;
            Name = name;
        }

        //Methods
        public virtual void Toggle()
        {
            if (Status == DeviceStatus.On)
                SwitchOff();
            else
                SwitchOn();
        }
        public virtual void SwitchOn()
        {
            OffValidator();
            Status = DeviceStatus.On;
            LastStatusChangeTime = DateTime.UtcNow;
        }

        public virtual void SwitchOff()
        {
            OnValidator();

            Status = DeviceStatus.Off;
            LastStatusChangeTime = DateTime.UtcNow;
        }

        // Validator
        public virtual void OnValidator()
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("Device is off");
        }
        public virtual void OffValidator()
        {
            if (Status == DeviceStatus.On)
                throw new InvalidOperationException("Device is on");
        }
    }
}
