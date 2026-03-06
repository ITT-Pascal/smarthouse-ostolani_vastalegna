using BlaisePascal.SmartHouse.Application.Devices.DoorDevice.Commands;
using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Commands;
using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Dto;
using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Query;
using BlaisePascal.SmartHouse.Application.Devices.Mapper;
using BlaisePascal.SmartHouse.Domain;
using BlaisePascal.SmartHouse.Domain.DoorDevice.Repository;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DoorController
{
    

    private readonly IDoorRepository _repository;

    public DoorController(IDoorRepository repos)
    {
        _repository = repos;
    }

    public void ShowDoors()
    {
        var doors = new DoorGetAllQuery(_repository).Execute();

        Console.WriteLine("Doors:");
        Console.WriteLine("------------------------------");

        if (doors.Count == 0)
        {
            Console.WriteLine("No doors available");
            return;
        }

        for (int i = 0; i < doors.Count; i++)
        {
            var d = doors[i];
            Console.WriteLine($"{i + 1}. {d.Name}\n{d}");
        }
    }

    public void ShowMenu() { }

    public void AddDoor()
    {
        Console.Write("Door name: ");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid name");
            return;
        }

        Console.Write("New Pin: ");
        string newpin = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(newpin))
        {
            Console.WriteLine("Invalid new pin");
            return;
        }

        new AddDoorCommand(_repository).Execute(name, int.Parse(newpin));
        Console.WriteLine("Door added!");
    }

    public void RemoveLamp()
    {
        Console.Write("Door Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        new RemoveDoorCommand(_repository).Execute(new Guid(id));
        Console.WriteLine("Door removed!");
    }

    public void ChangePin()
    {
        Console.Write("Door Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        Console.Write("Current pin: ");
        string currentpin = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(currentpin))
        {
            Console.WriteLine("Invalid Pin");
            return;
        }

        Console.Write("New pin: ");
        string newpin = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(newpin))
        {
            Console.WriteLine("Invalid Pin");
            return;
        }

        new ChangePinDoorCommand(_repository).Execute(new Guid(id), int.Parse(currentpin), int.Parse(newpin));
        Console.WriteLine("Door removed!");
    }

    public void Lock()
    {
        Console.Write("Door Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        new LockDoorCommand(_repository).Execute(new Guid(id));
        Console.WriteLine("Locked Door");
    }

    public void Unlock()
    {
        Console.Write("Door Id: ");
        string id = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(id))
        {
            Console.WriteLine("Invalid Id");
            return;
        }

        Console.Write("Current Pin: ");
        string currentpin = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(currentpin))
        {
            Console.WriteLine("Invalid Pin");
            return;
        }

        new UnlockDoorCommand(_repository).Execute(new Guid(id), int.Parse(currentpin));
        Console.WriteLine("Unlocked Door");
    }

    public void Open()
    {
        Guid id = new Guid(SelectDoor());

        if (id == null)
        {
            Console.WriteLine("Cannot find selected door");
            return;
        }

        try
        {
            if (DeviceStatusMapper.ToDomain(new DoorGetByIdQuery(_repository).Execute(id).Status) == DeviceStatus.Off)
                Console.WriteLine("Door must be on!");
            else if (new DoorGetByIdQuery(_repository).Execute(id).IsLocked == true)
                Console.WriteLine("Door must be unlocked!");
            else if (new DoorGetByIdQuery(_repository).Execute(id).IsOpen == true)
                Console.WriteLine("Door is alredy open");
            else
            {
                new OpenDoorCommand(_repository).Execute(id);
                Console.WriteLine("Opened door");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    public void Close()
    {
        Guid id = new Guid(SelectDoor());

        if (id == null)
        {
            Console.WriteLine("Cannot find selected door");
            return;
        }

        try
        {
            if (DeviceStatusMapper.ToDomain(new DoorGetByIdQuery(_repository).Execute(id).Status) == DeviceStatus.Off)
                Console.WriteLine("Door must be on!");
            else if (new DoorGetByIdQuery(_repository).Execute(id).IsOpen == false)
                Console.WriteLine("Door is alredy closed");
            else
            {
                new CloseDoorCommand(_repository).Execute(id);
                Console.WriteLine("Closed door");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
    }

    private string SelectDoor()
    {
        var doors = new DoorGetAllQuery(_repository).Execute();

        if (doors.Count == 0)
        {
            Console.WriteLine("No doors available");
            return null;
        }

        Console.Write("Door number: ");
        if (!int.TryParse(Console.ReadLine(), out int num))
        {
            Console.WriteLine("Invalid number");
            return null;
        }

        if (num < 1 || num > doors.Count)
        {
            Console.WriteLine("There is no corresponding door");
            return null;
        }

        try
        {
            return doors[num - 1].Id.ToString();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
            return null;
        }
    }
}



