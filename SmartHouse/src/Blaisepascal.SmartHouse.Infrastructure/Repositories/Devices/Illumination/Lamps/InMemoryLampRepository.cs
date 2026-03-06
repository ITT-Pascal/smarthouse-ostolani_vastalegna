using BlaisePascal.SmartHouse.Domain.Abstraction;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaisepascal.SmartHouse.Infrastructure.Repositories.Devices.Illumination.Lamps
{
    public class InMemoryLampRepository: ILampRepository
    {
        private readonly List<Lamp> _lamps;

        public InMemoryLampRepository()
        {
            // Dati inseriti staticamente
            _lamps = new List<Lamp>
            {
            new Lamp(DeviceName.Create("Pesto Lamp")),
            new Lamp(DeviceName.Create("Pelo Lamp")),
            new Lamp(DeviceName.Create("Pulga Lamp"))
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
                if (l.Id == id)
                {
                    return l;
                }
            }
            return null; 
        }

        public void Add(Lamp lamp)
        {
            if (lamp != null)
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
