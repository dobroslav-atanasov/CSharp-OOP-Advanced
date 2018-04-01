namespace InfernoInfinity.Models.Gems
{
    public class Amethyst : Gem
    {
        private const int DefaultStrength = 2;
        private const int DefaultAgility = 8;
        private const int DefaultVitality = 4;

        public Amethyst(string clarity) 
            : base(clarity)
        {
            this.Strength = DefaultStrength;
            this.Agility = DefaultAgility;
            this.Vitality = DefaultVitality;
            this.AddClarityBonus();
        }
    }
}