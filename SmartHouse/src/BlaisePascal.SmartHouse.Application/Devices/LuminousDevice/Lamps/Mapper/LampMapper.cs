using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Dto;
using BlaisePascal.SmartHouse.Application.Devices.Mapper;
using BlaisePascal.SmartHouse.Domain.Abstraction;
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
            //guid e datetime non vanno convertite in stringa?
            return new LampDto
            {
                Id = lamp.Id,
                Name = lamp.Name.Value,
                Status = DeviceStatusMapper.ToDto(lamp.Status),
                Brightness = lamp.Brightness.Value,
                CreatedAtUtc = lamp.CreatedAtUtc,
                LastModifiedAtUtc = lamp.LastModifiedAtUtc,
            };
        }

        public static Lamp ToDomain(LampDto dto)
        {
            return new Lamp(
                dto.Id,
                DeviceName.Create(dto.Name),
                DeviceStatusMapper.ToDomain(dto.Status),
                Brightness.Create(dto.Brightness),
                dto.CreatedAtUtc,
                dto.LastModifiedAtUtc
                );
        }
    }

}
