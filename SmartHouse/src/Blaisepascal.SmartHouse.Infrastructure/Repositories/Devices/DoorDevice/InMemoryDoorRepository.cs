using BlaisePascal.SmartHouse.Domain.Abstraction.ValueObject;
using BlaisePascal.SmartHouse.Domain.DoorDevice;
using BlaisePascal.SmartHouse.Domain.DoorDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaisepascal.SmartHouse.Infrastructure.Repositories.Devices.DoorDevice
{
    public class InMemoryDoorRepository : IDoorRepository
    {
        private readonly List<Door> _doors;

        public InMemoryDoorRepository()
        {
            _doors = new List<Door>
            {
                new Door(DeviceName.Create("Front Door"), Pin.Create(1234)),
            };
        }

        public List<Door> GetAll()
        {
            return _doors;
        }

        public Door GetById(Guid id)
        {
            foreach (var d in _doors)
            {
                if (d.Id == id)
                    return d;
            }
            return null;
        }

        public void Add(Door door)
        {
            if (door != null)
                _doors.Add(door);
        }

        public void Remove(Guid id)
        {
            var door = GetById(id);
            if (door != null)
                _doors.Remove(door);
        }

        public void Update(Door door)
        {
            // not to do
        }
    }

}
