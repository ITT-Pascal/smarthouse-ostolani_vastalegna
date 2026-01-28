using BlaisePascal.SmartHouse.Domain.Abstraction;
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

        public Door(string name, int pin) : base(name)
        {
            DoorStatus = DoorStatus.Closed;
            LockStatus = LockStatus.Unlocked;
            Status = DeviceStatus.On;
            Pin = Pin.Create(pin);
        }
        public Door(Guid guid, string name, int pin) : base(guid, name)
        {
            DoorStatus = DoorStatus.Closed;
            LockStatus = LockStatus.Unlocked;
            Status = DeviceStatus.On;
            Pin = Pin.Create(pin);
        }

        public void SetNewPin(int pin)
        {
            CheckUnlocked();
            Pin = Pin.Create(pin);
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

        public void Unlock(Pin pin)
        {
            CheckPin(pin);
            OnValidator();
            CheckLocked();
            LockStatus = LockStatus.Unlocked;
            LastStatusChangeTime = DateTime.UtcNow;
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
