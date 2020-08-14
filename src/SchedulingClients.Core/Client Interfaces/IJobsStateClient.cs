using BaseClients.Architecture;
using GAAPICommon.Architecture;
using SchedulingClients.Core.JobsStateServiceReference;
using System;

namespace SchedulingClients.Core
{
    public interface IJobsStateClient : ICallbackClient
    {
        IServiceCallResult AbortAllJobs();

        IServiceCallResult AbortAllJobsForAgent(int agentId);

        IServiceCallResult AbortJob(int jobId, string note);

        IServiceCallResult AbortTask(int taskId);

        IServiceCallResult<int[]> GetActiveJobIdsForAgent(int agentId);

        JobsStateDto JobsStateDto { get; }

        event Action<JobsStateDto> JobsStateUpdated;
    }
}
