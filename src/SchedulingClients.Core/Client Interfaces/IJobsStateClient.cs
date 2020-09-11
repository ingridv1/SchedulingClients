using BaseClients.Architecture;
using GAAPICommon.Architecture;
using SchedulingClients.Core.JobsStateServiceReference;
using System;

namespace SchedulingClients.Core
{
    /// <summary>
    /// For aborting jobs and monitoring the state of all jobs in the system.
    /// </summary>
    public interface IJobsStateClient : ICallbackClient
    {
        /// <summary>
        /// Aborts all jobs in the system.
        /// </summary>
        /// <returns>Successful service call result on success.</returns>
        IServiceCallResult AbortAllJobs();

        /// <summary>
        /// Aborts all jobs for a specific agent.
        /// </summary>
        /// <param name="agentId">Target agent Id.</param>
        /// <returns>Successful service call result on success.</returns>
        IServiceCallResult AbortAllJobsForAgent(int agentId);

        /// <summary>
        /// Aborts a specific job.
        /// </summary>
        /// <param name="jobId">Target job Id.</param>
        /// <param name="note">Reason for abortion.</param>
        /// <returns>Successful service call result on success.</returns>
        IServiceCallResult AbortJob(int jobId, string note);

        /// <summary>
        /// Aborts a specific task.
        /// </summary>
        /// <param name="taskId">Target task Id.</param>
        /// <returns>Successful service call result on success.</returns>
        IServiceCallResult AbortTask(int taskId);

        /// <summary>
        /// Gets the active job Ids for a specific agent.
        /// </summary>
        /// <param name="agentId">Target agent Id.</param>
        /// <returns>Array of active job Ids.</returns>
        IServiceCallResult<int[]> GetActiveJobIdsForAgent(int agentId);

        /// <summary>
        /// A summary of the current state of all jobs in the system.
        /// </summary>
        JobsStateDto JobsState { get; }

        /// <summary>
        /// Fired whenever the jobs state summary is updated.
        /// </summary>
        event Action<JobsStateDto> JobsStateUpdated;
    }
}