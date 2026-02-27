using BlaisePascal.SmartHouse.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlaisePascal.SmartHouse.Application.Devices.Mapper
{
    public class DeviceStatusMapper
    {
        public static string ToDto(DeviceStatus status)
        {
            return status switch
            {
                DeviceStatus.On => "ON",
                DeviceStatus.Off => "OFF",
                DeviceStatus.Standby => "STANDBY",
                DeviceStatus.Error => "ERROR",
                _ => "UNKNOWN",
            };
        }

        public static DeviceStatus ToDomain(string status)
        {
            return status switch
            {
                "ON" => DeviceStatus.On,
                "OFF" => DeviceStatus.Off,
                "STANDBY" => DeviceStatus.Standby,
                "ERROR" => DeviceStatus.Error,
                "UNKNOWN" => DeviceStatus.Unknown,
                _ => throw new ArgumentException("non valid status")
            };
        }
    }
}
