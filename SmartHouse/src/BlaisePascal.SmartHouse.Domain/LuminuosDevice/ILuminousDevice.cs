using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.LuminuosDevice
{
    public interface ILuminousDevice
    {
        void Dimmer(int amount);
        void Brighten(int amount);
        void SetBrightness(Brightness newBrightness);
    }
}
