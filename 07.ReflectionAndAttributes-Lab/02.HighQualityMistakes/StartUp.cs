using System;

public class StartUp
{
    public static void Main()
    {
        Spy spy = new Spy();
        string investigation = spy.AnalyzeAcessModifiers("Hacker");
        Console.WriteLine(investigation);
    }
}