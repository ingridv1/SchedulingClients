using BaseClients.Core;
using GAAPICommon.Architecture;
using SchedulingClients.Core.JobStateServiceReference;
using System;
using System.ServiceModel;

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
            : base(netTcpUri, heartbeat)
        {
        }

        public event Action<JobProgressDto> JobProgressUpdated
        {
            add { callback.JobProgressUpdated += value; }
            remove { callback.JobProgressUpdated -= value; }
        }

        /// <summary>
        /// Gets the state of a specific job
        /// </summary>
        /// <param name="jobId">Job id</param>
        /// <param name="jobState">State job is in</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult<JobSummaryDto> GetJobSummary(int jobId)
        {
            Logger.Trace($"GetJobSummary() jobId:{jobId}");
            return HandleAPICall<JobSummaryDto>(e => e.GetJobSummary(jobId));
        }

        /// <summary>
        /// Gets the summary of a specific job from the id one of its child tasks
        /// </summary>
        /// <param name="taskId">Task id</param>
        /// <param name="jobSummaryData">Job summary</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult<JobSummaryDto> GetParentJobSummaryFromTaskId(int taskId)
        {
            Logger.Trace($"GetParentJobSummaryFromTaskId() taskId:{taskId}");
            return HandleAPICall<JobSummaryDto>(e => e.GetParentJobSummaryFromTaskId(taskId));
        }

        /// <summary>
        /// Gets the summary of the curent job for an agent
        /// </summary>
        /// <param name="agentId">Agent id</param>
        /// <param name="jobSummaryData">Job summary</param>
        /// <returns>ServiceOperationResult</return
        public IServiceCallResult<JobSummaryDto> GetCurrentJobSummaryForAgentId(int agentId)
        {
            Logger.Trace($"GetParentJobSummaryFromTaskId() agentId:{agentId}");
            return HandleAPICall<JobSummaryDto>(e => e.GetCurrentJobSummaryForAgentId(agentId));
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposed)
                return;

            isDisposed = true;

            base.Dispose(isDisposing);
        }

        protected override void SetInstanceContext()
        {
            context = new InstanceContext(callback);
        }

        protected override void HandleSubscriptionHeartbeat(IJobStateService channel, Guid key)
        {
            channel.SubscriptionHeartbeat(key);
        }
    }
}