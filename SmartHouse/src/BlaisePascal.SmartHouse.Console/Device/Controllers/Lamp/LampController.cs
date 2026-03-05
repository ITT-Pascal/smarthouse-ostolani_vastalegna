using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Commands;
using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Dto;
using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Query;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice.Repository;
using System.Xml.Linq;

public class LampController
{
    private readonly ILampRepository _repository;

    public LampController(ILampRepository repos)
    {
        _repository = repos;
    }

    public void AddLamp()
    {
        Console.Write("Lamp name: ");
        string name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid string");
            return;
        }


        //try and catch per null in InMemoryLampRepository?
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

        int intensity;
        if (!int.TryParse(Console.ReadLine(), out intensity))
        {
            Console.WriteLine("Invalid value");
            return;
        }

        try
        {
            new SetBrightnessCommand(_repository).Execute(lamp.Id, intensity);
            Console.WriteLine("Intensity updated");
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

        Console.WriteLine("LAMPS:");
        Console.WriteLine("=====================");

        if (lamps.Count == 0)
        {
            Console.WriteLine("There are no lamps");
            return;
        }

        for (int i = 0; i < lamps.Count; i++)
        {
            LampDto l = lamps[i];
            Console.WriteLine($"{i + 1}) {l.Name}\n{l}");
        }
    }

    public void ShowMenu()
    {
        Console.WriteLine("\n=== LAMP MENU ===");
        Console.WriteLine("1. Add lamp");
        Console.WriteLine("2. Remove lamp");
        Console.WriteLine("3. Show all lamps");
        Console.WriteLine("4. Switch on");
        Console.WriteLine("5. Switch off");
        Console.WriteLine("6. Set brightness");
        Console.WriteLine("7. Brighten");
        Console.WriteLine("8. Dimmer");
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
        string strIndex = Console.ReadLine();

        int index;
        if (!int.TryParse(strIndex, out index))
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