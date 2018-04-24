namespace FestivalManager
{
    using Core;
    using Core.Contracts;
    using Core.Controllers;
    using Core.Controllers.Contracts;
    using Core.IO;
    using Core.IO.Contracts;
    using Entities;
    using Entities.Contracts;
    using Entities.Factories;
    using Entities.Factories.Contracts;

    public static class StartUp
    {
        public static void Main()
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();

            ISetFactory setFactory = new SetFactory();
            IInstrumentFactory instrumentFactory = new InstrumentFactory();
            IPerformerFactory performerFactory = new PerformerFactory();
            ISongFactory songFactory = new SongFactory();

            IStage stage = new Stage();
            ISetController setController = new SetController(stage);
            IFestivalController festivalController =
                new FestivalController(stage, setFactory, instrumentFactory, performerFactory, songFactory);

            IEngine engine = new Engine(reader, writer, setController, festivalController);
            engine.Run();
        }
    }
}