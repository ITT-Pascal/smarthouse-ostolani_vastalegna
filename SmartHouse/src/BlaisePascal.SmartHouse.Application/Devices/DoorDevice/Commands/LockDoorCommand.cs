using BlaisePascal.SmartHouse.Domain.DoorDevice;
using BlaisePascal.SmartHouse.Domain.DoorDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevice.Commands
{
    public class LockDoorCommand
    {
        private readonly IDoorRepository _doorRepository;

        public LockDoorCommand(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public void Execute(Guid doorId)
        {
            Door door = _doorRepository.GetById(doorId);
            door.Lock();
            _doorRepository.Update(door);
        }

    }
}
