using SchedulingClients.JobBuilderServiceReference;
using System;
using System.ServiceModel;

namespace SchedulingClients
{
    public class JobBuilderClient : AbstractClient<IJobBuilderService>
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
                var result = Commit(jobId, agentId);
                success = result.Item1;
                return ServiceOperationResult.FromServiceCallData(result.Item2);
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
                var result = CreateJob();
                jobData = result.Item1;
                return ServiceOperationResult.FromServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                jobData = new JobData() { JobId = -1 };
                return HandleClientException(ex);
            }
        }

        /// <summary>
        /// Creates a new list task
        /// </summary>
        /// <param name="parentTaskId">Parent list task Id</param>
        /// <param name="isOrdered">True if list task is to be ordered</param>
        /// <param name="listTaskId">Id of new list task</param>
        /// <returns>ServiceOperationResult</returns>
        public ServiceOperationResult TryCreateListTask(int parentTaskId, bool isOrdered, out int listTaskId)
        {
            Logger.Info("TryCreateListTask({0},{1})", parentTaskId, isOrdered);

            try
            {
                var result = CreateListTask(parentTaskId, isOrdered);
                listTaskId = result.Item1;
                return ServiceOperationResult.FromServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                listTaskId = -1;
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
            Logger.Info("TryCreateNodeTask({0},{1})", parentListTaskId, nodeId);

            try
            {
                var result = CreateServicingTask(parentListTaskId, nodeId, serviceType, expectedDuration);
                serviceTaskId = result.Item1;
                return ServiceOperationResult.FromServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                serviceTaskId = -1;
                return HandleClientException(ex);
            }
        }

        protected override void Dispose(bool isDisposing)
        {
            Logger.Debug("Dispose({0})", isDisposing);

            if (isDisposed)
            {
                return;
            }

            isDisposed = true;

            base.Dispose(isDisposing);
        }

        private Tuple<bool, ServiceCallData> Commit(int jobId, int agentId = -1)
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

        private Tuple<JobData, ServiceCallData> CreateJob()
        {
            Logger.Debug("CreateJob()");

            if (isDisposed)
            {
                throw new ObjectDisposedException("JobBuilderClient");
            }

            Tuple<JobData, ServiceCallData> result;

            using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
            {
                IJobBuilderService channel = channelFactory.CreateChannel();
                result = channel.CreateJob();
                channelFactory.Close();
            }

            return result;
        }

        private Tuple<int, ServiceCallData> CreateListTask(int parentTaskId, bool isOrdered)
        {
            Logger.Debug("CreateListTask({0},{1})", parentTaskId, isOrdered);

            if (isDisposed)
            {
                throw new ObjectDisposedException("JobBuilderClient");
            }

            Tuple<int, ServiceCallData> result;

            using (ChannelFactory<IJobBuilderService> channelFactory = CreateChannelFactory())
            {
                IJobBuilderService channel = channelFactory.CreateChannel();
                result = channel.CreateListTask(parentTaskId, isOrdered);
                channelFactory.Close();
            }

            return result;
        }

        private Tuple<int, ServiceCallData> CreateServicingTask(int parentTaskId, int nodeId, ServiceType serviceType, TimeSpan expectedDuration)
        {
            Logger.Debug("CreateServicingTask({0},{1})", parentTaskId, nodeId, serviceType, expectedDuration);

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
    }
}