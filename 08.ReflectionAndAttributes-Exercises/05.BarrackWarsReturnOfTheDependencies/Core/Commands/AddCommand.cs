namespace BarracksFactory.Core.Commands
{
    using Attributes;
    using Contracts;

    public class AddCommand : Command
    {
        [Inject]
        private IRepository repository;
        [Inject]
        private IUnitFactory unitFactory;

        public AddCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            IUnit unit = this.unitFactory.CreateUnit(unitType);
            this.repository.AddUnit(unit);
            string output = $"{unitType} added!";
            return output;
        }
    }
}