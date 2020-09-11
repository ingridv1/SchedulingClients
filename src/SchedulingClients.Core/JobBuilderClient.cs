using BaseClients.Core;
using GAAPICommon.Architecture;
using SchedulingClients.Core.JobBuilderServiceReference;
using System;
using System.Net;

namespace SchedulingClients.Core
{
    internal class JobBuilderClient : AbstractClient<IJobBuilderService>, IJobBuilderClient
    {
        private bool isDisposed = false;

        /// <summary>
        /// Creates a new JobBuilderClient
        /// </summary>
        /// <param name="netTcpUri">net.tcp address of the job builder service</param>
        public JobBuilderClient(Uri netTcpUri)
            : base(netTcpUri)
        {
        }

        /// <summary>
        /// Commits a job
        /// </summary>
        /// <param name="jobId">Id of the job to be committed</param>
        /// <param name="success">True if succesfull</param>
        /// <param name="agentId">
        /// Agent to assign the job to. If default scheduler will handle assignment
        /// </param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult CommitJob(int jobId, int agentId = -1)
        {
            Logger.Trace($"CommitJob() jobId:{jobId} agentId:{agentId}");
            return HandleAPICall(e => e.CommitJob(jobId, agentId));
        }

        /// <summary>
        /// Creates a new job
        /// </summary>
        /// <param name="jobData">Job data of new job instance</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult<JobDto> CreateJob()
        {
            Logger.Trace("CreateJob()");
            return HandleAPICall<JobDto>(e => e.CreateJob());
        }

        /// <summary>
        /// Creates a new ordered list task
        /// </summary>
        /// <param name="parentTaskId">Parent list task Id</param>
        /// <param name="listTaskId">Id of new list task</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult<int> CreateOrderedListTask(int parentListTaskId)
        {
            Logger.Trace($"CreateOrderedListTask() parentListTaskId:{parentListTaskId}");
            return HandleAPICall<int>(e => e.CreateOrderedListTask(parentListTaskId));
        }

        /// <summary>
        /// Creates a new unordered list task
        /// </summary>
        /// <param name="parentTaskId">Parent list task Id</param>
        /// <param name="listTaskId">Id of new list task</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult<int> CreateUnorderedListTask(int parentListTaskId)
        {
            Logger.Trace($"CreateUnorderedListTask() parentListTaskId:{parentListTaskId}");
            return HandleAPICall<int>(e => e.CreateUnorderedListTask(parentListTaskId));
        }

        /// <summary>
        /// Creates a new atomic move list task
        /// </summary>
        /// <param name="parentTaskId">Parent list task Id</param>
        /// <param name="atomicMoveListTaskId">Id of new atomic move list task</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult<int> CreateAtomicMoveListTask(int parentListTaskId)
        {
            Logger.Trace($"CreateAtomicMoveListTask() parentListTaskId:{parentListTaskId}");
            return HandleAPICall<int>(e => e.CreateAtomicMoveListTask(parentListTaskId));
        }

        /// <summary>
        /// Creates a new servicing task
        /// </summary>
        /// <param name="parentListTaskId">Id of parent list task</param>
        /// <param name="nodeId">Id of node for service to be carried out</param>
        /// <param name="serviceType">Service type to be carried out</param>
        /// <param name="serviceTaskId">Id of newly created servicing task</param>
        /// <param name="expectedDuration">Expected duration of the task</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult<int> CreateServicingTask(int parentListTaskId, int nodeId, ServiceType serviceType, TimeSpan expectedDuration = default)
        {
            Logger.Trace($"CreateServicingTask() parentListTaskId:{parentListTaskId} nodeId:{nodeId} serviceType:{serviceType} expectedDuration:{expectedDuration}");
            return HandleAPICall<int>(e => e.CreateServicingTask(parentListTaskId, nodeId, serviceType, expectedDuration));
        }

        public IServiceCallResult<int> CreateChargeTask(int parentListTaskId, int nodeId)
        {
            Logger.Trace($"CreateChargeTask() parentListTaskId:{parentListTaskId} nodeId:{nodeId}");
            return HandleAPICall<int>(e => e.CreateChargeTask(parentListTaskId, nodeId));
        }

        /// <summary>
        /// Creates a new sleeping task
        /// </summary>
        /// <param name="parentListTaskId">Id of parent list task</param>
        /// <param name="nodeId">Id of node for service to be carried out</param>
        /// <param name="sleepingTaskId">Id of newly created sleeping task</param>
        /// <param name="expectedDuration">Expected duration of the task</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult<int> CreateSleepingTask(int parentListTaskId, int nodeId, TimeSpan expectedDuration = default)
        {
            Logger.Trace($"CreateSleepingTask() parentListTaskId:{parentListTaskId} nodeId:{nodeId} expectedDuration:{expectedDuration}");
            return HandleAPICall<int>(e => e.CreateSleepingTask(parentListTaskId, nodeId, expectedDuration));
        }

        /// <summary>
        /// Creates a new await task
        /// </summary>
        /// <param name="parentListTaskId">Id of parent list task</param>
        /// <param name="nodeId">Id of node for await to be carried out</param>
        /// <param name="awaitTaskId">Id of newly created await task</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult<int> CreateAwaitingTask(int parentListTaskId, int nodeId)
        {
            Logger.Trace($"CreateAwaitingTask() parentListTaskId:{parentListTaskId} nodeId:{nodeId})");
            return HandleAPICall<int>(e => e.CreateAwaitingTask(parentListTaskId, nodeId));
        }

        /// <summary>
        /// Creates a task to send an agent to a node
        /// </summary>
        /// <param name="parentListTaskId">Id of parent list task</param>
        /// <param name="nodeId">Id of node to move agent to</param>
        /// <param name="nodeTaskId">Id of newly created goto node task</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult<int> CreateGoToNodeTask(int parentListTaskId, int nodeId)
        {
            Logger.Trace($"CreateGoToNodeTask() parentListTaskId:{parentListTaskId} nodeId:{nodeId}");
            return HandleAPICall<int>(e => e.CreateGoToNodeTask(parentListTaskId, nodeId));
        }

        /// <summary>
        /// Creates an atmoic move task
        /// </summary>
        /// <param name="parentAtomicMoveListTaskId">Id of parent atomic move list task</param>
        /// <param name="moveId">Id of move agent to follow</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult<int> CreateAtomicMoveTask(int parentAtomicMoveListTaskId, int moveId)
        {
            Logger.Trace($"CreateAtomicMoveTask() parentAtomicMoveListTaskId:{parentAtomicMoveListTaskId} moveId:{moveId}");
            return HandleAPICall<int>(e => e.CreateAtomicMoveTask(parentAtomicMoveListTaskId, moveId));
        }

        /// <summary>
        /// Issues a new directive
        /// </summary>
        /// <param name="taskId">Id of task directive is for</param>
        /// <param name="parameterAlias">Alias of parameter directive is for</param>
        /// <param name="value">Value assigned to directive</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult IssueEnumDirective(int taskId, string parameterAlias, byte value)
        {
            if (string.IsNullOrEmpty(parameterAlias))
                throw new ArgumentOutOfRangeException("parameterAlias");

            Logger.Trace($"IssueEnumDirective() taskId:{taskId} parameterAlias:{parameterAlias} value:{value}");
            return HandleAPICall(e => e.IssueEnumDirective(taskId, parameterAlias, value));
        }

        /// <summary>
        /// Issues a new short directive
        /// </summary>
        /// <param name="taskId">Id of task directive is for</param>
        /// <param name="parameterAlias">Alias of parameter directive is for</param>
        /// <param name="value">Value assigned to directive</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult IssueShortDirective(int taskId, string parameterAlias, short value)
        {
            if (string.IsNullOrEmpty(parameterAlias))
                throw new ArgumentOutOfRangeException("parameterAlias");

            Logger.Trace($"IssueShortDirective() taskId:{taskId} parameterAlias:{parameterAlias} value:{value}");
            return HandleAPICall(e => e.IssueShortDirective(taskId, parameterAlias, value));
        }

        /// <summary>
        /// Issues a new ushort directive
        /// </summary>
        /// <param name="taskId">Id of task directive is for</param>
        /// <param name="parameterAlias">Alias of parameter directive is for</param>
        /// <param name="value">Value assigned to directive</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult IssueUShortDirective(int taskId, string parameterAlias, ushort value)
        {
            if (string.IsNullOrEmpty(parameterAlias))
                throw new ArgumentOutOfRangeException("parameterAlias");

            Logger.Trace($"IssueUShortDirective() taskId:{taskId} parameterAlias:{parameterAlias} value:{value}");
            return HandleAPICall(e => e.IssueUShortDirective(taskId, parameterAlias, value));
        }

        /// <summary>
        /// Issues a new float directive
        /// </summary>
        /// <param name="taskId">Id of task directive is for</param>
        /// <param name="parameterAlias">Alias of parameter directive is for</param>
        /// <param name="value">Value assigned to directive</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult IssueFloatDirective(int taskId, string parameterAlias, float value)
        {
            if (string.IsNullOrEmpty(parameterAlias))
                throw new ArgumentOutOfRangeException("parameterAlias");

            Logger.Trace($"IssueFloatDirective() taskId:{taskId} parameterAlias:{parameterAlias} value:{value}");
            return HandleAPICall(e => e.IssueFloatDirective(taskId, parameterAlias, value));
        }

        /// <summary>
        /// Issues a new directive
        /// </summary>
        /// <param name="taskId">Id of task directive is for</param>
        /// <param name="parameterAlias">Alias of parameter directive is for</param>
        /// <param name="value">Value assigned to directive</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult IssueIPAddressDirective(int taskId, string parameterAlias, IPAddress ipAddress)
        {
            if (string.IsNullOrEmpty(parameterAlias))
                throw new ArgumentOutOfRangeException("parameterAlias");

            if (ipAddress == null)
                throw new ArgumentNullException("ipAddress");

            Logger.Trace($"IssueIPAddressDirective() taskId:{taskId} parameterAlias:{parameterAlias} ipAddress:{ipAddress}");
            return HandleAPICall(e => e.IssueIPAddressDirective(taskId, parameterAlias, ipAddress));
        }

        /// <summary>
        /// Puts a job into the editing state
        /// </summary>
        /// <param name="jobId">Id of the job to edit</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult<bool> BeginEditingJob(int jobId)
        {
            Logger.Trace($"BeginEditingJob() jobId:{jobId}");
            return HandleAPICall<bool>(e => e.BeginEditingJob(jobId));
        }

        /// <summary>
        /// Puts a job in the editing state back to in progress
        /// </summary>
        /// <param name="jobId">Id of the job to finish editing</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult FinishEditingJob(int jobId)
        {
            Logger.Trace($"FinishEditingJob() jobId:{jobId}");
            return HandleAPICall(e => e.FinishEditingJob(jobId));
        }

        /// <summary>
        /// Puts a job into the editing state
        /// </summary>
        /// <param name="taskId">Id of the task to edit</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult<bool> BeginEditingTask(int taskId)
        {
            Logger.Trace($"BeginEditingTask() taskId:{taskId}");
            return HandleAPICall<bool>(e => e.BeginEditingTask(taskId));
        }

        /// <summary>
        /// Puts a job in the editing state back to its previous state
        /// </summary>
        /// <param name="taskId">Id of the task to finish editing</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult FinishEditingTask(int taskId)
        {
            Logger.Trace($"FinishEditingTask() taskId:{taskId}");
            return HandleAPICall(e => e.FinishEditingTask(taskId));
        }
    }
}