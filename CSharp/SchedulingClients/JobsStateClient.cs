using SchedulingClients.JobsStateServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace SchedulingClients
{
    public class JobsStateClient : AbstractCallbackClient<IJobsStateService>
    {
        private JobsStateCallback callback = new JobsStateCallback();

        private TimeSpan heartbeat;

        private bool isDisposed = false;

        private JobsStateData jobsStateData = null;

        public JobsStateClient(Uri netTcpUri, TimeSpan heartbeat = default(TimeSpan))
                    : base(netTcpUri)
        {
            this.heartbeat = heartbeat < TimeSpan.FromMilliseconds(1000) ? TimeSpan.FromMilliseconds(1000) : heartbeat;
            callback.JobsStateChange += Callback_JobsStateChange;
        }

        /// <summary>
        /// Hearbeat time
        /// </summary>
        public TimeSpan Heartbeat { get { return heartbeat; } }

        /// <summary>
        /// The current state of jobs in the server
        /// </summary>
        public JobsStateData JobsStateData
        {
            get { return jobsStateData; }

            private set
            {
                if (jobsStateData != value)
                {
                    jobsStateData = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Aborts all jobs
        /// </summary>
        public void AbortAllJobs()
        {
            Logger.Info("AbortAllJobs()");

            if (isDisposed)
            {
                throw new ObjectDisposedException("JobsStateClient");
            }

            ChannelFactory<IJobsStateService> channelFactory = CreateChannelFactory();
            IJobsStateService channel = channelFactory.CreateChannel();

            channel.AbortAllJobs();
            channelFactory.Close();
        }

        /// <summary>
        /// Aborts a specific job
        /// </summary>
        /// <param name="jobId">Id of the the to be aborted</param>
        /// <returns>True if succesfully aborted</returns>
        public bool AbortJob(int jobId)
        {
            Logger.Info("AbortJob({0})", jobId);

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

        /// <summary>
        /// Gets active jobs for a specific agent
        /// </summary>
        /// <param name="agentId">Id of agent</param>
        /// <returns>Enumerable of all job ids in the waiting or inProgress state</returns>
        public IEnumerable<int> GetActiveJobIdsForAgent(int agentId)
        {
            Logger.Info("GetActiveJobIdsForAgent({0})", agentId);

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

        /// <summary>
        /// Tries to abort all jobs
        /// </summary>
        /// <returns>True if succesfull, otherwise false</returns>
        public bool TryAbortAllJobs()
        {
            Logger.Info("TryAbortAllJobs()");

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

        /// <summary>
        /// Tries to abort a specific job
        /// </summary>
        /// <param name="jobId">Id of the job to abort</param>
        /// <param name="couldAbort">True if job could be aborted</param>
        /// <returns>True if succesfull, otherwise false</returns>
        public bool TryAbortJob(int jobId, out bool couldAbort)
        {
            Logger.Info("TryAbortJob({0})", jobId);

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

        /// <summary>
        /// Tries to get active job ids for agent
        /// </summary>
        /// <param name="agentId">Id of agent</param>
        /// <param name="jobIds">Enumerable of all job ids in the waiting or inProgress state</param>
        /// <returns>True if succesfull, otherwise false</returns>
        public bool TryGetActiveJobIdsForAgent(int agentId, out IEnumerable<int> jobIds)
        {
            Logger.Info("TryGetActiveJobIdsForAgent({0})", agentId);

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

        protected override void Dispose(bool isDisposing)
        {
            Logger.Debug("Dispose({0})", isDisposing);

            if (isDisposed)
            {
                return;
            }

            callback.JobsStateChange -= Callback_JobsStateChange;
            isDisposed = true;

            base.Dispose(isDisposing);
        }

        protected override void HeartbeatThread()
        {
            Logger.Debug("HeartbeatThread()");

            ChannelFactory<IJobsStateService> channelFactory = CreateChannelFactory();
            IJobsStateService jobsStateService = channelFactory.CreateChannel();

            bool? exceptionCaught;

            while (!Terminate)
            {
                exceptionCaught = null;

                try
                {
                    Logger.Trace("SubscriptionHeartbeat({0})", Key);
                    jobsStateService.SubscriptionHeartbeat(Key);
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
                    jobsStateService = channelFactory.CreateChannel();
                }

                heartbeatReset.WaitOne(Heartbeat);
            }

            Logger.Debug("HeartbeatThread exit");
        }

        protected override void SetInstanceContext()
        {
            this.context = new InstanceContext(this.callback);
        }

        private void Callback_JobsStateChange(JobsStateData newJobsStateData)
        {
            JobsStateData = newJobsStateData;
        }
    }
}