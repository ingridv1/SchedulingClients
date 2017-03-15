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

        protected override void ConfigureChannelFactory()
        {
            InstanceContext context = new InstanceContext(this.callback);
            this.channelFactory = new DuplexChannelFactory<IServicingService>(context, Binding, EndpointAddress);
        }

        protected override void HeartbeatThread()
        {
            Logger.Debug("[ServicingClient] HeartbeatThread");

            while (!Terminate)
            {
                try
                {
                    if (channelFactory.State != CommunicationState.Opened)
                    {
                        channelFactory.Abort();
                        ConfigureChannelFactory();
                    }

                    IServicingService channel = channelFactory.CreateChannel();
                    Logger.Trace("[ServicingClient] SubscriptionHeartbeat({0})", Key);
                    channel.SubscriptionHeartbeat(Key);
                    IsConnected = true;
                }
                catch (Exception ex)
                {
                    channelFactory.Abort();
                    Logger.Warn(ex);
                    IsConnected = false;
                }

                heartbeatReset.WaitOne(Heartbeat);
            }

            Logger.Debug("[ServicingClient] HeartbeatThread exit()");
        }
    }
}