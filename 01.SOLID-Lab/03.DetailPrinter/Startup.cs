namespace DetailPrinter
{
    using System.Collections.Generic;
    using Core;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            Employee firstEmployee = new Employee("Pesho");
            Employee secondEmployee = new Employee("Ivan");
            Manager manager = new Manager("Gosho", new List<string>() {"data.txt", "preview.pptx", "salaries.xsl"});
            IList<Employee> employees = new List<Employee>() {firstEmployee, secondEmployee, manager};
            DetailsPrinter printer = new DetailsPrinter(employees);
            printer.PrintDetails();
        }
    }
}