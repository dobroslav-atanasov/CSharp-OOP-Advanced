using System;

public class StartUp
{
    public static void Main()
    {
        Scale<int> scale = new Scale<int>(5, 6);
        Console.WriteLine(scale.GetHeavier());

        Scale<string> stringScale = new Scale<string>("Str", "Str");
        Console.WriteLine(stringScale.GetHeavier());
    }
}