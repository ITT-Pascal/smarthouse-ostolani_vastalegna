using BlaisePascal.SmartHouse.Application.Devices.DoorDevice.Dto;
using BlaisePascal.SmartHouse.Application.Devices.DoorDevice.Mapper;
using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Dto;
using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Mapper;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevice.Query
{


    public class GetDoorByIdQuery
    {
        private readonly ILampRepository _repository;

        public GetDoorByIdQuery(ILampRepository repository)
        {
            _repository = repository;
        }

        public DoorDto Execute(Guid id)
        {
            var l = _repository.GetById(id);
            if (l != null)
            {
                return DoorMapper.ToDto(l);
            }
            return null;
        }
    }
}
