using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchedulingClients.JobsStateServiceReference;
using System.ServiceModel;

namespace SchedulingClients
{
    public class JobsStateClient : AbstractCallbackClient<IJobsStateService>
    {
        private JobsStateCallback callback = new JobsStateCallback();

        private TimeSpan heartbeat;

        private bool isDisposed = false;

        public JobsStateClient(Uri netTcpUri, TimeSpan heartbeat = default(TimeSpan))
                    : base(netTcpUri)
        {
            this.heartbeat = heartbeat < TimeSpan.FromMilliseconds(1000) ? TimeSpan.FromMilliseconds(1000) : heartbeat;
        }

        public event Action<JobsStateData> JobsStateChange
        {
            add { callback.JobsStateChange += value; }
            remove { callback.JobsStateChange -= value; }
        }

        public TimeSpan Heartbeat { get { return heartbeat; } }

        public void AbortAllJobs()
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("JobsStateClient");
            }

            ChannelFactory<IJobsStateService> channelFactory = CreateChannelFactory();
            IJobsStateService channel = channelFactory.CreateChannel();

            channel.AbortAllJobs();
            channelFactory.Close();
        }

        public bool TryAbortAllJobs()
        {
            try
            {
                AbortAllJobs();
                return true;
            }
            catch (Exception ex)
            {
                LastCaughtException = ex;
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
        }

        protected override void HeartbeatThread()
        {
            Logger.Debug("[JobsStateClient] HeartbeatThread");

            ChannelFactory<IJobsStateService> channelFactory = CreateChannelFactory();
            IJobsStateService jobsStateService = channelFactory.CreateChannel();

            while (!Terminate)
            {
                try
                {
                    Logger.Trace("[JobsStateClient] SubscriptionHeartbeat({0})", Key);
                    jobsStateService.SubscriptionHeartbeat(Key);
                    IsConnected = true;
                }
                catch (Exception ex)
                {
                    channelFactory.Abort();
                    Logger.Warn(ex);
                    IsConnected = false;

                    channelFactory = CreateChannelFactory(); // Create a new channel as this one is dead
                    jobsStateService = channelFactory.CreateChannel();
                }

                heartbeatReset.WaitOne(Heartbeat);
            }

            Logger.Debug("[JobsStateClient] HeartbeatThread exit()");
        }

        protected override void SetInstanceContext()
        {
            this.context = new InstanceContext(this.callback);
        }
    }
}