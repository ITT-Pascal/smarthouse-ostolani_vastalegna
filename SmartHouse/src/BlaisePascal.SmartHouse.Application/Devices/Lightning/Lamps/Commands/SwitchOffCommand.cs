using BlaisePascal.SmartHouse.Domain.LuminuosDevice;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Commands
{
    internal class SwitchOffCommand
    {
        private readonly ILampRepository _lamprepository;

        public SwitchOffCommand(ILampRepository lamprepository)
        {
            _lamprepository = lamprepository;
        }

        public void Execute(Guid lampId)
        {
            Lamp lamp = _lamprepository.GetById(lampId);
            lamp.SwitchOff();
            //_lamprepository.Update(lamp);
        }

    }
}
