using System;

[SoftUni("Pesho")]
public class StartUp
{
    [SoftUni("Ivan")]
    public static void Main()
    {
        Tracker tracker = new Tracker();
        tracker.PrintMethodsByAuthor();
    }

    [SoftUni("Pesho")]
    public void CreateObject()
    {
    }

    [SoftUni("Gosho")]
    public void GetMethod()
    {
    }
}