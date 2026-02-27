using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Commands;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Console.Device.Controllers
{
    public class LampController
    {
        static void Main
        private readonly ILampRepository _repository;

        public LampController(ILampRepository repository)
        {
            _repository = repository;
        }

        public void AddLamp()
        {
            Console.Write("Lamp name: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Invalid name");
                return; //blocca e restituisce il controllo a chi chiama
            }
            new AddLampCommand(_repository).Execute(name: name);
            Console.WriteLine("Lamp added!");
        
        }
    }
}
