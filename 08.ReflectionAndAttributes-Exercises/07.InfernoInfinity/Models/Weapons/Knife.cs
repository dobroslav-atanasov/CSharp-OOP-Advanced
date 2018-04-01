namespace InfernoInfinity.Models.Weapons
{
    using Contracts;

    public class Knife : Weapon
    {
        private const int DefaultMinDamage = 3;
        private const int DefaultMaxDamage = 4;
        private const int NumberOfSockets = 2;

        public Knife(string name, string rarity) 
            : base(name, rarity)
        {
            this.MinDamage = DefaultMinDamage;
            this.MaxDamage = DefaultMaxDamage;
            this.Sockets = new IGem[NumberOfSockets];
            this.AddRarityBonus();
        }
    }
}