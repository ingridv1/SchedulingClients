using BaseClients;
using SchedulingClients.ServicingServiceReference;
using System;

namespace SchedulingClients
{
    public interface IServicingClient : ICallbackClient
    {
        ServiceOperationResult TrySetServiceComplete(int taskId, out bool success);

        event Action<ServiceStateData> ServiceRequest;
    }
}
