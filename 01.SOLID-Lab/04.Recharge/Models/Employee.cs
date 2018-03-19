namespace Recharge.Models
{
    using System;
    using Interfaces;

    public class Employee : Worker, ISleeper
    {
        public Employee(string id)
            : base(id)
        {
        }

        public void Sleep()
        {
            Console.WriteLine("Employee is sleeping!");
        }
    }
}