using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain
{
    public abstract class AbstactDevice
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public DeviceStatus Status { get; protected set; }
        public DateTime CreationTime { get; protected set; }
        public DateTime LastStatusChangeTime { get; protected set; }

        protected AbstactDevice(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Status = DeviceStatus.Off;
            CreationTime = DateTime.Now;
            LastStatusChangeTime = DateTime.Now;
        }
        public AbstactDevice(Guid guid, string name)
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
            if (Status == DeviceStatus.On)
                throw new InvalidOperationException("Device è già acceso");

            Status = DeviceStatus.On;
            LastStatusChangeTime = DateTime.UtcNow;
        }

        public virtual void SwitchOff()
        {
            if (Status == DeviceStatus.Off)
                throw new InvalidOperationException("Device è già spento");

            Status = DeviceStatus.Off;
            LastStatusChangeTime = DateTime.UtcNow;
        }
    }
}
