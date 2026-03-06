using BlaisePascal.SmartHouse.Domain.Abstraction;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.DoorDevice
{
    public class Door: AbstractDevice, IOpenable, ILockable
    {
        public DoorStatus DoorStatus { get; private set; }
        public LockStatus LockStatus { get; private set; }
        public Pin Pin { get; private set; }

        public Door(DeviceName name, Pin pin) : base(name)
        {
            DoorStatus = DoorStatus.Closed;
            LockStatus = LockStatus.Unlocked;
            Status = DeviceStatus.On;
            Pin = pin;
        }
        public Door(Guid guid, DeviceName name, Pin pin) : base(guid, name)
        {
            DoorStatus = DoorStatus.Closed;
            LockStatus = LockStatus.Unlocked;
            Status = DeviceStatus.On;
            Pin = pin;
        }

        public Door(Guid guid, DeviceName name, Pin pin, DeviceStatus deviceStatus, DoorStatus doorStatus, LockStatus lockStatus, DateTime creationTime, DateTime lastUpdateTime) : base(guid, name, deviceStatus, creationTime, lastUpdateTime)
        {
            Pin = pin;
            DoorStatus = doorStatus;
            LockStatus = lockStatus;
        }

        public void SetNewPin(Pin pin)
        {
            CheckUnlocked();
            Pin = pin;
        }

        public void Open()
        {
            OnValidator();
            CheckClosed();
            CheckUnlocked();
            DoorStatus = DoorStatus.Open;
            LastModifiedAtUtc = DateTime.UtcNow;
        }
        public void Close()
        {
            OnValidator();
            CheckOpen();
            DoorStatus = DoorStatus.Closed;
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public void Lock()
        {
            OnValidator();
            CheckUnlocked();
            CheckClosed();
            LockStatus = LockStatus.Locked;
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        public void Unlock(Pin pin)
        {
            CheckPin(pin);
            OnValidator();
            CheckLocked();
            LockStatus = LockStatus.Unlocked;
            LastModifiedAtUtc = DateTime.UtcNow;
        }

        // Private function

        private void CheckClosed()
        {
            if (DoorStatus != DoorStatus.Closed)
                throw new InvalidOperationException("Door not closed");
        }

        private void CheckOpen()
        {
            if (DoorStatus != DoorStatus.Open)
                throw new InvalidOperationException("Door not open");
        }
        private void CheckUnlocked()
        {
            if (LockStatus != LockStatus.Unlocked)
                throw new InvalidOperationException("Door not unlocked");
        }
        private void CheckLocked()
        {
            if (LockStatus != LockStatus.Locked)
                throw new InvalidOperationException("Door not locked");
        }

        private void CheckPin(Pin pin)
        {
            if (Pin != pin)
                throw new InvalidOperationException("Pin not correct");
        }


    }
}
