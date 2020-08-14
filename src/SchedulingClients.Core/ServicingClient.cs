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
                    : base(netTcpUri)
        {
            Heartbeat = heartbeat < TimeSpan.FromMilliseconds(1000) 
                ? TimeSpan.FromMilliseconds(1000)
                : Heartbeat;
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
        /// Heartbeat time
        /// </summary>
        public TimeSpan Heartbeat { get; private set; } 

    /// <summary>
    /// Sets a service to complete
    /// </summary>
    /// <param name="taskId">Id of the service task</param>
    /// <param name="success">True if successfull</param>
    /// <returns>ServiceOperationResult</returns>
    public IServiceCallResult SetServiceComplete(int taskId)
    {
        Logger.Trace($"SetServiceComplete taskId:{taskId}");

        try
        {
            using (ChannelFactory<IServicingService> channelFactory = CreateChannelFactory())
            {
                IServicingService channel = channelFactory.CreateChannel();
                ServiceCallResultDto result = channel.SetServiceComplete(taskId);
                channelFactory.Close();

                return result;
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
            return ServiceCallResultFactory.FromClientException(ex);
        }
    }

    protected override void Dispose(bool isDisposing)
        {
            Logger.Debug("Dispose({0})", isDisposing);

            if (isDisposed)            
                return;

            isDisposed = true;

            base.Dispose(isDisposing);
        }

        protected override void HeartbeatThread()
        {
            Logger.Trace("HeartbeatThread()");

            ChannelFactory<IServicingService> channelFactory = CreateChannelFactory();
            IServicingService channel = channelFactory.CreateChannel();

            bool? exceptionCaught;

            while (!Terminate)
            {
                exceptionCaught = null;

                try
                {
                    Logger.Trace("SubscriptionHeartbeat({0})", Key);
                    channel.SubscriptionHeartbeat(Key);
                    IsConnected = true;
                    exceptionCaught = false;
                }
                catch (EndpointNotFoundException)
                {
                    Logger.Warn("HeartbeatThread - EndpointNotFoundException. Is the server running?");
                    exceptionCaught = true;
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                    exceptionCaught = true;
                }

                if (exceptionCaught == true)
                {
                    channelFactory.Abort();
                    IsConnected = false;

                    channelFactory = CreateChannelFactory(); // Create a new channel as this one is dead
                    channel = channelFactory.CreateChannel();
                }

                heartbeatReset.WaitOne(Heartbeat);
            }

            Logger.Trace("HeartbeatThread exit");
        }

        protected override void SetInstanceContext()
        {
            context = new InstanceContext(callback);
        }

        public IServiceCallResult<ServiceStateDto[]> GetOutstandingServiceRequests()
        {
            Logger.Trace($"GetOutstandingServiceRequests");

            try
            {
                using (ChannelFactory<IServicingService> channelFactory = CreateChannelFactory())
                {
                    IServicingService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto<ServiceStateDto[]> result = channel.GetOutstandingServiceRequests();
                    channelFactory.Close();

                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ServiceCallResultFactory<ServiceStateDto[]>.FromClientException(ex);
            }
        }
    }
}