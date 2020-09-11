using BaseClients.Architecture;
using GAAPICommon.Architecture;
using SchedulingClients.Core.ServicingServiceReference;
using System;

namespace SchedulingClients.Core
{
    /// <summary>
    /// Monitors and completes service requests. 
    /// </summary>
    public interface IServicingClient : ICallbackClient
    {
        /// <summary>
        /// Gets all outstanding service requests.
        /// </summary>
        /// <returns>Array of service state dtos.</returns>
        IServiceCallResult<ServiceStateDto[]> GetOutstandingServiceRequests();

        /// <summary>
        /// Marks a service task as complete.
        /// </summary>
        /// <param name="taskId">target task id</param>
        /// <returns>Successful service call result on success</returns>
        IServiceCallResult SetServiceComplete(int taskId);

        /// <summary>
        /// Fired whenever a new service request is received. 
        /// </summary>
        event Action<ServiceStateDto> ServiceRequest;
    }
}