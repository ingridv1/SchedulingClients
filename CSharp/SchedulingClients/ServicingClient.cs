using SchedulingClients.ServicingServiceReference;
using System;
using System.ServiceModel;

namespace SchedulingClients
{
    public class ServicingClient : AbstractCallbackClient<IServicingService>
    {
        private ServicingServiceCallback callback = new ServicingServiceCallback();

        private TimeSpan heartbeat;

        private bool isDisposed = false;

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

        public bool SetServiceComplete(int taskId)
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("RoadmapClient");
            }

            ChannelFactory<IServicingService> channelFactory = CreateChannelFactory();
            IServicingService channel = channelFactory.CreateChannel();

            bool result = channel.SetServiceComplete(taskId);
            channelFactory.Close();
            return result;
        }

        public bool TrySetServiceComplete(int taskId, out bool success)
        {
            try
            {
                success = SetServiceComplete(taskId);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Warn(ex);
                LastCaughtException = ex;
                success = false;
                return false;
            }
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposed)
            {
                return;
            }

            isDisposed = true;

            base.Dispose(isDisposing);
        }

        protected override void HeartbeatThread()
        {
            Logger.Debug("[ServicingClient] HeartbeatThread");

            ChannelFactory<IServicingService> channelFactory = CreateChannelFactory();
            IServicingService servicingService = channelFactory.CreateChannel();

            while (!Terminate)
            {
                try
                {
                    Logger.Trace("[ServicingClient] SubscriptionHeartbeat({0})", Key);
                    servicingService.SubscriptionHeartbeat(Key);
                    IsConnected = true;
                }
                catch (Exception ex)
                {
                    channelFactory.Abort();
                    Logger.Warn(ex);
                    IsConnected = false;

                    channelFactory = CreateChannelFactory(); // Create a new channel as this one is dead
                    servicingService = channelFactory.CreateChannel();
                }

                heartbeatReset.WaitOne(Heartbeat);
            }

            Logger.Debug("[ServicingClient] HeartbeatThread exit()");
        }

        protected override void SetInstanceContext()
        {
            this.context = new InstanceContext(this.callback);
        }
    }
}