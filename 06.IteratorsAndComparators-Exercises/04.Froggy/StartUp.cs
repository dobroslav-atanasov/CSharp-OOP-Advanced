using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int[] stones = Console.ReadLine().Split(new []{' ', ','}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        Lake lake = new Lake(stones);
        Console.WriteLine(string.Join(", ", lake));
    }
}