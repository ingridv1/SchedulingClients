using BaseClients.Architecture;
using SchedulingClients.Core.SchedulingServiceReference;
using System;

namespace SchedulingClients.Core
{
    /// <summary>
    /// Monitors state of the scheduler.
    /// </summary>
    public interface ISchedulingClient : ICallbackClient
    {
        /// <summary>
        /// Fired whenever the scheduler state is updated.
        /// </summary>
        event Action<SchedulerStateDto> Updated;

        /// <summary>
        /// The current state of the scheduler.
        /// </summary>
        SchedulerStateDto SchedulerState { get; }
    }
}
