namespace InfernoInfinity.Factories
{
    using System;
    using Contracts;
    using Models.Weapons;

    public class WeaponFactory
    {
        public IWeapon CreateWeapon(string type, string rarity, string name)
        {
            IWeapon weapon = null;

            switch (type)
            {
                case "Axe":
                    weapon = new Axe(name, rarity);
                    break;
                case "Knife":
                    weapon = new Knife(name, rarity);
                    break;
                case "Sword":
                    weapon = new Sword(name, rarity);
                    break;
                default:
                    throw new ArgumentException($"Invalid weapon type!");
            }

            return weapon;
        }
    }
}