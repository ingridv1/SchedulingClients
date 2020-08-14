using BaseClients;
using BaseClients.Architecture;
using SchedulingClients.TaskStateServiceReference;
using System;

namespace SchedulingClients
{
    public interface ITaskStateClient : ICallbackClient
    {
        event Action<TaskProgressDto> TaskProgressUpdated;
    }
}
