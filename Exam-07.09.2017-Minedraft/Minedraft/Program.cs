public class Program
{
    public static void Main(string[] args)
    {
        IReader reader = new Reader();
        IWriter writer = new Writer();

        IHarvesterFactory harvesterFactory = new HarvesterFactory();

        IEnergyRepository energyRepository = new EnergyRepository();
        IProviderController providerController = new ProviderController(energyRepository);
        IHarvesterController harvesterController = new HarvesterController(energyRepository, harvesterFactory);

        ICommandInterpreter commandInterpreter = new CommandInterpreter(providerController, harvesterController);

        Engine engine = new Engine(reader, writer, commandInterpreter);
        engine.Run();
    }
}