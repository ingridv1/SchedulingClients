﻿using BaseClients;
using SchedulingClients.JobsStateServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace SchedulingClients
{
    internal class JobsStateClient : AbstractCallbackClient<IJobsStateService>, IJobsStateClient
    {
        private JobsStateServiceCallback callback = new JobsStateServiceCallback();

        private TimeSpan heartbeat;

        private bool isDisposed = false;

        private JobsStateData jobsStateData = null;

        private static readonly TimeSpan minimumHearbeat = TimeSpan.FromMilliseconds(10000);

        public static TimeSpan MinimumHeartbeat => minimumHearbeat;

        /// <summary>
        /// Creates a JobsStateClient
        /// </summary>
        /// <param name="netTcpUri">net.tcp address of the job state service</param>
        /// <param name="heartbeat">Heartbeat</param>
        public JobsStateClient(Uri netTcpUri, TimeSpan heartbeat = default(TimeSpan))
                    : base(netTcpUri)
        {
            this.heartbeat = heartbeat < MinimumHeartbeat ? MinimumHeartbeat : heartbeat;
            callback.JobsStateChange += Callback_JobsStateChange;
        }

        /// <summary>
        /// Hearbeat time
        /// </summary>
        public TimeSpan Heartbeat => heartbeat; 

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
        /// <param name="success">True if abortion successfull</param>
        /// <returns>ServiceOperationResult</returns>
        public ServiceOperationResult TryAbortAllJobs(out bool success)
        {
            Logger.Info("TryAbortAllJobs()");

            try
            {
                var result = AbortAllJobs();
                success = result.Item1;
                return ServiceOperationResultFactory.FromJobsStateServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                success = false;
                return HandleClientException(ex);
            }
        }

        public ServiceOperationResult TryAbortAllJobsForAgent(int agentId, out bool success)
        {
            Logger.Info("TryAbortAllJobsForAgent() agentId:{0}", agentId);

            try
            {
                Tuple<bool,ServiceCallData> result = AbortAllJobsForAgent(agentId);
                success = result.Item1;
                return ServiceOperationResultFactory.FromJobsStateServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                success = false;
                return HandleClientException(ex);
            }
        }

        /// <summary>
        /// Abort a specific job
        /// </summary>
        /// <param name="jobId">Id of job to abort</param>
        /// <param name="success">True if successfull</param>
        /// <returns></returns>
        public ServiceOperationResult TryAbortJob(int jobId, out bool success)
        {
            Logger.Info("TryAbortJob({0})", jobId);

            try
            {
                Tuple<bool, ServiceCallData> result = AbortJob(jobId);
                success = result.Item1;
                return ServiceOperationResultFactory.FromJobsStateServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                success = false;
                return HandleClientException(ex);
            }
        }

        /// <summary>
        /// Abort a specific task
        /// </summary>
        /// <param name="taskId">Id of task to abort</param>
        /// <param name="success">True if successfull</param>
        /// <returns></returns>
        public ServiceOperationResult TryAbortTask(int taskId, out bool success)
        {
            Logger.Info("TryAbortTask({0})", taskId);

            try
            {
                var result = AbortTask(taskId);
                success = result.Item1;
                return ServiceOperationResultFactory.FromJobsStateServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                success = false;
                return HandleClientException(ex);
            }
        }

        /// <summary>
        /// Gets all active jobs for a specifc agent
        /// </summary>
        /// <param name="agentId">Id of agent</param>
        /// <param name="jobIds">Active job ids for this agent</param>
        /// <returns>ServiceOperationResult</returns>
        public ServiceOperationResult TryGetActiveJobIdsForAgent(int agentId, out IEnumerable<int> jobIds)
        {
            Logger.Info("TryGetActiveJobIdsForAgent({0})", agentId);

            try
            {
                var result = GetActiveJobIdsForAgent(agentId);
                jobIds = result.Item1;
                return ServiceOperationResultFactory.FromJobsStateServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                jobIds = Enumerable.Empty<int>();
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

        private Tuple<bool, ServiceCallData> AbortAllJobs()
        {
            Logger.Debug("AbortAllJobs()");

            if (isDisposed)
            {
                throw new ObjectDisposedException("JobsStateClient");
            }

            Tuple<bool, ServiceCallData> result;

            using (ChannelFactory<IJobsStateService> channelFactory = CreateChannelFactory())
            {
                IJobsStateService channel = channelFactory.CreateChannel();

                result = channel.AbortAllJobs();
                channelFactory.Close();
            }

            return result;
        }

        private Tuple<bool,ServiceCallData> AbortAllJobsForAgent(int agentId)
        {
            Logger.Trace("AbortAllJobsForAgent() agentId: {0}", agentId);

            if (isDisposed) throw new ObjectDisposedException("JobsStateClient");

            Tuple<bool, ServiceCallData> result;

            using (ChannelFactory<IJobsStateService> channelFactory = CreateChannelFactory())
            {
                IJobsStateService channel = channelFactory.CreateChannel();
                result = channel.AbortAllJobsForAgent(agentId);
                channelFactory.Close();
            }

            return result;
        }

        private Tuple<bool, ServiceCallData> AbortJob(int jobId, string note = null)
        {
            Logger.Debug("AbortJob({0})", jobId);

            if (isDisposed) throw new ObjectDisposedException("JobsStateClient");

            Tuple<bool, ServiceCallData> result;

            using (ChannelFactory<IJobsStateService> channelFactory = CreateChannelFactory())
            {
                IJobsStateService channel = channelFactory.CreateChannel();
                result = channel.AbortJob(jobId, note);
                channelFactory.Close();
            }

            return result;
        }

        private Tuple<bool, ServiceCallData> AbortTask(int taskId)
        {
            Logger.Debug("AbortTask({0})", taskId);

            if (isDisposed)
            {
                throw new ObjectDisposedException("JobsStateClient");
            }

            Tuple<bool, ServiceCallData> result;

            using (ChannelFactory<IJobsStateService> channelFactory = CreateChannelFactory())
            {
                IJobsStateService channel = channelFactory.CreateChannel();
                result = channel.AbortTask(taskId);            
                channelFactory.Close();
            }

            return result;
        }

        private void Callback_JobsStateChange(JobsStateData newJobsStateData)
        {
            JobsStateData = newJobsStateData;
        }

        private Tuple<int[], ServiceCallData> GetActiveJobIdsForAgent(int agentId)
        {
            Logger.Debug("GetActiveJobIdsForAgent({0})", agentId);

            if (isDisposed)
            {
                throw new ObjectDisposedException("JobsStateClient");
            }

            Tuple<int[], ServiceCallData> result;

            using (ChannelFactory<IJobsStateService> channelFactory = CreateChannelFactory())
            {
                IJobsStateService channel = channelFactory.CreateChannel();
                result = channel.GetActiveJobIdsForAgent(agentId);
                channelFactory.Close();
            }

            return result;
        }
    }
}