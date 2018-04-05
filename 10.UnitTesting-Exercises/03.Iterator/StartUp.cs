namespace Iterator
{
    using System;
    using System.Linq;
    using Models;

    public class StartUp
    {
        public static void Main()
        {
            string[] array = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
            ListIterator listIterator = new ListIterator(array);

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] parts = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];
                switch (command)
                {
                    case "Move":
                        Console.WriteLine(listIterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(listIterator.HasNext());
                        break;
                    case "Print":
                        Console.WriteLine(listIterator.Print());
                        break;
                }
                input = Console.ReadLine();
            }
        }
    }
}