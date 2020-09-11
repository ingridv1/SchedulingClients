using BaseClients.Architecture;
using GAAPICommon.Architecture;
using SchedulingClients.Core.ServicingServiceReference;
using System;

namespace SchedulingClients.Core
{
    public interface IServicingClient : ICallbackClient
    {
        IServiceCallResult<ServiceStateDto[]> GetOutstandingServiceRequests();

        IServiceCallResult SetServiceComplete(int taskId);

        event Action<ServiceStateDto> ServiceRequest;
    }
}