using BaseClients.Architecture;
using SchedulingClients.Core.TaskStateServiceReference;
using System;

namespace SchedulingClients
{
    /// <summary>
    /// Monitors task progress.
    /// </summary>
    public interface ITaskStateClient : ICallbackClient
    {
        /// <summary>
        /// Fired whenever a task progresses its state. 
        /// </summary>
        event Action<TaskProgressDto> TaskProgressUpdated;
    }
}