namespace WorkForce.Models
{
    using Intefaces;

    public class PartTimeEmployee : IEmployee
    {
        private const int PartTimeEmployeeWeekHours = 20;

        public PartTimeEmployee(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public int WorkHoursPerWeek => PartTimeEmployeeWeekHours;
    }
}