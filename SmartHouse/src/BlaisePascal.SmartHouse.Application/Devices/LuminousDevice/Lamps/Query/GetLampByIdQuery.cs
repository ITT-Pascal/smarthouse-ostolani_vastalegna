using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Dto;
using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Mapper;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Query
{

    public class GetLampByIdQuery
    {
        private readonly ILampRepository _repository;

        public GetLampByIdQuery(ILampRepository repository)
        {
            _repository = repository;
        }

        public LampDto Execute(Guid id)
        {
            var l = _repository.GetById(id);
            if (l != null)
            {
                return LampMapper.ToDto(l);
            }
            return null;
        }
    }

}
