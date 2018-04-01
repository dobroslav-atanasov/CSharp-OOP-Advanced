namespace InfernoInfinity.Models.Weapons
{
    using Contracts;

    public class Axe : Weapon
    {
        private const int DefaultMinDamage = 5;
        private const int DefaultMaxDamage = 10;
        private const int NumberOfSockets = 4;

        public Axe(string name, string rarity) 
            : base(name, rarity)
        {
            this.MinDamage = DefaultMinDamage;
            this.MaxDamage = DefaultMaxDamage;
            this.Sockets = new IGem[NumberOfSockets];
            this.AddRarityBonus();
        }
    }
}