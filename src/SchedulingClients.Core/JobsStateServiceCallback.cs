using MoreLinq;
using SchedulingClients.Core.JobsStateServiceReference;
using System;
using System.Linq;

namespace SchedulingClients.Core
{
    public class JobsStateServiceCallback : IJobsStateServiceCallback
    {
        public JobsStateServiceCallback()
        {
        }

        public event Action<JobsStateDto> JobsStateChange;

        public void OnCallback(JobsStateDto callbackObject)
        {
            Action<JobsStateDto> handlers = JobsStateChange;

            handlers?
                   .GetInvocationList()
                   .Cast<Action<JobsStateDto>>()
                   .ForEach(e => e.BeginInvoke(callbackObject, null, null));
        }
    }
}