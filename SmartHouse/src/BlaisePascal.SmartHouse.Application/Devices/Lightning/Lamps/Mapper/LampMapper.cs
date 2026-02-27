using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Dto;
using BlaisePascal.SmartHouse.Application.Devices.Mapper;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Mapper
{
    public class LampMapper
    {


        public static LampDto ToDto(Lamp lamp)
        {
            return new LampDto
            {
                Id = lamp.Id,
                Name = lamp.Name.Name,
                Status = DeviceStatusMapper.ToDto(lamp.Status),
                Brightness = lamp.Brightness.Value,
                CreatedAtUtc = lamp.CreationTime,
                LastModifiedAtUtc = lamp.LastStatusChangeTime,
            };
        }

        public static Lamp ToDomain(LampDto dto)
        {
            return new Lamp(
                dto.Id,
                dto.Name,
                DeviceStatusMapper.ToDomain(dto.Status),
                Brightness.Create(dto.Brightness, 0, 100),
                dto.CreationTime,
                dto.LastUpdateTime
                );
        }
    }

}
