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

        public ServiceOperationResult TryCreateServicingTask(int parentTaskId, int nodeId, ServiceType serviceType, TimeSpan expectedDuration, out int nodeTaskId)
        {
            Logger.Info("TryCreateNodeTask({0},{1})", parentTaskId, nodeId);

            try
            {
                var result = CreateServicingTask(parentTaskId, nodeId, serviceType, expectedDuration);
                nodeTaskId = result.Item1;
                return ServiceOperationResult.FromServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                nodeTaskId = -1;
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
            Logger.Info("Commit({0},{1})", jobId, agentId);

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
            Logger.Info("CreateJob()");

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
            Logger.Info("CreateListTask({0},{1})", parentTaskId, isOrdered);

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
            Logger.Info("CreateServicingTask({0},{1})", parentTaskId, nodeId, serviceType, expectedDuration);

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