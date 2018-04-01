namespace InfernoInfinity.Models.Gems
{
    using System;
    using Contracts;
    using Enums;

    public abstract class Gem : IGem
    {
        protected Gem(string clarity)
        {
            this.Clarity = Enum.Parse<Clarity>(clarity);
        }
        
        public int Strength { get; protected set; }

        public int Agility { get; protected set; }

        public int Vitality { get; protected set; }

        public Clarity Clarity { get; protected set; }

        public void AddClarityBonus()
        {
            this.Strength += (int)this.Clarity;
            this.Agility += (int)this.Clarity;
            this.Vitality += (int)this.Clarity;
        }
    }
}