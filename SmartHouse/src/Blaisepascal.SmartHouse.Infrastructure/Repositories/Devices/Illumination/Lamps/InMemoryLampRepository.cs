using BlaisePascal.SmartHouse.Domain.Abstraction;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaisepascal.SmartHouse.Infrastructure.Repositories.Devices.Illumination.Lamps
{
    internal class InMemoryLampRepository
    {
        private readonly List<Lamp> _lamps;

        public InMemoryLampRepository()
        {
            // Dati inseriti staticamente (Hard-coded)
            _lamps = new List<Lamp>
            {
            new Lamp(DeviceName.Create("Crazy Lamp")),
            new Lamp(DeviceName.Create("Pascal Lamp")),
            new Lamp(DeviceName.Create("Pulgs Lamp"))
            };
        }

        public List<Lamp> GetAll()
        {
            return _lamps;
        }

        public Lamp GetById(Guid id)
        {
            foreach (var l in _lamps)
            {
                if (l.id == id)
                {
                    return l;
                }
            }
            return null; 
        }

        public void Add(Lamp lamp)
        {
            if (lamp == null)
                throw new ArgumentNullException(nameof(lamp));

            _lamps.Add(lamp);
        }

        public void Remove(Guid id)
        {
            var lamp = GetById(id);

            if (lamp != null)
                _lamps.Remove(lamp);
        }

        public void Update(Lamp lamp)
        {
            // not to do
        }
    }
}
