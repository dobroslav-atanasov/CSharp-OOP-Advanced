namespace WorkForce.IO
{
    using System;
    using Interfaces;

    public class ConsoleWriteLine : IWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}