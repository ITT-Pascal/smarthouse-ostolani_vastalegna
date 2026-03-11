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
    public class RemoveCCTVCommand
    {
        private readonly ICCTVRepository _cctvRepository;

        public RemoveCCTVCommand(ICCTVRepository CCTVRepository)
        {
            _cctvRepository = CCTVRepository;
        }

        public void Execute(Guid cctvId)
        {
            CCTV cctv = _cctvRepository.GetById(cctvId);
            _cctvRepository.Remove(cctvId);
        }

    }
}
