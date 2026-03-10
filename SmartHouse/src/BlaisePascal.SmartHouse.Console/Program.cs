using Blaisepascal.SmartHouse.Infrastructure.Repositories.Devices.DoorDevice;
using Blaisepascal.SmartHouse.Infrastructure.Repositories.Devices.Illumination.Lamps;
using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Commands;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice;

class Program
{
    static InMemoryLampRepository lampRepository = new InMemoryLampRepository();
    static InMemoryDoorRepository doorRepository = new InMemoryDoorRepository();
    static LampController lampController = new LampController(lampRepository);
    static DoorController doorController = new DoorController(doorRepository);

    static void Main()
    {
        //improvable with a dictionary

        while (true)
        {
            Console.Clear();
            Console.Write("\x1b[3J");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("### SMART HOUSE ###");
            Console.ResetColor();
            Console.WriteLine();
            lampController.ShowLamps();
            doorController.ShowDoors();
            Console.WriteLine("Scegli quali dispositivi gestire:");
            Console.WriteLine("1. Lamps");
            Console.WriteLine("2. Doors");
            Console.WriteLine("0. Exit");
            Console.Write("\nScelta: ");

            switch (Console.ReadLine())
            {
                case "1": LampLoop(); break;
                case "2": DoorLoop(); break;
                case "0": return;
                default: Console.WriteLine("Scelta non valida."); break;
            }
        }
    }

    static void LampLoop()
    {
        while (true)
        {
            Console.Clear();
            Console.Write("\x1b[3J");
            lampController.ShowLamps();
            lampController.ShowMenu();
            Console.Write("\nScelta: ");
            switch (Console.ReadLine())
            {
                case "1": lampController.AddLamp(); break;
                case "2": lampController.RemoveLamp(); break;
                case "3": lampController.SwitchOn(); break;
                case "4": lampController.SwitchOff(); break;
                case "5": lampController.ChangeBrightness(); break;
                case "6": lampController.Brighten(); break;
                case "7": lampController.Dimmer(); break;
                case "0": return;
                default: Console.WriteLine("Scelta non valida."); break;
            }
            Pause();
        }
    }

    static void DoorLoop()
    {
        while (true)
        {
            Console.Clear();
            Console.Write("\x1b[3J");
            doorController.ShowMenu();
            Console.Write("\nScelta: ");
            switch (Console.ReadLine())
            {
                case "1": doorController.AddDoor(); break;
                case "2": doorController.RemoveDoor(); break;
                case "3": doorController.Open(); break;
                case "4": doorController.Close(); break;
                case "5": doorController.Lock(); break;
                case "6": doorController.Unlock(); break;
                case "7": doorController.SetPin(); break;
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