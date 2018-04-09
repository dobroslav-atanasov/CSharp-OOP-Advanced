namespace WorkForce.Models
{
    using System;
    using Intefaces;
    using IO.Interfaces;

    public class Job : IJob
    {
        private string name;
        private int hoursRequired;
        private IEmployee employee;
        private IWriter writer;

        public Job(string name, int hoursRequired, IEmployee employee, IWriter writer)
        {
            this.name = name;
            this.hoursRequired = hoursRequired;
            this.employee = employee;
            this.writer = writer;
        }

        public event EventHandler<JobEventArgs> JobFinished;

        public void Update()
        {
            this.hoursRequired -= this.employee.WorkHoursPerWeek;
            if (this.hoursRequired <= 0)
            {
                this.OnJobFinished();
            }
        }

        protected virtual void OnJobFinished()
        {
            this.writer.WriteLine($"Job {this.name} done!");
            if (this.JobFinished != null)
            {
                this.JobFinished(this, new JobEventArgs(this));
            }
        }

        public override string ToString()
        {
            return $"Job: {this.name} Hours Remaining: {this.hoursRequired}";
        }
    }
}