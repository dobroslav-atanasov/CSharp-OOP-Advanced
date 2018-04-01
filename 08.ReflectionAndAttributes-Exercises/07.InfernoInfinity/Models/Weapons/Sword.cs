namespace InfernoInfinity.Models.Weapons
{
    using Contracts;

    public class Sword : Weapon
    {
        private const int DefaultMinDamage = 4;
        private const int DefaultMaxDamage = 6;
        private const int NumberOfSockets = 3;

        public Sword(string name, string rarity) 
            : base(name, rarity)
        {
            this.MinDamage = DefaultMinDamage;
            this.MaxDamage = DefaultMaxDamage;
            this.Sockets = new IGem[NumberOfSockets];
            this.AddRarityBonus();
        }
    }
}