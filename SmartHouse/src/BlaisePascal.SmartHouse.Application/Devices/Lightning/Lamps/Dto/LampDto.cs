using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Dto
{
    //public record LampDto(Guid Id, string Name, string Status, int Brightness, DateTime CreatedAtUtc, DateTime LastModifiedAtUtc);

    public class LampDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int Brightness { get; set; }
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
