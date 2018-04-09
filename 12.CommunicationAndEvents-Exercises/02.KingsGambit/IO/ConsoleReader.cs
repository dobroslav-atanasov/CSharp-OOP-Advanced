namespace KingsGambit.IO
{
    using System;
    using Intefaces;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}