using SchedulingClients.JobsStateServiceReference;
using System;

namespace SchedulingClients
{
    public class JobsStateCallback : IJobsStateServiceCallback
    {
        public JobsStateCallback()
        {
        }

        public event Action<JobsStateData> JobsStateChange;

        public void OnJobsStateChange(JobsStateData jobsStateData)
        {
            Action<JobsStateData> handlers = JobsStateChange;

            if (handlers != null)
            {
                foreach (Action<JobsStateData> handler in handlers.GetInvocationList())
                {
                    handler.BeginInvoke(jobsStateData, null, null);
                }
            }
        }
    }
}