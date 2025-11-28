using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.CCTVDevice
{
    public class CCTV:AbstractDevice
    {
<<<<<<< HEAD
        public CCTV(string name) : base(name) { }
        public CCTV(Guid guid, string name) : base(guid, name) { }
=======
        public CCTV(string name): base(name) { }
        public CCTV(Guid guid, string name):base(guid, name) { }
>>>>>>> e894e9f095fd5368ddce186ba0f0abf0a6df1aa4

        public int minimumTiltDegrees = -90;
        public int maximumTiltDegrees = 90;
        public double maximumZoom = 5.0;
        public int currentTilt = 0;
        public double currentZoom = 1.0;

        
    }
}
