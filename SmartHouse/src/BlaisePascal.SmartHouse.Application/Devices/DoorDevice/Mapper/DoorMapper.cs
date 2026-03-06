using BlaisePascal.SmartHouse.Application.Devices.DoorDevice.Dto;
using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Dto;
using BlaisePascal.SmartHouse.Application.Devices.Mapper;
using BlaisePascal.SmartHouse.Domain.Abstraction;
using BlaisePascal.SmartHouse.Domain.DoorDevice;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevice.Mapper
{
    public class DoorMapper
    {


        public static DoorDto ToDto(Door door)
        {
            return new DoorDto
            {
                Id = door.Id,
                Name = door.Name.Value,
                Pin = door.Pin.Value,
                Status = DeviceStatusMapper.ToDto(door.Status),
                DoorStatus = DoorStatusMapper.ToDto(door.DoorStatus),
                LockStatus = LockStatusMapper.ToDto(door.LockStatus),
                CreatedAtUtc = door.CreatedAtUtc,
                LastModifiedAtUtc = door.LastModifiedAtUtc,
            };
        }

        public static Door ToDomain(DoorDto dto)
        {
            return new Door(
                dto.Id,
                DeviceName.Create(dto.Name),
                Pin.Create(dto.Pin),
                DeviceStatusMapper.ToDomain(dto.Status),
                DoorStatusMapper.ToDomain(dto.DoorStatus),
                LockStatusMapper.ToDomain(dto.LockStatus),  
                dto.CreatedAtUtc,
                dto.LastModifiedAtUtc
                );
        }
    }

}
