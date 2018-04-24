namespace FestivalManager.Entities.Sets
{
    using System;

    public class Long : Set
    {
        private const int MaxDurationConst = 60;

        public Long(string name)
            : base(name, new TimeSpan(0, MaxDurationConst, 0))
        {
        }
    }
}