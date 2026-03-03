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
        IsNullOrWhiteSpaceValidator(name);
        new AddLampCommand(_repository).Execute(name);
        Console.WriteLine("Lamp added");
    }

    public void RemoveLamp()
    {
        Console.Write("Lamp Id: ");
        string id = Console.ReadLine();
        IsNullOrWhiteSpaceValidator(id);
        new RemoveLampCommand(_repository).Execute(new Guid(id));
        Console.WriteLine("Lamp removed");
    }
    public void Dimmer()
    {
        Console.Write("Lamp Id: ");
        string id = Console.ReadLine();
        IsNullOrWhiteSpaceValidator(id);
        new DimmerCommand(_repository).Execute(new Guid(id));
        Console.WriteLine("Decreased lamp brightness!");
    }

    public void Brighten()
    {
        Console.Write("Lamp Id: ");
        string id = Console.ReadLine();
        IsNullOrWhiteSpaceValidator(id);
        new BrightenCommand(_repository).Execute(new Guid(id));
        Console.WriteLine("Increased lamp brightness!");
    }

    public void ChangeBrightness()
    {
        Console.Write("Lamp Id: ");
        string id = Console.ReadLine();
        IsNullOrWhiteSpaceValidator(id);

        Console.Write("New brightness: ");
        string newbrightness = Console.ReadLine();
        IsNullOrWhiteSpaceValidator(newbrightness);

        new SetBrightnessCommand(_repository).Execute(new Guid(id), int.Parse(newbrightness));
        Console.WriteLine("Setted new lamp brightness");
    }



    public void SwitchOn()
    {
        Console.Write("Lamp Id: ");
        string id = Console.ReadLine();
        IsNullOrWhiteSpaceValidator(id);

        new SwitchOnCommand(_repository).Execute(new Guid(id));
        Console.WriteLine("Lamp is now on");
    }

    public void SwitchOff()
    {
        Console.Write("Lamp Id: ");
        string id = Console.ReadLine();

        IsNullOrWhiteSpaceValidator(id);

        new SwitchOffCommand(_repository).Execute(new Guid(id));
        Console.WriteLine("Turned lamp off!");
    }

    public void ShowAllLamps()
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
            Console.WriteLine($"{i + 1}) {l.Name}\n{l.ToString}");
        }
    }

    public void IsNullOrWhiteSpaceValidator(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            Console.WriteLine("Invalid string");
            return;
        }
    }


}