using SchedulingClients.JobBuilderServiceReference;
using System;
using System.Net;
using System.ServiceModel;
using BaseClients;
using GACore.Architecture;

namespace SchedulingClients
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
        public ServiceOperationResult TryCommit(int jobId, out bool success, int agentId = -1)
        {
            Logger.Info("TryCommit({0},{1})", jobId, agentId);

            try
            {
                var result = HandleCommit(jobId, agentId);
                success = result.Item1;
                return ServiceOperationResultFactory.FromJobBuilderServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                success = false;
                return HandleClientException(ex);
            }
        }

        /// <summary>
        /// Creates a new job
        /// </summary>
        /// <param name="jobData">Job data of new job instance</param>
        /// <returns>ServiceOperationResult</returns>
        public ServiceOperationResult TryCreateJob(out JobData jobData)
        {
            Logger.Info("TryCreateJob()");

            try
            {
                var result = HandleCreateJob();
                jobData = result.Item1;
                return ServiceOperationResultFactory.FromJobBuilderServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                jobData = new JobData() { JobId = -1 };
                return HandleClientException(ex);
            }
        }

        /// <summary>
        /// Creates a new ordered list task
        /// </summary>
        /// <param name="parentTaskId">Parent list task Id</param>
        /// <param name="listTaskId">Id of new list task</param>
        /// <returns>ServiceOperationResult</returns>
        public ServiceOperationResult TryCreateOrderedListTask(int parentTaskId, out int listTaskId)
        {
            Logger.Info("TryCreateOrderedListTask({0})", parentTaskId);

            try
            {
                var result = HandleCreateOrderedListTask(parentTaskId);
                listTaskId = result.Item1;
                return ServiceOperationResultFactory.FromJobBuilderServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                listTaskId = -1;
                return HandleClientException(ex);
            }
        }

        /// <summary>
        /// Creates a new unordered list task
        /// </summary>
        /// <param name="parentTaskId">Parent list task Id</param>
        /// <param name="listTaskId">Id of new list task</param>
        /// <returns>ServiceOperationResult</returns>
        public ServiceOperationResult TryCreateUnorderedListTask(int parentTaskId, out int listTaskId)
        {
            Logger.Info("TryCreateUnorderedListTask({0})", parentTaskId);

            try
            {
                var result = HandleCreateUnorderedListTask(parentTaskId);
                listTaskId = result.Item1;
                return ServiceOperationResultFactory.FromJobBuilderServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                listTaskId = -1;
                return HandleClientException(ex);
            }
        }

        /// <summary>
        /// Creates a new atomic move list task
        /// </summary>
        /// <param name="parentTaskId">Parent list task Id</param>
        /// <param name="atomicMoveListTaskId">Id of new atomic move list task</param>
        /// <returns>ServiceOperationResult</returns>
        public ServiceOperationResult TryCreateAtomicMoveListTask(int parentTaskId, out int atomicMoveListTaskId)
        {
            Logger.Info("TryCreateAtomicMoveListTask({0})", parentTaskId);

            try
            {
                var result = HandleCreateAtomicMoveListTask(parentTaskId);
                atomicMoveListTaskId = result.Item1;
                return ServiceOperationResultFactory.FromJobBuilderServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                atomicMoveListTaskId = -1;
                return HandleClientException(ex);
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
        public ServiceOperationResult TryCreateServicingTask(int parentListTaskId, int nodeId, ServiceType serviceType, out int serviceTaskId, TimeSpan expectedDuration = default(TimeSpan))
        {
            Logger.Info("TryCreateServicingTask({0},{1})", parentListTaskId, nodeId);

            try
            {
                var result = HandleCreateServicingTask(parentListTaskId, nodeId, serviceType, expectedDuration);
                serviceTaskId = result.Item1;
                return ServiceOperationResultFactory.FromJobBuilderServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                serviceTaskId = -1;
                return HandleClientException(ex);
            }
        }

		public ServiceOperationResult TryCreateChargeTask(int parentListTaskId, int nodeId, out int chargeTaskId)
		{
			Logger.Info($"TryCreateCharge({parentListTaskId}, {nodeId})");

			try
			{
				var result = HandleCreateChargeTask(parentListTaskId, nodeId);
				chargeTaskId = result.Item1;
				return ServiceOperationResultFactory.FromJobBuilderServiceCallData(result.Item2);
			}
			catch (Exception ex)
			{
				chargeTaskId = -1;
				return HandleClientException(ex);
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
        public ServiceOperationResult TryCreateSleepingTask(int parentListTaskId, int nodeId, out int sleepingTaskId, TimeSpan expectedDuration = default(TimeSpan))
        {
            Logger.Info("TryCreateNodeTask({0},{1})", parentListTaskId, nodeId);

            if (expectedDuration == TimeSpan.Zero)
            {
                expectedDuration = TimeSpan.FromSeconds(1);
            }

            try
            {
                var result = HandleCreateSleepingTask(parentListTaskId, nodeId, expectedDuration);
                sleepingTaskId = result.Item1;
                return ServiceOperationResultFactory.FromJobBuilderServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                sleepingTaskId = -1;
                return HandleClientException(ex);
            }
        }


        /// <summary>
        /// Creates a new await task
        /// </summary>
        /// <param name="parentListTaskId">Id of parent list task</param>
        /// <param name="nodeId">Id of node for await to be carried out</param>
        /// <param name="awaitTaskId">Id of newly created await task</param>
        /// <returns>ServiceOperationResult</returns>
        public ServiceOperationResult TryCreateAwaitingTask(int parentListTaskId, int nodeId, out int awaitTaskId)
        {
            Logger.Info("TryCreateAwaitTask({0},{1})", parentListTaskId, nodeId);

            try
            {
                var result = HandleCreateAwaitingTask(parentListTaskId, nodeId);
                awaitTaskId = result.Item1;
                return ServiceOperationResultFactory.FromJobBuilderServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                awaitTaskId = -1;
                return HandleClientException(ex);
            }
        }

        /// <summary>
        /// Creates a task to send an agent to a node
        /// </summary>
        /// <param name="parentListTaskId">Id of parent list task</param>
        /// <param name="nodeId">Id of node to move agent to</param>
        /// <param name="nodeTaskId">Id of newly created goto node task</param>
        /// <returns>ServiceOperationResult</returns>
        public ServiceOperationResult TryCreateGoToNodeTask(int parentListTaskId, int nodeId, out int nodeTaskId)
        {
            Logger.Info("TryCreateMoveTask({0},{1})", parentListTaskId, nodeId);

            try
            {
                var result = HandleCreateGoToNodeTask(parentListTaskId, nodeId);
                nodeTaskId = result.Item1;
                return ServiceOperationResultFactory.FromJobBuilderServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                nodeTaskId = -1;
                return HandleClientException(ex);
            }
        }

        /// <summary>
        /// Creates an atmoic move task
        /// </summary>
        /// <param name="parentAtomicMoveListTaskId">Id of parent atomic move list task</param>
        /// <param name="moveId">Id of move agent to follow</param>
        /// <param name="atomicMoveTaskId">Id of newly created atomic move task</param>
        /// <returns>ServiceOperationResult</returns>
        public ServiceOperationResult TryCreateAtomicMoveTask(int parentAtomicMoveListTaskId, int moveId, out int atomicMoveTaskId)
        {
            Logger.Info("TryHandleCreateAtomicMoveTask({0},{1})", parentAtomicMoveListTaskId, moveId);

            try
            {
                var result = HandleCreateAtomicMoveTask(parentAtomicMoveListTaskId, moveId);
                atomicMoveTaskId = result.Item1;
                return ServiceOperationResultFactory.FromJobBuilderServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                atomicMoveTaskId = -1;
                return HandleClientException(ex);
            }
        }

        

        /// <summary>
        /// Issues a new directive
        /// </summary>
        /// <param name="taskId">Id of task directive is for</param>
        /// <param name="parameterAlias">Alias of parameter directive is for</param>
        /// <param name="value">Value assigned to directive</param>
        /// <returns>ServiceOperationResult</returns>
        public ServiceOperationResult TryIssueDirective(int taskId, string parameterAlias, byte value)
        {
            Logger.Info("TryIssueDirective({0},{1},{2})", taskId, parameterAlias, value);

            try
            {
                var result = HandleIssueDirective(taskId, parameterAlias, value);
                return ServiceOperationResultFactory.FromJobBuilderServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                return HandleClientException(ex);
            }
        }

        /// <summary>
        /// Issues a new directive
        /// </summary>
        /// <param name="taskId">Id of task directive is for</param>
        /// <param name="parameterAlias">Alias of parameter directive is for</param>
        /// <param name="value">Value assigned to directive</param>
        /// <returns>ServiceOperationResult</returns>
        public ServiceOperationResult TryIssueDirective(int taskId, string parameterAlias, short value)
        {
            Logger.Info("TryIssueDirective({0},{1},{2})", taskId, parameterAlias, value);

            try
            {
                var result = HandleIssueDirective(taskId, parameterAlias, value);
                return ServiceOperationResultFactory.FromJobBuilderServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                return HandleClientException(ex);
            }
        }

        /// <summary>
        /// Issues a new directive
        /// </summary>
        /// <param name="taskId">Id of task directive is for</param>
        /// <param name="parameterAlias">Alias of parameter directive is for</param>
        /// <param name="value">Value assigned to directive</param>
        /// <returns>ServiceOperationResult</returns>
        public ServiceOperationResult TryIssueDirective(int taskId, string parameterAlias, ushort value)
        {
            Logger.Info("TryIssueDirective({0},{1},{2})", taskId, parameterAlias, value);

            try
            {
                var result = HandleIssueDirective(taskId, parameterAlias, value);
                return ServiceOperationResultFactory.FromJobBuilderServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                return HandleClientException(ex);
            }
        }

        /// <summary>
        /// Issues a new directive
        /// </summary>
        /// <param name="taskId">Id of task directive is for</param>
        /// <param name="parameterAlias">Alias of parameter directive is for</param>
        /// <param name="value">Value assigned to directive</param>
        /// <returns>ServiceOperationResult</returns>
        public ServiceOperationResult TryIssueDirective(int taskId, string parameterAlias, float value)
        {
            Logger.Info("TryIssueDirective({0},{1},{2})", taskId, parameterAlias, value);

            try
            {
                var result = HandleIssueDirective(taskId, parameterAlias, value);
                return ServiceOperationResultFactory.FromJobBuilderServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                return HandleClientException(ex);
            }
        }

        /// <summary>
        /// Issues a new directive
        /// </summary>
        /// <param name="taskId">Id of task directive is for</param>
        /// <param name="parameterAlias">Alias of parameter directive is for</param>
        /// <param name="value">Value assigned to directive</param>
        /// <returns>ServiceOperationResult</returns>
        public ServiceOperationResult TryIssueDirective(int taskId, string parameterAlias, IPAddress value)
        {
            Logger.Info("TryIssueDirective({0},{1},{2})", taskId, parameterAlias, value);

            try
            {
                var result = HandleIssueDirective(taskId, parameterAlias, value);
                return ServiceOperationResultFactory.FromJobBuilderServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                return HandleClientException(ex);
            }
        }

        /// <summary>
        /// Puts a job into the editing state
        /// </summary>
        /// <param name="jobId">Id of the job to edit</param>
        /// <returns>ServiceOperationResult</returns>
        public ServiceOperationResult TryBeginEditingJob(int jobId)
        {
            Logger.Info("TryFinaliseTask({0})", jobId);

            try
            {
                var result = HandleBeginEditingJob(jobId);
                return ServiceOperationResultFactory.FromJobBuilderServiceCallData(result);
            }
            catch (Exception ex)
            {
                return HandleClientException(ex);
            }
        }

        /// <summary>
        /// Puts a job in the editing state back to in progress
        /// </summary>
        /// <param name="jobId">Id of the job to finish editing</param>
        /// <returns>ServiceOperationResult</returns>
        public ServiceOperationResult TryFinishEditingJob(int jobId)
        {
            Logger.Info("TryFinaliseTask({0})", jobId);

            try
            {
                var result = HandleFinishEditingJob(jobId);
                return ServiceOperationResultFactory.FromJobBuilderServiceCallData(result);
            }
            catch (Exception ex)
            {
                return HandleClientException(ex);
            }
        }

        /// <summary>
        /// Puts a job into the editing state
        /// </summary>
        /// <param name="taskId">Id of the task to edit</param>
        /// <returns>ServiceOperationResult</returns>
        public ServiceOperationResult TryBeginEditingTask(int taskId)
        {
            Logger.Info("TryFinaliseTask({0})", taskId);

            try
            {
                var result = HandleBeginEditingTask(taskId);
                return ServiceOperationResultFactory.FromJobBuilderServiceCallData(result);
            }
            catch (Exception ex)
            {
                return HandleClientException(ex);
            }
        }

        /// <summary>
        /// Puts a job in the editing state back to its previous state
        /// </summary>
        /// <param name="taskId">Id of the task to finish editing</param>
        /// <returns>ServiceOperationResult</returns>
        public ServiceOperationResult TryFinishEditingTask(int taskId)
        {
            Logger.Info("TryFinaliseTask({0})", taskId);

            try
            {
                var result = HandleFinishEditingTask(taskId);
                return ServiceOperationResultFactory.FromJobBuilderServiceCallData(result);
            }
            catch (Exception ex)
            {
                return HandleClientException(ex);
            }
        }

        private Tuple<bool, ServiceCallData> HandleCommit(int jobId, int agentId = -1)
        {
            Logger.Debug("Commit({0},{1})", jobId, agentId);

            if (isDisposed)
            {
                throw new ObjectDisposedException("JobBuilderClient");
            }

            Tuple<bool, ServiceCallData> result;

            using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
            {
                IJobBuilderService channel = channelFactory.CreateChannel();
                result = channel.CommitJob(jobId, agentId);
                channelFactory.Close();
            }

            return result;
        }

        private Tuple<JobData, ServiceCallData> HandleCreateJob()
        {
            Logger.Debug("CreateJob()");

            if (isDisposed)
            {
                throw new ObjectDisposedException("JobBuilderClient");
            }

            Tuple<JobData, ServiceCallData> result;

            EndpointAddress addy = this.EndpointAddress;

            using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
            {
                IJobBuilderService channel = channelFactory.CreateChannel();
                result = channel.CreateJob();
                channelFactory.Close();
            }

            return result;
        }

        private Tuple<int, ServiceCallData> HandleCreateUnorderedListTask(int parentTaskId)
        {
            Logger.Debug("CreateListTask({0})", parentTaskId);

            if (isDisposed)
            {
                throw new ObjectDisposedException("JobBuilderClient");
            }

            Tuple<int, ServiceCallData> result;

            using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
            {
                IJobBuilderService channel = channelFactory.CreateChannel();
                result = channel.CreateUnorderedListTask(parentTaskId);
                channelFactory.Close();
            }

            return result;
        }

        private Tuple<int, ServiceCallData> HandleCreateOrderedListTask(int parentTaskId)
        {
            Logger.Debug("HandleCreateOrderedListTask({0})", parentTaskId);

            if (isDisposed) throw new ObjectDisposedException("JobBuilderClient");

            Tuple<int, ServiceCallData> result;

            using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
            {
                IJobBuilderService channel = channelFactory.CreateChannel();
                result = channel.CreateOrderedListTask(parentTaskId);
                channelFactory.Close();
            }

            return result;
        }

        private Tuple<int, ServiceCallData> HandleCreateAtomicMoveListTask(int parentTaskId)
        {
            Logger.Debug("CreateListTask({0})", parentTaskId);

            if (isDisposed) throw new ObjectDisposedException("JobBuilderClient");

            Tuple<int, ServiceCallData> result;

            using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
            {
                IJobBuilderService channel = channelFactory.CreateChannel();
                result = channel.CreateAtomicMoveListTask(parentTaskId);
                channelFactory.Close();
            }

            return result;
        }

        private Tuple<int, ServiceCallData> HandleCreateAtomicMoveTask(int parentAtomicListTaskId, int moveId)
        {
            Logger.Debug("HandleCreateAtomicMoveTask parentAtomicListTaskId:{0}, moveId:{1}", parentAtomicListTaskId, moveId);

            if (isDisposed) throw new ObjectDisposedException("JobBuilderClient");

            Tuple<int, ServiceCallData> result;

            using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
            {
                IJobBuilderService channel = channelFactory.CreateChannel();
                result = channel.CreateAtomicMoveTask(parentAtomicListTaskId, moveId);
                channelFactory.Close();
            }

            return result;
        }


        private Tuple<int, ServiceCallData> HandleCreateServicingTask(int parentTaskId, int nodeId, ServiceType serviceType, TimeSpan expectedDuration)
        {
            Logger.Debug("CreateServicingTask({0},{1},{2},{3})", parentTaskId, nodeId, serviceType, expectedDuration);

            if (isDisposed)
            {
                throw new ObjectDisposedException("JobBuilderClient");
            }

            Tuple<int, ServiceCallData> result;

            using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
            {
                IJobBuilderService channel = channelFactory.CreateChannel();
                result = channel.CreateServicingTask(parentTaskId, nodeId, serviceType, expectedDuration);
                channelFactory.Close();
            }

            return result;
        }

		private Tuple<int, ServiceCallData> HandleCreateChargeTask(int parentTaskId, int nodeId)
		{
			Logger.Debug($"CreateChargeTask({parentTaskId},{nodeId})");

			if (isDisposed)
			{
				throw new ObjectDisposedException("JobBuilderClient");
			}

			Tuple<int, ServiceCallData> result;

			using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
			{
				IJobBuilderService channel = channelFactory.CreateChannel();
				result = channel.CreateChargeTask(parentTaskId, nodeId);
				channelFactory.Close();
			}

			return result;
		}

        private Tuple<int, ServiceCallData> HandleCreateSleepingTask(int parentTaskId, int nodeId, TimeSpan expectedDuration)
        {
            Logger.Debug("CreateSleepingTask({0},{1},{2})", parentTaskId, nodeId, expectedDuration);

            if (isDisposed)
            {
                throw new ObjectDisposedException("JobBuilderClient");
            }

            Tuple<int, ServiceCallData> result;

            using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
            {
                IJobBuilderService channel = channelFactory.CreateChannel();
                result = channel.CreateSleepingTask(parentTaskId, nodeId, expectedDuration);
                channelFactory.Close();
            }

            return result;
        }

        private Tuple<int, ServiceCallData> HandleCreateAwaitingTask(int parentTaskId, int nodeId)
        {
            Logger.Debug("CreateAwaitingTask({0},{1})", parentTaskId, nodeId);

            if (isDisposed)
            {
                throw new ObjectDisposedException("JobBuilderClient");
            }

            Tuple<int, ServiceCallData> result;

            using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
            {
                IJobBuilderService channel = channelFactory.CreateChannel();
                result = channel.CreateAwaitingTask(parentTaskId, nodeId);
                channelFactory.Close();
            }

            return result;
        }

        private Tuple<int, ServiceCallData> HandleCreateGoToNodeTask(int parentTaskId, int nodeId)
        {
            Logger.Debug("HandleCreateGoToNodeTask({0},{1})", parentTaskId, nodeId);

            if (isDisposed) throw new ObjectDisposedException("JobBuilderClient");
    
            Tuple<int, ServiceCallData> result;

            using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
            {
                IJobBuilderService channel = channelFactory.CreateChannel();
                result = channel.CreateGoToNodeTask(parentTaskId, nodeId);
                channelFactory.Close();
            }

            return result;
        }

        private Tuple<bool, ServiceCallData> HandleIssueDirective(int taskId, string parameterAlias, byte value)
        {
            Logger.Debug("IssueDirective({0},{1},{2})", taskId, parameterAlias, value);

            if (isDisposed)
            {
                throw new ObjectDisposedException("JobBuilderClient");
            }

            Tuple<bool, ServiceCallData> result;

            using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
            {
                IJobBuilderService channel = channelFactory.CreateChannel();
                result = channel.IssueEnumDirective(taskId, parameterAlias, value);
                channelFactory.Close();
            }

            return result;
        }

        private Tuple<bool, ServiceCallData> HandleIssueDirective(int taskId, string parameterAlias, short value)
        {
            Logger.Debug("IssueDirective({0},{1},{2})", taskId, parameterAlias, value);

            if (isDisposed)
            {
                throw new ObjectDisposedException("JobBuilderClient");
            }

            Tuple<bool, ServiceCallData> result;

            using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
            {
                IJobBuilderService channel = channelFactory.CreateChannel();
                result = channel.IssueShortDirective(taskId, parameterAlias, value);
                channelFactory.Close();
            }

            return result;
        }

        private Tuple<bool, ServiceCallData> HandleIssueDirective(int taskId, string parameterAlias, ushort value)
        {
            Logger.Debug("IssueDirective({0},{1},{2})", taskId, parameterAlias, value);

            if (isDisposed)
            {
                throw new ObjectDisposedException("JobBuilderClient");
            }

            Tuple<bool, ServiceCallData> result;

            using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
            {
                IJobBuilderService channel = channelFactory.CreateChannel();
                result = channel.IssueUShortDirective(taskId, parameterAlias, value);
                channelFactory.Close();
            }

            return result;
        }

        private Tuple<bool, ServiceCallData> HandleIssueDirective(int taskId, string parameterAlias, float value)
        {
            Logger.Debug("IssueDirective({0},{1},{2})", taskId, parameterAlias, value);

            if (isDisposed)
            {
                throw new ObjectDisposedException("JobBuilderClient");
            }

            Tuple<bool, ServiceCallData> result;

            using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
            {
                IJobBuilderService channel = channelFactory.CreateChannel();
                result = channel.IssueFloatDirective(taskId, parameterAlias, value);
                channelFactory.Close();
            }

            return result;
        }

        private Tuple<bool, ServiceCallData> HandleIssueDirective(int taskId, string parameterAlias, IPAddress value)
        {
            Logger.Debug("IssueDirective({0},{1},{2})", taskId, parameterAlias, value);

            if (isDisposed)
            {
                throw new ObjectDisposedException("JobBuilderClient");
            }

            Tuple<bool, ServiceCallData> result;

            using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
            {
                IJobBuilderService channel = channelFactory.CreateChannel();
                result = channel.IssueIPAddressDirective(taskId, parameterAlias, value);
                channelFactory.Close();
            }

            return result;
        }

        private ServiceCallData HandleBeginEditingJob(int jobId)
        {
            Logger.Debug("BeginEditingJob({0})", jobId);

            if (isDisposed)
            {
                throw new ObjectDisposedException("JobBuilderClient");
            }

            ServiceCallData result;

            using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
            {
                IJobBuilderService channel = channelFactory.CreateChannel();
                result = channel.BeginEditingJob(jobId);
                channelFactory.Close();
            }

            return result;
        }

        private ServiceCallData HandleFinishEditingJob(int jobId)
        {
            Logger.Debug("FinishEditingJob({0})", jobId);

            if (isDisposed)
            {
                throw new ObjectDisposedException("JobBuilderClient");
            }

            ServiceCallData result;

            using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
            {
                IJobBuilderService channel = channelFactory.CreateChannel();
                result = channel.FinishEditingJob(jobId);
                channelFactory.Close();
            }

            return result;
        }

        private ServiceCallData HandleBeginEditingTask(int taskId)
        {
            Logger.Debug("BeginEditingTask({0})", taskId);

            if (isDisposed)
            {
                throw new ObjectDisposedException("JobBuilderClient");
            }

            ServiceCallData result;

            using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
            {
                IJobBuilderService channel = channelFactory.CreateChannel();
                result = channel.BeginEditingTask(taskId);
                channelFactory.Close();
            }

            return result;
        }

        private ServiceCallData HandleFinishEditingTask(int taskId)
        {
            Logger.Debug("FinishEditingTask({0})", taskId);

            if (isDisposed)
            {
                throw new ObjectDisposedException("JobBuilderClient");
            }

            ServiceCallData result;

            using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
            {
                IJobBuilderService channel = channelFactory.CreateChannel();
                result = channel.FinishEditingTask(taskId);
                channelFactory.Close();
            }

            return result;
        }
    }
}