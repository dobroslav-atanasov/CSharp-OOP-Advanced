using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        CustomStack<int> customStack = new CustomStack<int>();

        string input = Console.ReadLine();
        while (input != "END")
        {
            string[] parts = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string command = parts[0];
            switch (command)
            {
                case "Push":
                    customStack.Push(parts.Skip(1).Select(int.Parse).ToArray());
                    break;
                case "Pop":
                    customStack.Pop();
                    break;
            }
            input = Console.ReadLine();
        }

        foreach (int num in customStack)
        {
            Console.WriteLine(num);
        }
    }
}