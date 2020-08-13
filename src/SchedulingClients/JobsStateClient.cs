using BaseClients.Core;
using GAAPICommon.Architecture;
using GAAPICommon.Core;
using GAAPICommon.Core.Dtos;
using MoreLinq;
using SchedulingClients.JobsStateServiceReference;
using System;
using System.Linq;
using System.ServiceModel;

namespace SchedulingClients
{
    internal class JobsStateClient : AbstractCallbackClient<IJobsStateService>, IJobsStateClient
    {
        private JobsStateServiceCallback callback = new JobsStateServiceCallback();

        private TimeSpan heartbeat;

        private bool isDisposed = false;

        private JobsStateDto jobsStateDto = null;

        public static TimeSpan MinimumHeartbeat { get; } = TimeSpan.FromMilliseconds(10000);

        /// <summary>
        /// Creates a JobsStateClient
        /// </summary>
        /// <param name="netTcpUri">net.tcp address of the job state service</param>
        /// <param name="heartbeat">Heartbeat</param>
        public JobsStateClient(Uri netTcpUri, TimeSpan heartbeat = default)
                    : base(netTcpUri)
        {
            this.heartbeat = heartbeat < MinimumHeartbeat 
                ? MinimumHeartbeat
                : heartbeat;

            callback.JobsStateChange += Callback_JobsStateChange;
        }

        /// <summary>
        /// Hearbeat time
        /// </summary>
        public TimeSpan Heartbeat => heartbeat;

        public event Action<JobsStateDto> JobsStateUpdated;

        /// <summary>
        /// The current state of jobs in the server
        /// </summary>
        public JobsStateDto JobsStateDto
        {
            get { return jobsStateDto; }

            private set
            {
                if (jobsStateDto != value)
                {
                    jobsStateDto = value;
                    OnJobsStateUpdated(jobsStateDto);
                }
            }
        }

        private void OnJobsStateUpdated(JobsStateDto jobsStateDto)
        {
            Action<JobsStateDto> handlers = JobsStateUpdated;

            handlers?
                   .GetInvocationList()
                   .Cast<Action<JobsStateDto>>()
                   .ForEach(e => e.BeginInvoke(jobsStateDto, null, null));
        }

        /// <summary>
        /// Aborts all jobs
        /// </summary>
        /// <param name="success">True if abortion successfull</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult AbortAllJobs()
        {
            Logger.Trace("AbortAllJobs()");

            try
            {
                using (ChannelFactory<IJobsStateService> channelFactory = CreateChannelFactory())
                {
                    IJobsStateService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto result = channel.AbortAllJobs();
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


        public IServiceCallResult AbortAllJobsForAgent(int agentId)
        {
            Logger.Trace("AbortAllJobsForAgent({0})", agentId);

            try
            {
                using (ChannelFactory<IJobsStateService> channelFactory = CreateChannelFactory())
                {
                    IJobsStateService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto result = channel.AbortAllJobsForAgent(agentId);
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

        /// <summary>
        /// Abort a specific job
        /// </summary>
        /// <param name="jobId">Id of job to abort</param>
        /// <param name="success">True if successfull</param>
        /// <returns></returns>
        public IServiceCallResult AbortJob(int jobId, string note)
        {
            if (string.IsNullOrEmpty(note))
                note = "Unspecified";

            Logger.Trace("AbortJob({0},{1})", jobId, note);

            try
            {
                using (ChannelFactory<IJobsStateService> channelFactory = CreateChannelFactory())
                {
                    IJobsStateService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto result = channel.AbortJob(jobId, note);
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

        /// <summary>
        /// Abort a specific task
        /// </summary>
        /// <param name="taskId">Id of task to abort</param>
        /// <param name="success">True if successfull</param>
        /// <returns></returns>
        public IServiceCallResult AbortTask(int taskId)
        {
            Logger.Trace("Abort Task({0})", taskId);

            try
            {
                using (ChannelFactory<IJobsStateService> channelFactory = CreateChannelFactory())
                {
                    IJobsStateService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto result = channel.AbortTask(taskId);
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

        /// <summary>
        /// Gets all active jobs for a specifc agent
        /// </summary>
        /// <param name="agentId">Id of agent</param>
        /// <param name="jobIds">Active job ids for this agent</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult<int[]> GetActiveJobIdsForAgent(int agentId)
        {
            Logger.Trace("GetActiveJobIdsForAgent({0})", agentId);

            try
            {
                using (ChannelFactory<IJobsStateService> channelFactory = CreateChannelFactory())
                {
                    IJobsStateService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto<int[]> result = channel.GetActiveJobIdsForAgent(agentId);
                    channelFactory.Close();

                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ServiceCallResultFactory<int[]>.FromClientException(ex);
            }
        }

        protected override void Dispose(bool isDisposing)
        {
            Logger.Debug("Dispose({0})", isDisposing);

            if (isDisposed)            
                return;
   
            callback.JobsStateChange -= Callback_JobsStateChange;
            isDisposed = true;

            base.Dispose(isDisposing);
        }

        protected override void HeartbeatThread()
        {
            Logger.Trace("HeartbeatThread()");

            ChannelFactory<IJobsStateService> channelFactory = CreateChannelFactory();
            IJobsStateService channel = channelFactory.CreateChannel();

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

        private void Callback_JobsStateChange(JobsStateDto newJobsStateDto)
        {
            JobsStateDto = newJobsStateDto;
        }
    }
}