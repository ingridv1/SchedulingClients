using BaseClients;
using SchedulingClients.ServicingServiceReference;
using System;
using System.ServiceModel;

namespace SchedulingClients
{
    internal class ServicingClient : AbstractCallbackClient<IServicingService>, IServicingClient
    {
        private ServicingServiceCallback callback = new ServicingServiceCallback();

        private TimeSpan heartbeat;

        private bool isDisposed = false;

        /// <summary>
        /// Creates a new servicing client
        /// </summary>
        /// <param name="netTcpUri">net.tcp address of the servicing service</param>
        /// <param name="heartbeat">Heartbeat</param>
        public ServicingClient(Uri netTcpUri, TimeSpan heartbeat = default(TimeSpan))
                    : base(netTcpUri)
        {
            this.heartbeat = heartbeat < TimeSpan.FromMilliseconds(1000) ? TimeSpan.FromMilliseconds(1000) : heartbeat;
        }

        /// <summary>
        /// New service request received
        /// </summary>
        public event Action<ServiceStateData> ServiceRequest
        {
            add { callback.ServiceRequest += value; }
            remove { callback.ServiceRequest -= value; }
        }

        /// <summary>
        /// Heartbeat time
        /// </summary>
        public TimeSpan Heartbeat { get { return heartbeat; } }

        /// <summary>
        /// Sets a service to complete
        /// </summary>
        /// <param name="taskId">Id of the service task</param>
        /// <param name="success">True if successfull</param>
        /// <returns>ServiceOperationResult</returns>
        public ServiceOperationResult TrySetServiceComplete(int taskId, out bool success)
        {
            Logger.Info("TrySetServiceComplete({0})", taskId);

            try
            {
                var result = SetServiceComplete(taskId);
                success = result.Item1;
                return ServiceOperationResultFactory.FromServicingServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                success = false;
                return HandleClientException(ex);
            }
        }

        protected override void Dispose(bool isDisposing)
        {
            Logger.Debug("Dispose({0})", isDisposing);

            if (isDisposed)
            {
                return;
            }

            isDisposed = true;

            base.Dispose(isDisposing);
        }

        protected override void HeartbeatThread()
        {
            Logger.Debug("HeartbeatThread()");

            ChannelFactory<IServicingService> channelFactory = CreateChannelFactory();
            IServicingService servicingService = channelFactory.CreateChannel();

            bool? exceptionCaught;

            while (!Terminate)
            {
                exceptionCaught = null;

                try
                {
                    Logger.Trace("SubscriptionHeartbeat({0})", Key);
                    servicingService.SubscriptionHeartbeat(Key);
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
                    servicingService = channelFactory.CreateChannel();
                }

                heartbeatReset.WaitOne(Heartbeat);
            }

            Logger.Debug("HeartbeatThread exit");
        }

        protected override void SetInstanceContext()
        {
            this.context = new InstanceContext(this.callback);
        }

        private Tuple<bool, ServiceCallData> SetServiceComplete(int taskId)
        {
            Logger.Debug("SetServiceComplete({0})", taskId);

            if (isDisposed)
            {
                throw new ObjectDisposedException("RoadmapClient");
            }

            Tuple<bool, ServiceCallData> result;

            using (ChannelFactory<IServicingService> channelFactory = CreateChannelFactory())
            {
                IServicingService channel = channelFactory.CreateChannel();
                result = channel.SetServiceComplete(taskId);
                channelFactory.Close();
            }

            return result;
        }
    }
}