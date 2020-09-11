using BaseClients.Architecture;
using GAAPICommon.Architecture;
using SchedulingClients.Core.JobStateServiceReference;
using System;

namespace SchedulingClients.Core
{
    public interface IJobStateClient : ICallbackClient
    {
        IServiceCallResult<JobSummaryDto> GetJobSummary(int jobId);

        IServiceCallResult<JobSummaryDto> GetParentJobSummaryFromTaskId(int taskId);

        IServiceCallResult<JobSummaryDto> GetCurrentJobSummaryForAgentId(int agentId);

        event Action<JobProgressDto> JobProgressUpdated;
    }
}