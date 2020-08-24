using BaseClients;
using BaseClients.Core;
using GAAPICommon.Architecture;
using GAAPICommon.Core;
using GAAPICommon.Core.Dtos;
using NLog;
using SchedulingClients.Core.ServicingServiceReference;
using System;
using System.ServiceModel;

namespace SchedulingClients.Core
{
    internal class ServicingClient : AbstractCallbackClient<IServicingService>, IServicingClient
    {
        private ServicingServiceCallback callback = new ServicingServiceCallback();

        private bool isDisposed = false;

        /// <summary>
        /// Creates a new servicing client
        /// </summary>
        /// <param name="netTcpUri">net.tcp address of the servicing service</param>
        /// <param name="Heartbeat">Heartbeat</param>
        public ServicingClient(Uri netTcpUri, TimeSpan heartbeat = default)
                    : base(netTcpUri, heartbeat)
        {
        }

        /// <summary>
        /// New service request received
        /// </summary>
        public event Action<ServiceStateDto> ServiceRequest
        {
            add { callback.ServiceRequest += value; }
            remove { callback.ServiceRequest -= value; }
        }


        /// <summary>
        /// Sets a service to complete
        /// </summary>
        /// <param name="taskId">Id of the service task</param>
        /// <param name="success">True if successfull</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult SetServiceComplete(int taskId)
        {
            Logger.Trace($"SetServiceComplete() taskId:{taskId}");
            return HandleAPICall(e => e.SetServiceComplete(taskId));
        }

        protected override void Dispose(bool isDisposing)
        {
            Logger.Debug("Dispose({0})", isDisposing);

            if (isDisposed)            
                return;

            isDisposed = true;

            base.Dispose(isDisposing);
        }     

        protected override void SetInstanceContext()
        {
            context = new InstanceContext(callback);
        }

        public IServiceCallResult<ServiceStateDto[]> GetOutstandingServiceRequests()
        {
            Logger.Trace($"GetOutstandingServiceRequests()");
            return HandleAPICall<ServiceStateDto[]>(e => e.GetOutstandingServiceRequests());
        }

        protected override void HandleSubscriptionHeartbeat(IServicingService channel, Guid key)
        {
            channel.SubscriptionHeartbeat(key);
        }
    }
}