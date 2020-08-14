using BaseClients.Core;
using GAAPICommon.Architecture;
using GAAPICommon.Core;
using GAAPICommon.Core.Dtos;
using GACore.Architecture;
using SchedulingClients.Core.JobBuilderServiceReference;
using System;
using System.Net;
using System.ServiceModel;

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
            Logger.Trace("CreateJob()");

            try
            {
                using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
                {
                    IJobBuilderService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto result = channel.CommitJob(jobId, agentId);
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
        /// Creates a new job
        /// </summary>
        /// <param name="jobData">Job data of new job instance</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult<JobDto> CreateJob()
        {
            Logger.Trace("CreateJob()");

            try
            {
                using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
                {
                    IJobBuilderService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto<JobDto> result = channel.CreateJob();
                    channelFactory.Close();

                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ServiceCallResultFactory<JobDto>.FromClientException(ex);
            }
        }

        /// <summary>
        /// Creates a new ordered list task
        /// </summary>
        /// <param name="parentTaskId">Parent list task Id</param>
        /// <param name="listTaskId">Id of new list task</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult<int> CreateOrderedListTask(int parentListTaskId)
        {
            Logger.Trace("CreateOrderedListTask({0})", parentListTaskId);

            try
            {
                using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
                {
                    IJobBuilderService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto<int> result = channel.CreateOrderedListTask(parentListTaskId);
                    channelFactory.Close();

                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ServiceCallResultFactory<int>.FromClientException(ex);
            }
        }


        /// <summary>
        /// Creates a new unordered list task
        /// </summary>
        /// <param name="parentTaskId">Parent list task Id</param>
        /// <param name="listTaskId">Id of new list task</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult<int> CreateUnorderedListTask(int parentListTaskId)
        {
            Logger.Trace("CreateUnorderedListTask({0})", parentListTaskId);

            try
            {
                using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
                {
                    IJobBuilderService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto<int> result = channel.CreateUnorderedListTask(parentListTaskId);
                    channelFactory.Close();

                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ServiceCallResultFactory<int>.FromClientException(ex);
            }
        }

        /// <summary>
        /// Creates a new atomic move list task
        /// </summary>
        /// <param name="parentTaskId">Parent list task Id</param>
        /// <param name="atomicMoveListTaskId">Id of new atomic move list task</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult<int> CreateAtomicMoveListTask(int parentListTaskId)
        {
            Logger.Trace("CreateAtomicMoveListTask({0})", parentListTaskId);

            try
            {
                using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
                {
                    IJobBuilderService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto<int> result = channel.CreateAtomicMoveListTask(parentListTaskId);
                    channelFactory.Close();

                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ServiceCallResultFactory<int>.FromClientException(ex);
            }
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
            Logger.Trace("CreateServicingTask({0},{1},{2},{3})", parentListTaskId, nodeId, serviceType, expectedDuration);

            try
            {
                using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
                {
                    IJobBuilderService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto<int> result = channel.CreateServicingTask(parentListTaskId, nodeId, serviceType, expectedDuration);
                    channelFactory.Close();

                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ServiceCallResultFactory<int>.FromClientException(ex);
            }
        }

        public IServiceCallResult<int> CreateChargeTask(int parentListTaskId, int nodeId)
        {
            Logger.Trace("CreateChargeTask({0},{1})", parentListTaskId, nodeId);

            try
            {
                using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
                {
                    IJobBuilderService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto<int> result = channel.CreateChargeTask(parentListTaskId, nodeId);
                    channelFactory.Close();

                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ServiceCallResultFactory<int>.FromClientException(ex);
            }
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
            Logger.Trace("CreateSleepingTask({0},{1},{2})", parentListTaskId, nodeId, expectedDuration);

            try
            {
                using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
                {
                    IJobBuilderService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto<int> result = channel.CreateSleepingTask(parentListTaskId, nodeId, expectedDuration);
                    channelFactory.Close();

                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ServiceCallResultFactory<int>.FromClientException(ex);
            }
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
            Logger.Trace("CreateAwaitingTask({0},{1})", parentListTaskId, nodeId);

            try
            {
                using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
                {
                    IJobBuilderService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto<int> result = channel.CreateAwaitingTask(parentListTaskId, nodeId);
                    channelFactory.Close();

                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ServiceCallResultFactory<int>.FromClientException(ex);
            }
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
            Logger.Trace("CreateGoToNodeTask({0},{1})", parentListTaskId, nodeId);

            try
            {
                using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
                {
                    IJobBuilderService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto<int> result = channel.CreateGoToNodeTask(parentListTaskId, nodeId);
                    channelFactory.Close();

                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ServiceCallResultFactory<int>.FromClientException(ex);
            }
        }

        /// <summary>
        /// Creates an atmoic move task
        /// </summary>
        /// <param name="parentAtomicMoveListTaskId">Id of parent atomic move list task</param>
        /// <param name="moveId">Id of move agent to follow</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult<int> CreateAtomicMoveTask(int parentAtomicMoveListTaskId, int moveId)
        {
            Logger.Trace("CreateAtomicMoveTask({0},{1})", parentAtomicMoveListTaskId, moveId);

            try
            {
                using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
                {
                    IJobBuilderService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto<int> result = channel.CreateAtomicMoveTask(parentAtomicMoveListTaskId, moveId);
                    channelFactory.Close();

                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ServiceCallResultFactory<int>.FromClientException(ex);
            }
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

            Logger.Trace("IssueEnumDirective({0},{1},{2})", taskId, parameterAlias, value);

            try
            {
                using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
                {
                    IJobBuilderService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto result = channel.IssueEnumDirective(taskId, parameterAlias, value);
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

            Logger.Trace("IssueShortDirective({0},{1},{2})", taskId, parameterAlias, value);

            try
            {
                using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
                {
                    IJobBuilderService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto result = channel.IssueShortDirective(taskId, parameterAlias, value);
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

            Logger.Trace("IssueUShortDirective({0},{1},{2})", taskId, parameterAlias, value);

            try
            {
                using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
                {
                    IJobBuilderService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto result = channel.IssueUShortDirective(taskId, parameterAlias, value);
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

            Logger.Trace("IssueFloatDirective({0},{1},{2})", taskId, parameterAlias, value);

            try
            {
                using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
                {
                    IJobBuilderService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto result = channel.IssueFloatDirective(taskId, parameterAlias, value);
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

            Logger.Trace("IssueIPAddressDirective({0},{1},{2})", taskId, parameterAlias, ipAddress);

            try
            {
                using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
                {
                    IJobBuilderService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto result = channel.IssueIPAddressDirective(taskId, parameterAlias, ipAddress);
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
        /// Puts a job into the editing state
        /// </summary>
        /// <param name="jobId">Id of the job to edit</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult<bool> BeginEditingJob(int jobId)
        {
            Logger.Trace("BeginEditingJob({0})", jobId);

            try
            {
                using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
                {
                    IJobBuilderService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto<bool> result = channel.BeginEditingJob(jobId);
                    channelFactory.Close();

                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ServiceCallResultFactory<bool>.FromClientException(ex);
            }
        }

        /// <summary>
        /// Puts a job in the editing state back to in progress
        /// </summary>
        /// <param name="jobId">Id of the job to finish editing</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult FinishEditingJob(int jobId)
        {
            Logger.Trace("FinishEditingJob({0})", jobId);

            try
            {
                using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
                {
                    IJobBuilderService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto result = channel.FinishEditingJob(jobId);
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
        /// Puts a job into the editing state
        /// </summary>
        /// <param name="taskId">Id of the task to edit</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult<bool> BeginEditingTask(int taskId)
        {
            Logger.Trace("BeginEditingTask({0})", taskId);

            try
            {
                using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
                {
                    IJobBuilderService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto<bool> result = channel.BeginEditingTask(taskId);
                    channelFactory.Close();

                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ServiceCallResultFactory<bool>.FromClientException(ex);
            }
        }

        /// <summary>
        /// Puts a job in the editing state back to its previous state
        /// </summary>
        /// <param name="taskId">Id of the task to finish editing</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult FinishEditingTask(int taskId)
        {
            Logger.Trace("FinishEditingTask({0})", taskId);

            try
            {
                using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
                {
                    IJobBuilderService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto result = channel.FinishEditingTask(taskId);
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
    }
}