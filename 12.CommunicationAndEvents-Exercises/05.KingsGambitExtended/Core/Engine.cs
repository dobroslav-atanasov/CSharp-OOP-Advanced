namespace KingsGambitExtended.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using IO;
    using IO.Intefaces;
    using Models;

    public class Engine
    {
        private IReader reader;
        private IWriter writer;
        private King king;
        private List<Soldier> soldiers;

        public Engine()
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriteLine();
            this.soldiers = new List<Soldier>();
        }

        public void Run()
        {
            this.ParseKingAndSoldiers();
            this.ExecuteCommands();
        }

        private void ExecuteCommands()
        {
            string command = this.reader.ReadLine();
            while (command != "End")
            {
                string[] commandParts = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                switch (commandParts[0])
                {
                    case "Attack":
                        this.king.OnUnderAttack();
                        break;
                    case "Kill":
                        this.KillSoldier(commandParts[1]);
                        break;
                }
                command = this.reader.ReadLine();
            }
        }

        private void KillSoldier(string name)
        {
            Soldier soldier = this.soldiers.FirstOrDefault(s => s.Name == name);
            soldier.Hit--;
            if (soldier.Hit <= 0)
            {
                this.king.BeingAttacked -= soldier.KingIsAttacked;
                this.soldiers.Remove(soldier);
            }
        }

        private void ParseKingAndSoldiers()
        {
            string kingName = this.reader.ReadLine();
            this.king = new King(kingName, this.writer);

            string[] royalGuardNames = this.reader.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string name in royalGuardNames)
            {
                RoyalGuard royalGuard = new RoyalGuard(name, this.writer);
                this.king.BeingAttacked += royalGuard.KingIsAttacked;
                this.soldiers.Add(royalGuard);
            }

            string[] footmanNames = this.reader.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string name in footmanNames)
            {
                Footman footman = new Footman(name, this.writer);
                this.king.BeingAttacked += footman.KingIsAttacked;
                this.soldiers.Add(footman);
            }
        }
    }
}