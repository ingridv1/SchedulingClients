using System;
using SchedulingClients.Core.JobStateServiceReference;
using System.ServiceModel;
using BaseClients;
using BaseClients.Core;
using GAAPICommon.Architecture;
using GAAPICommon.Core.Dtos;
using GAAPICommon.Core;

namespace SchedulingClients.Core
{
    internal class JobStateClient : AbstractCallbackClient<IJobStateService>, IJobStateClient
    {
        private JobStateServiceCallback callback = new JobStateServiceCallback();

        private bool isDisposed = false;

        /// <summary>
        /// Creates a JobStateClient
        /// </summary>
        /// <param name="netTcpUri">net.tcp address of the job state service</param>
        public JobStateClient(Uri netTcpUri, TimeSpan heartbeat = default)
            : base(netTcpUri)
        {
            Heartbeat = heartbeat < TimeSpan.FromMilliseconds(1000) 
                ? TimeSpan.FromMilliseconds(1000)
                : heartbeat;
        }

        public event Action<JobProgressDto> JobProgressUpdated
        {
            add { callback.JobProgressUpdated += value; }
            remove { callback.JobProgressUpdated -= value; }
        }

        /// <summary>
        /// Heartbeat time
        /// </summary>
        public TimeSpan Heartbeat { get; private set; }

        /// <summary>
        /// Gets the state of a specific job
        /// </summary>
        /// <param name="jobId">Job id</param>
        /// <param name="jobState">State job is in</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult<JobSummaryDto> GetJobSummary(int jobId)
        {
            Logger.Trace($"GetJobSummary jobId:{jobId}");

            try
            {
                using (ChannelFactory<IJobStateService> channelFactory = CreateChannelFactory())
                {
                    IJobStateService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto<JobSummaryDto> result = channel.GetJobSummary(jobId);
                    channelFactory.Close();

                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ServiceCallResultFactory<JobSummaryDto>.FromClientException(ex);
            }
        }

        /// <summary>
        /// Gets the summary of a specific job from the id one of its child tasks
        /// </summary>
        /// <param name="taskId">Task id</param>
        /// <param name="jobSummaryData">Job summary</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult<JobSummaryDto> GetParentJobSummaryFromTaskId(int taskId)
        {
            Logger.Trace($"GetParentJobSummaryFromTaskId jobId:{taskId}");

            try
            {
                using (ChannelFactory<IJobStateService> channelFactory = CreateChannelFactory())
                {
                    IJobStateService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto<JobSummaryDto> result = channel.GetParentJobSummaryFromTaskId(taskId);
                    channelFactory.Close();

                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ServiceCallResultFactory<JobSummaryDto>.FromClientException(ex);
            }
        }

        /// <summary>
        /// Gets the summary of the curent job for an agent
        /// </summary>
        /// <param name="agentId">Agent id</param>
        /// <param name="jobSummaryData">Job summary</param>
        /// <returns>ServiceOperationResult</return
        public IServiceCallResult<JobSummaryDto> GetCurrentJobSummaryForAgentId(int agentId)
        {
            Logger.Trace($"GetParentJobSummaryFromTaskId agentId:{agentId}");

            try
            {
                using (ChannelFactory<IJobStateService> channelFactory = CreateChannelFactory())
                {
                    IJobStateService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto<JobSummaryDto> result = channel.GetCurrentJobSummaryForAgentId(agentId);
                    channelFactory.Close();

                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ServiceCallResultFactory<JobSummaryDto>.FromClientException(ex);
            }
        }


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

            ChannelFactory<IJobStateService> channelFactory = CreateChannelFactory();
            IJobStateService channel = channelFactory.CreateChannel();

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