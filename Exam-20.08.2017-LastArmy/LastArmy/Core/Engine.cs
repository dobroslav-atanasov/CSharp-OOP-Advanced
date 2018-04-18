using System;

public class Engine : IEngine
{
    private IReader reader;
    private IWriter writer;
    private IGameController gameController;

    public Engine(IReader reader, IWriter writer, IGameController gameController)
    {
        this.reader = reader;
        this.writer = writer;
        this.gameController = gameController;
    }

    public void Run()
    {
        string input = this.reader.ReadLine();

        while (input != OutputMessages.EndCommand)
        {
            try
            {
                this.gameController.ParseCommand(input);
            }
            catch (ArgumentException ae)
            {
                this.writer.WriteLine(ae.Message);
            }

            input = this.reader.ReadLine();
        }

        this.gameController.PrintSummary();
    }
}