namespace BarracksFactory
{
    using Contracts;
    using Core;
    using Core.Factories;
    using Data;

    public class StartUp
    {
        public static void Main()
        {
            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            IRunnable engine = new Engine(repository, unitFactory);
            engine.Run();
        }
    }
}