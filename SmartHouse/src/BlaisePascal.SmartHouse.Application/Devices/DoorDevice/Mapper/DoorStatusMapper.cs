using BlaisePascal.SmartHouse.Domain;
using BlaisePascal.SmartHouse.Domain.DoorDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevice.Mapper
{
    public class DoorStatusMapper
    {
        public static string ToDto(DoorStatus status)
        {
            return status switch
            {
                DoorStatus.Open => "OPEN",
                DoorStatus.Closed => "CLOSED",
                _ => "UNKNOWN",
            };
        }

        public static DoorStatus ToDomain(string status)
        {
            return status switch
            {
                "OPEN" => DoorStatus.Open,
                "CLOSED" => DoorStatus.Closed,
                "UNKNOWN" => DoorStatus.Unknown,
                _ => throw new ArgumentException("non valid status")
            };
        }
    }
}
