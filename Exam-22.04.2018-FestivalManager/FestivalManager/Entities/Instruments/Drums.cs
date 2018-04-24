namespace FestivalManager.Entities.Instruments
{
    public class Drums : Instrument
    {
        private const int DefaultRepairAmount = 20;

        public Drums()
        {
            this.RepairAmount = DefaultRepairAmount;
        }

        protected override int RepairAmount { get; }
    }
}