namespace WorkForce.Models
{
    using Intefaces;

    public class StandartEmployee : IEmployee
    {
        private const int StandartEmployeeWeekHours = 40;

        public StandartEmployee(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public int WorkHoursPerWeek => StandartEmployeeWeekHours;
    }
}