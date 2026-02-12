using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.TemperatureDevice
{
    public interface ITemperatureDevice
    {
        void SetTemperatureToReach(int temperature);
        void IncreaseTemperatureToReach();
        void DecreaseTemperatureToReach();
    }
}
