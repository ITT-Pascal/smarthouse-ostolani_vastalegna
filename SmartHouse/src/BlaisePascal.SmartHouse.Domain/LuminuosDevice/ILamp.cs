using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.LuminuosDevice
{
    public interface ILamp
    {
        void Dimmer();
        void Brighten();
        void SetBrightness(int newBrightness);
    }
}
