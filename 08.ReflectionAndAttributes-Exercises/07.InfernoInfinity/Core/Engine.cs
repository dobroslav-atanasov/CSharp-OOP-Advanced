namespace InfernoInfinity.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Factories;

    public class Engine
    {
        private IReader reader;
        private IWriter writer;
        private WeaponFactory weaponFactory;
        private GemFactory gemFactory;
        private IDictionary<string, IWeapon> weapons;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.weaponFactory = new WeaponFactory();
            this.gemFactory = new GemFactory();
            this.weapons = new Dictionary<string, IWeapon>();
        }

        public void Run()
        {
            string input = this.reader.ReadLine();
            while (input != "END")
            {
                string[] parts = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];
                switch (command)
                {
                    case "Create":
                        this.CreateCommand(parts.Skip(1).ToArray());
                        break;
                    case "Add":
                        this.AddCommand(parts.Skip(1).ToArray());
                        break;
                    case "Remove":
                        this.RemoveCommand(parts.Skip(1).ToArray());
                        break;
                    case "Print":
                        this.PrintCommand(parts.Skip(1).ToArray());
                        break;
                }

                input = this.reader.ReadLine();
            }
        }

        private void PrintCommand(string[] parts)
        {
            string weaponName = parts[0];
            this.writer.WriteLine(this.weapons[weaponName].ToString());
        }

        private void RemoveCommand(string[] parts)
        {
            string weaponName = parts[0];
            int socketIndex = int.Parse(parts[1]);
            this.weapons[weaponName].RemoveGem(socketIndex);
        }

        private void AddCommand(string[] parts)
        {
            string weaponName = parts[0];
            int socketIndex = int.Parse(parts[1]);
            string[] getParts = parts[2].Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            string clarity = getParts[0];
            string type = getParts[1];
            IGem gem = this.gemFactory.CreateGem(type, clarity);
            this.weapons[weaponName].AddGem(socketIndex, gem);
        }

        private void CreateCommand(string[] parts)
        {
            string[] weaponParts = parts[0].Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            string rarity = weaponParts[0];
            string type = weaponParts[1];
            string name = parts[1];
            IWeapon weapon = this.weaponFactory.CreateWeapon(type, rarity, name);
            this.weapons.Add(name, weapon);
        }
    }
}