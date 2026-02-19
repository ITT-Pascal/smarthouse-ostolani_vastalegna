using BlaisePascal.SmartHouse.Domain.DoorDevice;
using BlaisePascal.SmartHouse.Domain.DoorDevice.Repository;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevice.Commands
{
    internal class OpenDoorCommand
    {
        private readonly IDoorRepository _doorRepository;

        public OpenDoorCommand(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public void Execute(Guid lampId)
        {
            Door door = _doorRepository.GetById(lampId);
            door.Open();
            _doorRepository.Update(door);
        }

    }
}
