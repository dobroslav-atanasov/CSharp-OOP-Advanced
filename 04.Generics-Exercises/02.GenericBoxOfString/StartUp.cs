using System;

public class StartUp
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        for (int i = 0; i < number; i++)
        {
            string input = Console.ReadLine();
            Box<string> box = new Box<string>(input);
            Console.WriteLine(box);
        }
    }
}