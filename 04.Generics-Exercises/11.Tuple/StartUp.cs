using System;

public class StartUp
{
    public static void Main()
    {
        string[] firstInput = ParseInput();
        string[] secondInput = ParseInput();
        string[] thirdInput = ParseInput();

        Tuple<string, string> firstTuple = new Tuple<string, string>($"{firstInput[0]} {firstInput[1]}", firstInput[2]);
        Tuple<string, int> secondTuple = new Tuple<string, int>(secondInput[0], int.Parse(secondInput[1]));
        Tuple<int, double> thirdTuple = new Tuple<int, double>(int.Parse(thirdInput[0]), double.Parse(thirdInput[1]));

        Console.WriteLine(firstTuple);
        Console.WriteLine(secondTuple);
        Console.WriteLine(thirdTuple);
    }

    private static string[] ParseInput()
    {
        string[] parts = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        return parts;
    }
}