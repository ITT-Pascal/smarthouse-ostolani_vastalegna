using Blaisepascal.SmartHouse.Infrastructure.Repositories.Devices.Illumination.Lamps;
using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Commands;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice;

class Program
{
    static void Main()
    {
        //Inizializziamo il repo e il controller
        InMemoryLampRepository lampRepository = new InMemoryLampRepository();
        LampController lampController = new LampController(lampRepository);

        while (true)
        {
            Console.Clear();
            Console.Write("\x1b[3J");
            lampController.ShowLamps();
            lampController.ShowMenu();
            Console.Write("\nScelta: ");
            var scelta = Console.ReadLine();
            Console.WriteLine();

            switch (scelta)
            {
                case "1": lampController.AddLamp(); break;
                case "2": lampController.RemoveLamp(); break;
                case "3": lampController.ShowLamps(); break;
                case "4": lampController.SwitchOn(); break;
                case "5": lampController.SwitchOff(); break;
                case "6": lampController.ChangeBrightness(); break;
                case "7": lampController.Brighten(); break;
                case "8": lampController.Dimmer(); break;
                case "0": return;
                default: Console.WriteLine("Scelta non valida."); break;
            }

            Pause();
        }
    }

    static void Pause()
    {
        Console.WriteLine();
        Console.WriteLine("Press ENTER to continue...");
        Console.ReadLine(); ;
    }
}