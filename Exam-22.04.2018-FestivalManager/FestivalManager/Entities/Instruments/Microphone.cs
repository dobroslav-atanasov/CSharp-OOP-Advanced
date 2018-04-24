namespace FestivalManager.Entities.Instruments
{
    public class Microphone : Instrument
    {
        private const int DefaultRepairAmount = 80;

        public Microphone()
        {
            this.RepairAmount = DefaultRepairAmount;
        }

        protected override int RepairAmount { get; }
    }
}