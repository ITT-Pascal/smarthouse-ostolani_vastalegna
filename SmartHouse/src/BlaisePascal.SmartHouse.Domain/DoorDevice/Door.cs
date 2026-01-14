using BlaisePascal.SmartHouse.Domain.Abstraction;
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
            CheckClosed();
            CheckUnlocked();
            DoorStatus = DoorStatus.Open;
            LastStatusChangeTime = DateTime.UtcNow;
        }
        public void Close()
        {
            OnValidator();
            CheckOpen();
            DoorStatus = DoorStatus.Closed;
            LastStatusChangeTime = DateTime.UtcNow;
        }

        public void Lock()
        {
            OnValidator();
            CheckUnlocked();
            CheckClosed();
            LockStatus = LockStatus.Locked;
            LastStatusChangeTime = DateTime.UtcNow;
        }

        public void Unlock()
        {
            OnValidator();
            CheckLocked();
            LockStatus = LockStatus.Unlocked;
            LastStatusChangeTime = DateTime.UtcNow;
        }

        // Private function

        public void CheckClosed()
        {
            if (DoorStatus != DoorStatus.Closed)
                throw new InvalidOperationException("Door not closed");
        }

        public void CheckOpen()
        {
            if (DoorStatus != DoorStatus.Open)
                throw new InvalidOperationException("Door not open");
        }
        public void CheckUnlocked()
        {
            if (LockStatus != LockStatus.Unlocked)
                throw new InvalidOperationException("Door not unlocked");
        }
        public void CheckLocked()
        {
            if (LockStatus != LockStatus.Locked)
                throw new InvalidOperationException("Door not locked");
        }


    }
}
