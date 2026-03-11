using BlaisePascal.SmartHouse.Domain.LuminuosDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Domain.DoorDevice.Repository
{
    public interface IDoorRepository
    {
        void Add(Door door);
        void Update(Door door);
        void Remove(Guid id);
        Door GetById(Guid id);
        List<Door> GetAll();
        
    }
}
