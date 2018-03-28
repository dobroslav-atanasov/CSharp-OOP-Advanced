using System;
using System.Linq;

public class Engine
{
    private readonly ClinicController clinicController;
        
    public Engine()
    {
        this.clinicController = new ClinicController();
    }

    public void Run()
    {
        int numberOfCommands = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfCommands; i++)
        {
            string[] parts = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string command = parts[0];

            try
            {
                switch (command)
                {
                    case "Create":
                        this.CreateCommand(parts);
                        break;
                    case "Add":
                        Console.WriteLine(this.clinicController.Add(parts[1], parts[2]));
                        break;
                    case "Release":
                        Console.WriteLine(this.clinicController.Release(parts[1]));
                        break;
                    case "HasEmptyRooms":
                        Console.WriteLine(this.clinicController.HasEmptyRooms(parts[1]));
                        break;
                    case "Print":
                        this.PrintCommand(parts);
                        break;
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }

    private void PrintCommand(string[] parts)
    {
        if (parts.Length == 2)
        {
            this.clinicController.Print(parts[1]);
        }
        else if (parts.Length == 3)
        {
            this.clinicController.Print(parts[1], int.Parse(parts[2]));
        }
    }

    private void CreateCommand(string[] parts)
    {
        string type = parts[1];
        switch (type)
        {
            case "Pet":
                this.clinicController.CreatePet(parts.Skip(2).ToArray());
                break;
            case "Clinic":
                this.clinicController.CreateClinic(parts.Skip(2).ToArray());
                break;
        }
    }
}