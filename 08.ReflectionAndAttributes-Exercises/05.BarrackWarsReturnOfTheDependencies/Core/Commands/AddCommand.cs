namespace BarracksFactory.Core.Commands
{
    using Attributes;
    using Contracts;

    public class AddCommand : Command
    {
        [Inject]
        private IUnitFactory unitFactory;
        [Inject]
        private IRepository repository;

        public AddCommand(string[] data) 
            : base(data)
        {
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