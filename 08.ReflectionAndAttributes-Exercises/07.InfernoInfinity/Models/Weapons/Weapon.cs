namespace InfernoInfinity.Models.Weapons
{
    using System;
    using System.Linq;
    using Contracts;
    using Enums;

    public abstract class Weapon : IWeapon
    {
        protected Weapon(string name, string rarity)
        {
            this.Name = name;
            this.Rarity = Enum.Parse<Rarity>(rarity);
        }

        public string Name { get; protected set; }

        public int MinDamage { get; protected set; }

        public int MaxDamage { get; protected set; }

        public IGem[] Sockets { get; protected set; }

        public Rarity Rarity { get; protected set; }

        public void AddRarityBonus()
        {
            this.MinDamage *= (int)this.Rarity;
            this.MaxDamage *= (int)this.Rarity;
        }

        public void AddGem(int socketIndex, IGem gem)
        {
            if (this.SocketExist(socketIndex))
            {
                this.Sockets[socketIndex] = gem;

            }
        }

        private bool SocketExist(int socketIndex)
        {
            if (socketIndex < 0 || socketIndex > this.Sockets.Length - 1)
            {
                return false;
            }
            return true;
        }

        public void RemoveGem(int socketIndex)
        {
            if (this.SocketExist(socketIndex))
            {
                if (this.SocketExist(socketIndex) != null)
                {
                    this.Sockets[socketIndex] = null;
                }
            }
        }

        public override string ToString()
        {
            int minDamage = this.MinDamage;
            int maxDamage = this.MaxDamage;
            int strength = 0;
            int agility = 0;
            int vitality = 0;

            foreach (IGem gem in this.Sockets.Where(s => s != null))
            {
                strength += gem.Strength;
                agility += gem.Agility;
                vitality += gem.Vitality;
                minDamage += (gem.Strength * 2) + (gem.Agility * 1);
                maxDamage += (gem.Strength * 3) + (gem.Agility * 4);
            }

            return $"{this.Name}: {minDamage}-{maxDamage} Damage, +{strength} Strength, +{agility} Agility, +{vitality} Vitality";
        }
    }
}