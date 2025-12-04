using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.CCTVDevice
{
    public class Recording
    {
        public Recording(string name, double zoom, int tilt, TimeSpan length) 
        {

        }
        public string name;
        public double zoom;
        public int tilt;
        public TimeSpan length;
    }
}
