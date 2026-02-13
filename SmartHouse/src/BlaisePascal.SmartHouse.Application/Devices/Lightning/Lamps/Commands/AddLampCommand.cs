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
            _lampRepository.Add(new Lamp(name));
        }
        public void Execute(Guid lampId)
        {
            Lamp lamp =_lampRepository.GetById(lampId);
            if (lamp != null)
            {
                lamp.SwitchOn();
                _lampRepository.Update(lamp);
            }
        }
    }
}
