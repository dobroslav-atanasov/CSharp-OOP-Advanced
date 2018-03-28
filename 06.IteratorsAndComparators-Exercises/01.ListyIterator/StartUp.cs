using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        ListyIterator<string> listyIterator = new ListyIterator<string>();
        string[] parts = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        listyIterator.Create(parts.Skip(1).ToArray());

        string command = Console.ReadLine();
        while (command != "END")
        {
            switch (command)
            {
                case "Move":
                    Console.WriteLine(listyIterator.Move());
                    break;
                case "HasNext":
                    Console.WriteLine(listyIterator.HasNext());
                    break;
                case "Print":
                    listyIterator.Print();
                    break;
            }
            command = Console.ReadLine();
        }
    }
}