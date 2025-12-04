using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.DoorDevice
{
    public class Door: AbstractDevice
    {
        public DoorStatus DoorStatus { get; private set; }
        public LockStatus LockStatus { get; private set; }

        public Door(string name) : base(name)
        {
            DoorStatus = DoorStatus.Closed;
            LockStatus = LockStatus.Unlocked;
            Status = DeviceStatus.On;
        }
        public Door(Guid guid, string name) : base(guid, name)
        {
            DoorStatus = DoorStatus.Closed;
            LockStatus = LockStatus.Unlocked;
            Status = DeviceStatus.On;
        }

        public void Open()
        {
            OnValidator();
            if (DoorStatus == DoorStatus.Open)
                throw new InvalidOperationException("Door is already open");
            if (LockStatus == LockStatus.Locked)
                throw new InvalidOperationException("Cannot open a locked door");

            DoorStatus = DoorStatus.Open;
            LastStatusChangeTime = DateTime.UtcNow;
        }
        public void Close()
        {
            OnValidator();
            if (DoorStatus == DoorStatus.Closed)
                throw new InvalidOperationException("Door is already closed");
            DoorStatus = DoorStatus.Closed;
            LastStatusChangeTime = DateTime.UtcNow;
        }

        public void Lock()
        {
            OnValidator();
            if (LockStatus == LockStatus.Locked)
                throw new InvalidOperationException("Door is already locked");

            if (DoorStatus != DoorStatus.Closed)
                throw new InvalidOperationException("Cannot lock an open door");

            LockStatus = LockStatus.Locked;
            LastStatusChangeTime = DateTime.UtcNow;
        }

        public void Unlock()
        {
            OnValidator();
            if (LockStatus == LockStatus.Unlocked)
                throw new InvalidOperationException("Door is already unlocked");
            LockStatus = LockStatus.Unlocked;
            LastStatusChangeTime = DateTime.UtcNow;
        }


    }
}
