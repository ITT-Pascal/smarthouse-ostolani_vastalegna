using Blaisepascal.SmartHouse.Infrastructure.Repositories.Devices.Illumination.Lamps;
using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Commands;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice;

class Program
{
    static void Main()
    {
        //Inizializziamo il repo e il controller
        var lampRepository = new InMemoryLampRepository();
        var lampController = new LampController(lampRepository);

        while (true)
        {
            Console.WriteLine("\n=== SMART HOUSE - LAMP MANAGER ===");
            Console.WriteLine("1. Add lamp");
            Console.WriteLine("2. Remove lamp");
            Console.WriteLine("3. Show all lamps");
            Console.WriteLine("4. Switch on");
            Console.WriteLine("5. Switch off");
            Console.WriteLine("6. Set brightness");
            Console.WriteLine("7. Brighten");
            Console.WriteLine("8. Dimmer");
            Console.WriteLine("0. Exit");
            Console.Write("\nScelta: ");

            var scelta = Console.ReadLine();

            Console.WriteLine();

            switch (scelta)
            {
                case "1": lampController.AddLamp(); break;
                case "2": lampController.RemoveLamp(); break;
                case "3": lampController.ShowAllLamps(); break;
                case "4": lampController.SwitchOn(); break;
                case "5": lampController.SwitchOff(); break;
                case "6": lampController.ChangeBrightness(); break;
                case "7": lampController.Brighten(); break;
                case "8": lampController.Dimmer(); break;
                case "0": return;
                default: Console.WriteLine("Scelta non valida."); break;
            }
        }
    }
}