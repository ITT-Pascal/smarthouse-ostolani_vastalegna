using BlaisePascal.SmartHouse.Domain.Abstraction;
using BlaisePascal.SmartHouse.Domain.DoorDevice;
using BlaisePascal.SmartHouse.Domain.DoorDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevice.Commands
{
    public class SetPinCommand
    {
        private readonly IDoorRepository _doorRepository;

        public SetPinCommand(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public void Execute(Guid doorId, Pin pin)
        {
            Door door = _doorRepository.GetById(doorId);
            door.SetNewPin(pin);
            _doorRepository.Update(door);
        }

    }
}
