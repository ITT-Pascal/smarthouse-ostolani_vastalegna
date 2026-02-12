using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.CCTVDevice
{
    public class Photo
    {
        public string Name;
        public double Zoom;
        public int Tilt;
        public DateTime DateTaken;
        public Photo(string name, double zoom, int tilt, DateTime dateTaken)
        {
            Name = name;
            Zoom = zoom;
            Tilt = tilt;
            DateTaken = dateTaken;
        }
    }
}
