using MoreLinq;
using SchedulingClients.Core.SchedulingServiceReference;
using System;
using System.Linq;

namespace SchedulingClients.Core
{
    public class SchedulingServiceCallback : ISchedulingServiceCallback
    {
        public SchedulingServiceCallback()
        {
        }

        public event Action<SchedulerStateDto> Updated;

        public void OnCallback(SchedulerStateDto schedulerStateDto)
        {
            Action<SchedulerStateDto> handlers = Updated;

            handlers?
                .GetInvocationList()
                .Cast<Action<SchedulerStateDto>>()
                .ForEach(e => e.BeginInvoke(schedulerStateDto, null, null));
        }
    }
}
