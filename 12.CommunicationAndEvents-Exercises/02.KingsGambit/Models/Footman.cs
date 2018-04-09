namespace KingsGambit.Models
{
    using System;
    using IO.Intefaces;

    public class Footman : Soldier
    {
        public Footman(string name, IWriter writer) 
            : base(name, writer)
        {
        }

        public override void KingIsAttacked(object sender, EventArgs args)
        {
            this.Writer.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}