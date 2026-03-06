using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.DoorDevice.Dto
{

    public class DoorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Pin { get; set; }
        public string Status { get; set; }
        public string DoorStatus { get; set; }
        public string LockStatus { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime LastModifiedAtUtc { get; set; }


        public override string ToString()
        {
            return $"Id: {Id}\n" +
                   $"Name: {Name}\n" +
                   $"Status: {Status}\n" +
                   $"Brightness: {Brightness}\n" +
                   $"Created: {CreatedAtUtc}\n" +
                   $"Last update: {LastModifiedAtUtc}\n";
        }
    }
}
