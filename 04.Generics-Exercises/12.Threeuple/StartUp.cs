using System;

public class StartUp
{
    public static void Main()
    {
        string[] firstParts = ParseInput();
        string[] secondParts = ParseInput();
        string[] thirdParts = ParseInput();

        Threeuple<string, string, string> firstThreeuple = new Threeuple<string, string, string>($"{firstParts[0]} {firstParts[1]}", firstParts[2], firstParts[3]);
        Threeuple<string, int, bool> secondThreeuple = new Threeuple<string, int, bool>(secondParts[0], int.Parse(secondParts[1]), secondParts[2] == "drunk" ? true : false);
        Threeuple<string, double, string> thirdThreeuple = new Threeuple<string, double, string>(thirdParts[0], double.Parse(thirdParts[1]), thirdParts[2]);

        Console.WriteLine(firstThreeuple);
        Console.WriteLine(secondThreeuple);
        Console.WriteLine(thirdThreeuple);
    }

    private static string[] ParseInput()
    {
        string[] parts = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        return parts;
    }
}