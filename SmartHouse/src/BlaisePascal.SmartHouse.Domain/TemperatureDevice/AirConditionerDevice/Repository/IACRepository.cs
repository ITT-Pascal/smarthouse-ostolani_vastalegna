using BlaisePascal.SmartHouse.Domain.CCTVDevice;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.TemperatureDevice.AirConditionerDevice.Repository
{
    public interface IACRepository
    {
        void Add(AirConditioner ac);
        void Update(AirConditioner ac);
        void Remove(Guid id);
        AirConditioner GetById(Guid id);
        List<AirConditioner> GetAll();
    }
}
