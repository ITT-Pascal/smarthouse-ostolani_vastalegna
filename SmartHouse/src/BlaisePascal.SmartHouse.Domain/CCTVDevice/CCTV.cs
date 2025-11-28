using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.CCTVDevice
{
    public class CCTV:AbstractDevice
    {
        public CCTV(string name): base(name) { }
        public CCTV(Guid guid, string name):base(guid, name) { }

        public int minimumTiltDegrees = -90;
        public int maximumTiltDegrees = 90;
        public double maximumZoom = 5.0;
        public int currentTilt = 0;
        public double currentZoom = 1.0;

        public void move(int degrees)
        {
            if ( currentTilt+ degrees > maximumTiltDegrees )
            {
                currentTilt = maximumTiltDegrees;
            } else
            {
                if (currentTilt + degrees < minimumTiltDegrees)
                {
                    currentTilt = minimumTiltDegrees;
                } else
                {
                    currentTilt += degrees;
                }
            }

        }

        public void zoom(double newZoom)
        {
            if (newZoom <= maximumZoom && newZoom >= 1)
            {
                currentZoom = newZoom;
            } else
            {
                throw new Exception("the input zoom amount is not possible on this device");
            }
        }
    }
}
