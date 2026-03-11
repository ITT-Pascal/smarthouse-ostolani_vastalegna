using BlaisePascal.SmartHouse.Domain.CCTVDevice;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.Application.Devices.CCTVDevice.Dto
{
    internal class CCTVDto
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CCTVStatus { get; set; }
        public int CurrentZoom { get; set; }
        public int CurrentTilt { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime LastModifiedAtUtc { get; set; }


        public override string ToString()
        {
            return $"Id: {Id}\n" +
                   $"Name: {Name}\n" +
                   $"Status: {CCTVStatus}\n" +
                   $"Zoom: {CurrentZoom}\n" +
                   $"Tilt: {CurrentTilt}\n" +
                   $"Created: {CreatedAtUtc}\n" +
                   $"Last update: {LastModifiedAtUtc}\n";
        }
    }
}
