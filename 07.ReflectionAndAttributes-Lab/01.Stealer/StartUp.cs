using System;

public class StartUp
{
    public static void Main()
    {
        Spy spy = new Spy();
        string investigation = spy.StealFieldInfo("Hacker", "username", "password");
        Console.WriteLine(investigation);
    }
}