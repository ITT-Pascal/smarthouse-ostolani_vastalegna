using BlaisePascal.SmartHouse.Application.Devices.DoorDevice.Dto;
using BlaisePascal.SmartHouse.Application.Devices.DoorDevice.Mapper;
using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Dto;
using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Mapper;
using BlaisePascal.SmartHouse.Domain.DoorDevice.Repository;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevice.Query
{
    public class GetAllDoorsQuery
    {
        private readonly IDoorRepository _repository;

        public GetAllDoorsQuery(IDoorRepository repository)
        {
            _repository = repository;
        }

        public List<DoorDto> Execute()
        {
            var result = new List<DoorDto>();

            foreach (var d in _repository.GetAll())
            {
                result.Add(DoorMapper.ToDto(d));
            }

            return result;
        }
    }
}
