namespace InfernoInfinity
{
    using Contracts;
    using Core;
    using IO;

    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();
            Engine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}