namespace FestivalManager.Entities.Instruments
{
    public class Guitar : Instrument
    {
        private const int DefaultRepairAmount = 60;

        public Guitar()
        {
            this.RepairAmount = DefaultRepairAmount;
        }

        protected override int RepairAmount { get; }
    }
}