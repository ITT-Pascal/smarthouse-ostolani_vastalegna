using BlaisePascal.SmartHouse.Domain.LuminuosDevice;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice.Repository;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Commands
{
    public class RemoveLampCommand
    {
        private readonly ILampRepository _lampRepository;

        public RemoveLampCommand(ILampRepository lampRepository)
        {
            _lampRepository = lampRepository;
        }

        public void Execute(Guid lampId)
        {
            Lamp lamp = _lampRepository.GetById(lampId);
            if (lamp != null)
            {
                _lampRepository.Remove(lampId);
            }
        }

    }
}
