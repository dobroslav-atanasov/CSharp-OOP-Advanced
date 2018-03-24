using System;

public class Engine
{
    private CustomList<string> customList;

    public Engine()
    {
        this.customList = new CustomList<string>();
    }

    public void Run()
    {
        string input = Console.ReadLine();

        while (input != "END")
        {
            string[] parts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string command = parts[0];
            switch (command)
            {
                case "Add":
                    this.customList.Add(parts[1]);
                    break;
                case "Remove":
                    this.customList.Remove(int.Parse(parts[1]));
                    break;
                case "Contains":
                    Console.WriteLine(this.customList.Contains(parts[1]));
                    break;
                case "Swap":
                    this.customList.Swap(int.Parse(parts[1]), int.Parse(parts[2]));
                    break;
                case "Greater":
                    Console.WriteLine(this.customList.CountGreaterThan(parts[1]));
                    break;
                case "Max":
                    Console.WriteLine(this.customList.Max());
                    break;
                case "Min":
                    Console.WriteLine(this.customList.Min());
                    break;
                case "Sort":
                    this.customList.Sort();
                    break;
                case "Print":
                    Console.WriteLine(this.customList.Print());
                    break;
            }

            input = Console.ReadLine();
        }
    }
}