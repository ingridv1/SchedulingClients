using BaseClients.Architecture;
using GAAPICommon.Architecture;
using GAAPICommon.Core.Dtos;
using SchedulingClients.Core.JobStateServiceReference;
using System;

namespace SchedulingClients.Core
{
    /// <summary>
    /// For tracking individual jobs.
    /// </summary>
    public interface IJobStateClient : ICallbackClient
    {
        /// <summary>
        /// Gets the summary for a specific job.
        /// </summary>
        /// <param name="jobId">Target job Id.</param>
        /// <returns>Job summary dto containing relevant data.</returns>
        IServiceCallResult<JobSummaryDto> GetJobSummary(int jobId);

        /// <summary>
        /// Returns the summary for a job, via the id of one of its tasks.
        /// </summary>
        /// <param name="taskId">Target task Id.</param>
        /// <returns>Job summary dto containing relevant data.</returns>
        IServiceCallResult<JobSummaryDto> GetParentJobSummaryFromTaskId(int taskId);

        /// <summary>
        /// Returns the summary for a job an agent is currently pursuing. 
        /// </summary>
        /// <param name="agentId">Target agent Id.</param>
        /// <returns>Job summary dto containing relevant data.</returns>
        IServiceCallResult<JobSummaryDto> GetCurrentJobSummaryForAgentId(int agentId);

        /// <summary>
        /// Fired whenever a job progress update is received. 
        /// </summary>
        event Action<JobProgressDto> JobProgressUpdated;
    }
}