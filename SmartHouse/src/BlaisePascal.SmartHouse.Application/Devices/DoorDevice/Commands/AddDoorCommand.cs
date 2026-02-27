using BlaisePascal.SmartHouse.Domain.DoorDevice;
using BlaisePascal.SmartHouse.Domain.DoorDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevice.Commands
{
    public class AddDoorCommand
    {
        private readonly IDoorRepository _doorRepository;
        public AddDoorCommand(IDoorRepository repository)
        {
            _doorRepository = repository;
        }
        public void Execute(string name, int pin)
        {
            _doorRepository.Add(new Door(name, pin));
        }

    }
}
