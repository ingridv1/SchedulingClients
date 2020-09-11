using MoreLinq;
using SchedulingClients.Core.JobStateServiceReference;
using System;
using System.Linq;

namespace SchedulingClients.Core
{
    internal class JobStateServiceCallback : IJobStateServiceCallback
    {
        public JobStateServiceCallback()
        {
        }

        public event Action<JobProgressDto> JobProgressUpdated;

        public void OnCallback(JobProgressDto jobProgressDto)
        {
            Action<JobProgressDto> handlers = JobProgressUpdated;

            handlers?
                   .GetInvocationList()
                   .Cast<Action<JobProgressDto>>()
                   .ForEach(e => e.BeginInvoke(jobProgressDto, null, null));
        }
    }
}