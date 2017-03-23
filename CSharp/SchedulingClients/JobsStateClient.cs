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

        public bool AbortJob(int jobId)
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("JobsStateClient");
            }

            ChannelFactory<IJobsStateService> channelFactory = CreateChannelFactory();
            IJobsStateService channel = channelFactory.CreateChannel();

            bool result = channel.AbortJob(jobId);
            channelFactory.Close();

            return result;
        }

        public IEnumerable<int> GetActiveJobIdsForAgent(int agentId)
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("JobsStateClient");
            }

            ChannelFactory<IJobsStateService> channelFactory = CreateChannelFactory();
            IJobsStateService channel = channelFactory.CreateChannel();

            IEnumerable<int> jobIds = channel.GetActiveJobIdsForAgent(agentId);
            channelFactory.Close();
            return jobIds;
        }

        public bool GetActiveJobIdsForAgent(int agentId, out IEnumerable<int> jobIds)
        {
            try
            {
                jobIds = GetActiveJobIdsForAgent(agentId);
                return true;
            }
            catch (Exception ex)
            {
                LastCaughtException = ex;
                jobIds = Enumerable.Empty<int>();
                return false;
            }
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

        public bool TryAbortJob(int jobId, out bool couldAbort)
        {
            try
            {
                couldAbort = AbortJob(jobId);
                return true;
            }
            catch (Exception ex)
            {
                LastCaughtException = ex;
                couldAbort = false;
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