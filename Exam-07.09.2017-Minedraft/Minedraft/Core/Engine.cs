using System;
using System.Collections.Generic;
using System.Linq;

public class Engine : IEngine
{
    private const string EndCommand = "Shutdown";
    
    private IReader reader;
    private IWriter writer;
    private ICommandInterpreter commandInterpreter;

    public Engine(IReader reader, IWriter writer, ICommandInterpreter commandInterpreter)
    {
        this.reader = reader;
        this.writer = writer;
        this.commandInterpreter = commandInterpreter;
    }

    public void Run()
    {
        while (true)
        {
            IList<string> args = this.reader.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();

            string meessage = this.commandInterpreter.ProcessCommand(args);

            this.writer.WriteLine(meessage);

            if (args[0] == EndCommand)
            {
                return;
            }
        }
    }
}
