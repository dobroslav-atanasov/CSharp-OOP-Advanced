namespace KingsGambitExtended.Models
{
    using System;
    using Interfaces;
    using IO.Intefaces;

    public abstract class Soldier : IPerson, IHitable
    {
        protected Soldier(string name, IWriter writer)
        {
            this.Name = name;
            this.Writer = writer;
        }

        public string Name { get; }

        protected IWriter Writer { get; }

        public int Hit { get; set; }

        public abstract void KingIsAttacked(object sender, EventArgs args);
    }
}