namespace FestivalManager.Core.IO
{
    using System;
    using Contracts;

    public class Writer : IWriter
    {
        public void WriteLine(string contents)
        {
            Console.WriteLine(contents);
        }

        public void Write(string contents)
        {
            Console.Write(contents);
        }
    }
}