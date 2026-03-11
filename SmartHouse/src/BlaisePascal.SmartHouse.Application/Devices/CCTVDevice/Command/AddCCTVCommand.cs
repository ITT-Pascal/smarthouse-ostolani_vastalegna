using BlaisePascal.SmartHouse.Domain.Abstraction;
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
    public class AddCCTVCommand
    {
        private readonly ICCTVRepository _cctvRepository;
        public AddCCTVCommand(ICCTVRepository repository)
        {
            _cctvRepository = repository;
        }
        public void Execute(string name)
        {
            _cctvRepository.Add(new CCTV(DeviceName.Create(name)));
        }

    }
}
