namespace InfernoInfinity.IO
{
    using System;
    using Contracts;

    public class Writer : IWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}