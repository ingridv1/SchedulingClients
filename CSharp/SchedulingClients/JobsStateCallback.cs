using System;
using System.Collections.Generic;
using System.Linq;
using SchedulingClients.JobsStateServiceReference;
using System.Text;
using System.Threading.Tasks;

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