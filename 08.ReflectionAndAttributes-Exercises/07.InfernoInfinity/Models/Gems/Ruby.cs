namespace InfernoInfinity.Models.Gems
{
    public class Ruby : Gem
    {
        private const int DefaultStrength = 7;
        private const int DefaultAgility = 2;
        private const int DefaultVitality = 5;

        public Ruby(string clarity) 
            : base(clarity)
        {
            this.Strength = DefaultStrength;
            this.Agility = DefaultAgility;
            this.Vitality = DefaultVitality;
            this.AddClarityBonus();
        }
    }
}