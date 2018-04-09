namespace KingsGambit.Models
{
    using System;
    using Interfaces;
    using IO.Intefaces;

    public class RoyalGuard : Soldier
    {
        public RoyalGuard(string name, IWriter writer) 
            : base(name, writer)
        {
        }

        public override void KingIsAttacked(object sender, EventArgs args)
        {
            this.Writer.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}