namespace KingsGambit.IO
{
    using System;
    using Intefaces;

    public class ConsoleWriteLine : IWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}