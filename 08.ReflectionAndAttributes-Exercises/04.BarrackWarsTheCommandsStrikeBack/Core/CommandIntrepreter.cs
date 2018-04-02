namespace BarracksFactory.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class CommandIntrepreter : ICommandInterpreter
    {
        private const string Suffix = "command";

        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandIntrepreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == commandName + Suffix);
            object[] ctorParts = new object[] { data, this.repository, this.unitFactory };
            IExecutable instance = (IExecutable) Activator.CreateInstance(type, ctorParts);
            return instance;
        }
    }
}