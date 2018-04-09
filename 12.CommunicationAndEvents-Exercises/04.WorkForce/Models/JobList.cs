namespace WorkForce.Models
{
    using System.Collections.Generic;

    public class JobList : List<Job>
    {
        public void OnJobFinished(object sender, JobEventArgs args)
        {
            args.Job.JobFinished -= this.OnJobFinished;
            this.Remove(args.Job);
        }
    }
}