using System;

public class StartUp
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        Box<int> firstBox = new Box<int>(number);
        Console.WriteLine(firstBox);

        string text = Console.ReadLine();
        Box<string> secondBox = new Box<string>(text);
        Console.WriteLine(secondBox);

        bool boolean = bool.Parse(Console.ReadLine());
        Box<bool> thirdBox = new Box<bool>(boolean);
        Console.WriteLine(thirdBox);
    }
}