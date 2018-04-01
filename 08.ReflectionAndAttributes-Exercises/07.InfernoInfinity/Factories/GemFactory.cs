namespace InfernoInfinity.Factories
{
    using System;
    using Contracts;
    using Models.Gems;

    public class GemFactory
    {
        public IGem CreateGem(string type, string clarity)
        {
            IGem gem = null;

            switch (type)
            {
                case "Ruby":
                    gem = new Ruby(clarity);
                    break;
                case "Emerald":
                    gem = new Emerald(clarity);
                    break;
                case "Amethyst":
                    gem = new Amethyst(clarity);
                    break;
                default:
                    throw new ArgumentException("Invalid gem type!");
            }

            return gem;
        }
    }
}