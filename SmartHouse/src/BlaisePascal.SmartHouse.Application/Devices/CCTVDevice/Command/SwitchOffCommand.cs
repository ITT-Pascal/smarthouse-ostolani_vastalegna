using BlaisePascal.SmartHouse.Domain.CCTVDevice;
using BlaisePascal.SmartHouse.Domain.CCTVDevice.Repository;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVDevice.Command
{
    public class SwitchOffCommand
    {
        private readonly ICCTVRepository _cctvrepository;

        public SwitchOffCommand(ICCTVRepository cctvrepository)
        {
            _cctvrepository = cctvrepository;
        }

        public void Execute(Guid cctvId)
        {
            CCTV cctv = _cctvrepository.GetById(cctvId);
            if (cctv != null)
            {
                cctv.SwitchOff();
                _cctvrepository.Update(cctv);
            }

        }

    }
}
