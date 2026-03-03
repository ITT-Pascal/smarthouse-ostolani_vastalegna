using BlaisePascal.SmartHouse.Domain.Abstraction;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Commands
{
    public class AddLampCommand
    {
        private readonly ILampRepository _lampRepository;
        public AddLampCommand(ILampRepository repository)
        {
            _lampRepository = repository;
        }
        public void Execute(string name)
        {
            _lampRepository.Add(new Lamp(DeviceName.Create(name)));
        }
        
    }
}
