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
        public DeviceName Name { get; protected set; }
        public DeviceStatus Status { get; protected set; }
        public DateTime CreatedAtUtc { get; protected set; }
        public DateTime LastModifiedAtUtc { get; protected set; }

        protected AbstractDevice(DeviceName name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Status = DeviceStatus.Off;
            CreatedAtUtc = DateTime.Now;
            LastModifiedAtUtc = DateTime.Now;
        }
        public AbstractDevice(Guid guid, DeviceName name)
        {
            CreatedAtUtc = DateTime.UtcNow;
            LastModifiedAtUtc = DateTime.Now;
            Status = DeviceStatus.Off;
            Id = guid;
            Name = name;
        }

        public AbstractDevice(Guid guid, DeviceName name, DeviceStatus deviceStatus, DateTime creationTime, DateTime lastUpdateTime)
        {
            Id = guid;
            Name = name;
            Status = deviceStatus;
            CreatedAtUtc = creationTime;
            LastModifiedAtUtc = lastUpdateTime;

            
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
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public virtual void SwitchOff()
        {
            OnValidator();

            Status = DeviceStatus.Off;
            LastModifiedAtUtc = DateTime.UtcNow;
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
