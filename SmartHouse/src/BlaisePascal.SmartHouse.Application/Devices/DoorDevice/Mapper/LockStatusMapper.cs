using BlaisePascal.SmartHouse.Domain.DoorDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevice.Mapper
{
    public class LockStatusMapper
    {
        public static string ToDto(LockStatus status)
        {
            return status switch
            {
                LockStatus.Locked => "LOCKED",
                LockStatus.Unlocked => "UNLOCKED",
                _ => "UNKNOWN",
            };
        }

        public static LockStatus ToDomain(string status)
        {
            return status switch
            {
                "LOCKED" => LockStatus.Locked,
                "UNLOCKED" => LockStatus.Unlocked,
                "UNKNOWN" => LockStatus.Unknown,
                _ => throw new ArgumentException("non valid status")
            };
        }
    }
}
