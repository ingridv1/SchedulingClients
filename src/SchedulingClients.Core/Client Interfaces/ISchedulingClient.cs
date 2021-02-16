using BaseClients.Architecture;
using SchedulingClients.Core.SchedulingServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingClients.Core
{
    public interface ISchedulingClient : ICallbackClient
    {
        event Action<SchedulerStateDto> Updated;

        SchedulerStateDto SchedulerState { get; }
    }
}
