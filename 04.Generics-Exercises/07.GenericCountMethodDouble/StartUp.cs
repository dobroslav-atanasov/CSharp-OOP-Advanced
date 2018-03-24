using System;

public class StartUp
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        Box<double> box = new Box<double>();

        for (int i = 0; i < number; i++)
        {
            double input = double.Parse(Console.ReadLine());
            box.Add(input);
        }

        double givenItem = double.Parse(Console.ReadLine());
        int count = box.Compare(givenItem);
        Console.WriteLine(count);
    }
}