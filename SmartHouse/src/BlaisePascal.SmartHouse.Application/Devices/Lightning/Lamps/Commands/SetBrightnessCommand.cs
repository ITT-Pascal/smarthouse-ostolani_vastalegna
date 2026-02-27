using BlaisePascal.SmartHouse.Domain.LuminuosDevice;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Commands
{

    public class SetBrightnessCommand
    {
        private readonly ILampRepository _repository;

        public SetBrightnessCommand(ILampRepository repository)
        {
            _repository = repository;
        }

        public void Execute(Guid lampId, int brightness)
        {
            var lamp = _repository.GetById(lampId);
            if (lamp != null)
            {
                lamp.SetBrightness(Brightness.Create(brightness));
                _repository.Update(lamp);
            }
        }
    }
}
