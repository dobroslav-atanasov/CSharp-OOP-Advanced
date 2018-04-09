namespace WorkForce.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using IO;
    using IO.Interfaces;
    using Models;
    using Models.Intefaces;

    public class Engine
    {
        private IReader reader;
        private IWriter writer;
        private JobList jobs;
        private IList<IEmployee> employees;

        public Engine()
        {
            this.reader = new ConsoleReadLine();
            this.writer = new ConsoleWriteLine();
            this.jobs = new JobList();
            this.employees = new List<IEmployee>();
        }

        public void Run()
        {
            this.ExecuteCommands();
        }

        private void ExecuteCommands()
        {
            string input = this.reader.ReadLine();
            while (input != "End")
            {
                string[] parts = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0];
                switch (command)
                {
                    case "Job":
                        this.JobCommand(parts);
                        break;
                    case "StandardEmployee":
                        this.StandartEmployeeCommand(parts);
                        break;
                    case "PartTimeEmployee":
                        this.PartTimeEmployeeCommand(parts);
                        break;
                    case "Pass":
                        this.PassCommand();
                        break;
                    case "Status":
                        this.StatusCommand();
                        break;
                }
                input = this.reader.ReadLine();
            }
        }

        private void StatusCommand()
        {
            foreach (Job job in this.jobs)
            {
                this.writer.WriteLine(job.ToString());
            }
        }

        private void PassCommand()
        {
            foreach (Job job in this.jobs.ToArray())
            {
                job.Update();
            }
        }

        private void PartTimeEmployeeCommand(string[] parts)
        {
            PartTimeEmployee partTimeEmployee = new PartTimeEmployee(parts[1]);
            this.employees.Add(partTimeEmployee);
        }

        private void StandartEmployeeCommand(string[] parts)
        {
            StandartEmployee standartEmployee = new StandartEmployee(parts[1]);
            this.employees.Add(standartEmployee);
        }

        private void JobCommand(string[] parts)
        {
            Job job = new Job(parts[1], int.Parse(parts[2]), this.employees.FirstOrDefault(e => e.Name == parts[3]), this.writer);
            this.jobs.Add(job);
            job.JobFinished += this.jobs.OnJobFinished;
        }
    }
}