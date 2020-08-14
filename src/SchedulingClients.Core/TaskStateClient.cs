using BaseClients.Core;
using SchedulingClients.Core.TaskStateServiceReference;
using System;
using System.ServiceModel;

namespace SchedulingClients.Core
{
    internal class TaskStateClient : AbstractCallbackClient<ITaskStateService>, ITaskStateClient
    {
        private TaskStateServiceCallback callback = new TaskStateServiceCallback();

        public TaskStateClient(Uri netTcpUri, TimeSpan heartbeat = default)
            : base(netTcpUri)
        {
            Heartbeat = heartbeat < TimeSpan.FromMilliseconds(1000) 
                ? TimeSpan.FromMilliseconds(1000) 
                : heartbeat;
        }

        public event Action<TaskProgressDto> TaskProgressUpdated
        {
            add { callback.TaskProgressUpdated += value; }
            remove { callback.TaskProgressUpdated -= value; }
        }

        public TimeSpan Heartbeat { get; private set; }

        private bool isDisposed = false;

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposed)
                return;
	
            isDisposed = true;

            base.Dispose(isDisposing);
        }

        protected override void HeartbeatThread()
        {
            Logger.Trace("HeartbeatThread()");

            ChannelFactory<ITaskStateService> channelFactory = CreateChannelFactory();
            ITaskStateService channel = channelFactory.CreateChannel();

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

    }
}
