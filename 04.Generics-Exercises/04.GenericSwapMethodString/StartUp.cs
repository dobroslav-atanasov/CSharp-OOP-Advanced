using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        Box<string> box = new Box<string>();

        for (int i = 0; i < number; i++)
        {
            string input = Console.ReadLine();
            box.Add(input);
        }

        int[] indexes = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        box.Swap(indexes[0], indexes[1]);

        Console.WriteLine(box);
    }
}