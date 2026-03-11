using BlaisePascal.SmartHouse.Application.Devices.DoorDevice.Commands;
using BlaisePascal.SmartHouse.Application.Devices.DoorDevice.Dto;
using BlaisePascal.SmartHouse.Application.Devices.DoorDevice.Query;
using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Commands;
using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Dto;
using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Query;
using BlaisePascal.SmartHouse.Application.Devices.Mapper;
using BlaisePascal.SmartHouse.Domain;
using BlaisePascal.SmartHouse.Domain.Abstraction;
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

    public DoorController(IDoorRepository repository)
    {
        _repository = repository;
    }


    public void AddDoor()
    {
        Console.Write("Door name: ");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid name");
            return;
        }

        Console.Write("Pin: ");
        string inputPin = Console.ReadLine();

        if (!int.TryParse(inputPin, out int pin))
        {
            Console.WriteLine("Invalid pin");
            return;
        }

        new AddDoorCommand(_repository).Execute(name, pin);
        Console.WriteLine("Door added");
    }

    public void RemoveDoor()
    {
        var door = SelectDoor();
        if (door == null) return;

        new RemoveDoorCommand(_repository).Execute(door.Id);
        Console.WriteLine("Door removed");

    }

    public void SetPin()
    {
        var door = SelectDoor();
        if (door == null) return;
        Console.Write("Old pin: ");

        string inputOldPin = Console.ReadLine();

        if (!int.TryParse(inputOldPin, out int oldPin))
        {
            Console.WriteLine("Invalid pin");
            return;
        }

        Console.Write("New pin: ");
        string inputNewPin = Console.ReadLine();

        if (!int.TryParse(inputNewPin, out int newPin))
        {
            Console.WriteLine("Invalid pin");
            return;
        }

        try
        {
            new SetPinCommand(_repository).Execute(door.Id, oldPin, newPin);
            Console.WriteLine("Pin updated");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }

    }
    public void Open()
    {
        var door = SelectDoor();
        if (door == null) return;

        try
        {
            new OpenDoorCommand(_repository).Execute(door.Id);
            Console.WriteLine("Door is now open");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }

    }

    public void Close()
    {
        var door = SelectDoor();
        if (door == null) return;

        try
        {
            new CloseDoorCommand(_repository).Execute(door.Id);
            Console.WriteLine("Door is now closed");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }

    }


    public void Lock()
    {
        var door = SelectDoor();
        if (door == null) return;

        try
        {
            new LockDoorCommand(_repository).Execute(door.Id);
            Console.WriteLine("Door is now locked");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }

    }

    public void Unlock()
    {
        var door = SelectDoor();
        if (door == null) return;

        Console.Write("Pin: ");

        string inputPin = Console.ReadLine();

        if (!int.TryParse(inputPin, out int pin))
        {
            Console.WriteLine("Invalid pin");
            return;
        }

        try
        {
            new UnlockDoorCommand(_repository).Execute(door.Id, pin);
            Console.WriteLine("Door is now unlocked");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}");
        }

    }


    public void ShowDoors()
    {
        var doors = new GetAllDoorsQuery(_repository).Execute();

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("DOORS:");
        Console.ResetColor();

        Console.WriteLine("=====================");

        if (doors.Count == 0)
        {
            Console.WriteLine("There are no doors");
            return;
        }

        for (int i = 0; i < doors.Count; i++)
        {
            DoorDto d = doors[i];
            Console.WriteLine($"\x1b[1m{i + 1}) {d.Name}\x1b[0m\n{d}");
        }

    }

    public void ShowMenu() 
    {
        Console.WriteLine("\n=== DOOR MENU ===");
        Console.WriteLine("1. Add door");
        Console.WriteLine("2. Remove door");
        Console.WriteLine("3. Open door");
        Console.WriteLine("4. Close door");
        Console.WriteLine("5. Lock door");
        Console.WriteLine("6. Unlock door");
        Console.WriteLine("7. Set pin");
        Console.WriteLine("0. Exit");

    }

    //Private methods
    private DoorDto SelectDoor()
    {
        var doors = new GetAllDoorsQuery(_repository).Execute();

        if (doors.Count == 0)
        {
            Console.WriteLine("No doors available");
            return null;
        }

        Console.Write("Door number: ");

        int index;
        if (!int.TryParse(Console.ReadLine(), out index))
        {
            Console.WriteLine("Invalid number");
            return null;
        }

        if (index < 1 || index > doors.Count)
        {
            Console.WriteLine("Door not found");
            return null;
        }

        return doors[index - 1];
    }
}



