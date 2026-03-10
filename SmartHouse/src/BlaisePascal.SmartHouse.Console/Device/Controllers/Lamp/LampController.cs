using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Commands;
using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Dto;
using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Query;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice.Repository;
using System.Xml.Linq;

public class LampController
{
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
            return;
        }

        new AddLampCommand(_repository).Execute(name);
        Console.WriteLine("Lamp added");
    }

    public void RemoveLamp()
    {
        var lamp = SelectLamp();
        if (lamp == null) return;

        //No exception
        new RemoveLampCommand(_repository).Execute(lamp.Id);
        Console.WriteLine("Lamp removed");
    }
    public void Dimmer()
    {
        var lamp = SelectLamp();
        if (lamp == null) return;
        try
        {
            new DimmerCommand(_repository).Execute(lamp.Id);
            Console.WriteLine("Decreased lamp brightness");
        }
        catch (InvalidOperationException ex)
        {
            // Errore di dominio (lamp spenta)
            Console.WriteLine($"ERROR: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Errore generico
            Console.WriteLine($"ERROR: {ex.Message}");
        }


    }

    public void Brighten()
    {
        var lamp = SelectLamp();
        if (lamp == null) return;
        try
        {
            new BrightenCommand(_repository).Execute(lamp.Id);
            Console.WriteLine("Increased lamp brightness!");
        }
        catch (InvalidOperationException ex)
        {
            // Errore di dominio (lamp spenta)
            Console.WriteLine($"ERROR: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Errore generico
            Console.WriteLine($"ERROR: {ex.Message}");
        }
        
    }

    public void ChangeBrightness()
    {
        var lamp = SelectLamp();
        if (lamp == null) return;

        Console.Write("New brightness (0-100): ");

        int brightness;
        if (!int.TryParse(Console.ReadLine(), out brightness))
        {
            Console.WriteLine("Invalid value");
            return;
        }

        try
        {
            new SetBrightnessCommand(_repository).Execute(lamp.Id, brightness);
            Console.WriteLine("Brightness updated");
        }
        catch (InvalidOperationException ex)
        {
            // Errore di dominio (lamp spenta)
            Console.WriteLine($"ERROR: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Errore generico
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }


    public void SwitchOn()
    {
        var lamp = SelectLamp();
        if (lamp == null) return;
        try
        {
            new SwitchOnCommand(_repository).Execute(lamp.Id);
            Console.WriteLine("Lamp is now on");
        }
        catch (InvalidOperationException ex)
        {
            // Errore di dominio (lamp già accesa)
            Console.WriteLine($"ERROR: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Errore generico
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void SwitchOff()
    {
        var lamp = SelectLamp();
        if (lamp == null) return;
        try
        {
            new SwitchOffCommand(_repository).Execute(lamp.Id);
            Console.WriteLine("Turned lamp off!");
        }
        catch (InvalidOperationException ex)
        {
            // Errore di dominio (lamp già spenta)
            Console.WriteLine($"ERROR: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Errore generico
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void ShowLamps()
    {
        var lamps = new GetAllLampsQuery(_repository).Execute();

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("LAMPS:");
        Console.ResetColor();
        Console.WriteLine("=====================");

        if (lamps.Count == 0)
        {
            Console.WriteLine("There are no lamps");
            return;
        }

        for (int i = 0; i < lamps.Count; i++)
        {
            LampDto l = lamps[i];
            Console.WriteLine($"\x1b[1m{i + 1}) {l.Name}\x1b[0m\n{l}");
        }
    }

    public void ShowMenu()
    {
        Console.WriteLine("\n=== LAMP MENU ===");
        Console.WriteLine("1. Add lamp");
        Console.WriteLine("2. Remove lamp");
        Console.WriteLine("3. Switch on");
        Console.WriteLine("4. Switch off");
        Console.WriteLine("5. Set brightness");
        Console.WriteLine("6. Brighten");
        Console.WriteLine("7. Dimmer");
        Console.WriteLine("0. Exit");
    }

    // PRIVATE METHODS
    private LampDto SelectLamp()
    {
        var lamps = new GetAllLampsQuery(_repository).Execute();

        if (lamps.Count == 0)
        {
            Console.WriteLine("No lamps available");
            return null;
        }

        Console.Write("Lamp number: ");

        int index;
        if (!int.TryParse(Console.ReadLine(), out index))
        {
            Console.WriteLine("Invalid number");
            return null;
        }

        if (index < 1 || index > lamps.Count)
        {
            Console.WriteLine("Lamp not found");
            return null;
        }

        return lamps[index - 1];
    }

}