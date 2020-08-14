using BaseClients.Architecture;
using GAAPICommon.Architecture;
using SchedulingClients.ServicingServiceReference;
using System;

namespace SchedulingClients
{
    public interface IServicingClient : ICallbackClient
    {
        IServiceCallResult<ServiceStateDto[]> GetOutstandingServiceRequests();

        IServiceCallResult SetServiceComplete(int taskId);

        event Action<ServiceStateDto> ServiceRequest;
    }
}
