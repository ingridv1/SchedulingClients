using System;
using SchedulingClients.ServicingServiceReference;
using System.ServiceModel;

namespace SchedulingClients
{
    public class ServicingClient : AbstractCallbackClient<IServicingService>
    {
        private ServicingServiceCallback callback = new ServicingServiceCallback();

        private TimeSpan heartbeat;

        public ServicingClient(Uri netTcpUri, TimeSpan heartbeat = default(TimeSpan))
            : base(netTcpUri)
        {
            this.heartbeat = heartbeat < TimeSpan.FromMilliseconds(1000) ? TimeSpan.FromMilliseconds(1000) : heartbeat;
        }

        public event Action<ServiceStateData> ServiceRequest
        {
            add { callback.ServiceRequest += value; }
            remove { callback.ServiceRequest -= value; }
        }

        public TimeSpan Heartbeat { get { return heartbeat; } }

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