using MoreLinq;
using SchedulingClients.Core.TaskStateServiceReference;
using System;
using System.Linq;

namespace SchedulingClients.Core
{
    public class TaskStateServiceCallback : ITaskStateServiceCallback
    {
        public TaskStateServiceCallback()
        {
        }

        public event Action<TaskProgressDto> TaskProgressUpdated;

        public void OnCallback(TaskProgressDto taskProgressDto)
        {
            Action<TaskProgressDto> handlers = TaskProgressUpdated;

            handlers?
                   .GetInvocationList()
                   .Cast<Action<TaskProgressDto>>()
                   .ForEach(e => e.BeginInvoke(taskProgressDto, null, null));
        }
    }
}
