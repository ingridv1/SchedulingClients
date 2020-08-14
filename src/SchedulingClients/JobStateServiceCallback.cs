using System;
using SchedulingClients.JobStateServiceReference;

namespace SchedulingClients
{
    public class JobStateServiceCallback : IJobStateServiceCallback
    {
        public JobStateServiceCallback()
        {
        }

        public event Action<JobProgressDto> JobProgressUpdated;

        public void OnCallback(JobProgressDto jobProgressDto)
        {
            Action<JobProgressDto> handlers = JobProgressUpdated;

            if (handlers != null)
            {
                foreach (Action<JobProgressDto> handler in handlers.GetInvocationList())
                {
                    handler.BeginInvoke(jobProgressDto, null, null);
                }
            }
        }
    }
}