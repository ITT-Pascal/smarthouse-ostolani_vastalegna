using BlaisePascal.SmartHouse.Domain.LuminuosDevice;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Commands
{
    public class SwitchOnCommand
    {
        private readonly ILampRepository _lamprepository;

        public SwitchOnCommand(ILampRepository lamprepository)
        {
            _lamprepository = lamprepository;
        }

        public void Execute(Guid lampId)
        {
            Lamp lamp = _lamprepository.GetById(lampId);
            if (lamp != null)
            {
                lamp.SwitchOn();
                _lamprepository.Update(lamp);
            }
        }

    }
}
