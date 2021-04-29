using BaseClients;
using SchedulingClients.TaskStateServiceReference;
using System;

namespace SchedulingClients
{
    public interface ITaskStateClient : ICallbackClient
    {
        event Action<TaskProgressData> TaskProgressUpdated;
    }
}
