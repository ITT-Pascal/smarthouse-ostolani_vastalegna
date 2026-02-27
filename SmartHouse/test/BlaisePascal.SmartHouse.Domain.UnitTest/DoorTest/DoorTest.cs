using BlaisePascal.SmartHouse.Domain.Abstraction;
using BlaisePascal.SmartHouse.Domain.DoorDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.UnitTest.DoorTest
{
    public class DoorTest
    {

        //Open

        [Fact]
        public void When_DoorIsAlreadyOpen_ShouldThrow()
        {
            Door d = new Door("Door", 1234);
            d.Open();
            Assert.Throws<InvalidOperationException>(() => d.Open());
        }

        [Fact]
        public void When_DoorIsLockedAndTryToOpen_ShouldThrow()
        {
            Door d = new Door("Door", 1234);
            d.Lock();
            Assert.Throws<InvalidOperationException>(() => d.Open());
        }

        [Fact]
        public void When_DoorIsClosedAndUnlocked_ShouldOpen()
        {
            Door d = new Door("Door", 1234);
            d.Open();
            Assert.Equal(DoorStatus.Open, d.DoorStatus);
        }


        //Close

        [Fact]
        public void When_DoorIsAlreadyClosed_ShouldThrow()
        {
            Door d = new Door("Door", 1234);
            Assert.Throws<InvalidOperationException>(() => d.Close());
        }

        [Fact]
        public void When_DoorIsOpen_ShouldClose()
        {
            Door d = new Door("Door", 1234);
            d.Open();
            d.Close();

            Assert.Equal(DoorStatus.Closed, d.DoorStatus);
        }



        //Lock

        [Fact]
        public void When_DoorIsAlreadyLocked_ShouldThrow()
        {
            Door d = new Door("Door", 1234);
            d.Lock();
            Assert.Throws<InvalidOperationException>(() => d.Lock());
        }

        [Fact]
        public void When_DoorIsOpenAndTryToLock_ShouldThrow()
        {
            Door d = new Door("Door", 1234);
            d.Open();

            Assert.Throws<InvalidOperationException>(() => d.Lock());
        }

        [Fact]
        public void When_DoorIsClosedAndUnlocked_ShouldLock()
        {
            Door d = new Door("Door", 1234);
            d.Lock();

            Assert.Equal(LockStatus.Locked, d.LockStatus);
        }


        //Unlock


        [Fact]
        public void When_DoorIsAlreadyUnlocked_ShouldThrow()
        {
            Door d = new Door("Door", 1234);

            Assert.Throws<InvalidOperationException>(() => d.Unlock(Pin.Create(1234)));
        }

        [Fact]
        public void When_DoorIsLocked_ShouldUnlock()
        {
            Door d = new Door("Door", 1234);
            d.Lock();
            d.Unlock(Pin.Create(1234));

            Assert.Equal(LockStatus.Unlocked, d.LockStatus);
        }
        [Fact]
        public void When_PinIsWrong_ShouldThrow()
        {
            Door d = new Door("Door", 1234);

            Assert.Throws<InvalidOperationException>(() => d.Unlock(Pin.Create(1235)));
        }
    }
}
