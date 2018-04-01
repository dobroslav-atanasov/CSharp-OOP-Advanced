namespace BarracksFactory.Core
{
    using System;
    using Commands;
    using Contracts;

    public class CommandIntrepreter : ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandIntrepreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            switch (commandName)
            {
                case "add":
                    return new AddCommand(data, this.repository, this.unitFactory);
                case "report":
                    return new ReportCommand(data, this.repository, this.unitFactory);
                case "fight":
                    return new FightCommand(data, this.repository, this.unitFactory);
                case "retire":
                    return new RetireCommand(data, this.repository, this.unitFactory);
                default:
                    throw new InvalidOperationException("Invalid command!");
            }
        }
    }
}