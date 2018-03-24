using System;

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

        string givenItem = Console.ReadLine();
        int count = box.Compare(givenItem);
        Console.WriteLine(count);
    }
}