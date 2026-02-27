using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Dto;
using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Mapper;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Query
{
    public class GetAllLampsQuery
    {
        private readonly ILampRepository _repository;

        public GetAllLampsQuery(ILampRepository repository)
        {
            _repository = repository;
        }

        public List<LampDto> Execute()
        {
            var result = new List<LampDto>();

            foreach (var l in _repository.GetAll())
            {
                result.Add(LampMapper.ToDto(l));
            }

            return result;
        }
    }
}
