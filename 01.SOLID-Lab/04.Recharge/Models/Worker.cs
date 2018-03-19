namespace Recharge.Models
{
    using Interfaces;

    public abstract class Worker
    {
        private string id;
        private int workingHours;

        protected Worker(string id)
        {
            this.id = id;
        }

        public virtual void Work(int hours)
        {
            this.workingHours += hours;
        }
    }
}