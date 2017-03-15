using System;
using SchedulingClients.JobBuilderServiceReference;

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
        /// Commits a job , ready for assignment
        /// </summary>
        /// <param name="jobId">Id of the job to be comitted</param>
        /// <param name="agentId">Id of the agent to be assigned, -1 if unspecified</param>
        public bool Commit(int jobId, int agentId = -1)
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("JobBuilderClient");
            }

            IJobBuilderService channel = channelFactory.CreateChannel();
            return channel.CommitJob(jobId, agentId).Item1;
        }

        /// <summary>
        /// Creates a new job
        /// </summary>
        /// <returns>JobData of created job</returns>
        public JobData CreateJob()
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("JobBuilderClient");
            }

            IJobBuilderService channel = channelFactory.CreateChannel();
            return channel.CreateJob();
        }

        /// <summary>
        /// Creates a new list task
        /// </summary>
        /// <param name="parentTaskId">Parent task of this list task</param>
        /// <param name="isOrdered">true if job is ordered, false if is unordered</param>
        /// <returns>Tuple of new list tast id and error string</returns>
        public Tuple<int, string> CreateListTask(int parentTaskId, bool isOrdered)
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("JobBuilderClient");
            }

            IJobBuilderService channel = channelFactory.CreateChannel();
            return channel.CreateListTask(parentTaskId, isOrdered);
        }

        /// <summary>
        /// Creates a new node task
        /// </summary>
        /// <param name="parentTaskId">Parent task of this service task</param>
        /// <param name="nodeId">Id of the node to service at</param>
        /// <param name="serviceType">ServiceType to perform</param>
        /// <param name="expectedDuration">Estimated duration of the service task</param>
        /// <returns>Tuple of new task id and error string</returns>
        public Tuple<int, string> CreateNodeTask(int parentTaskId, int nodeId, ServiceType serviceType, TimeSpan expectedDuration)
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("JobBuilderClient");
            }

            IJobBuilderService channel = channelFactory.CreateChannel();
            return channel.CreateNodeTask(parentTaskId, nodeId, serviceType, expectedDuration);
        }

        /// <summary>
        /// Tries to commit a job, ready for assignment
        /// </summary>
        /// <param name="jobId">Id of the job to be comitted</param>
        /// <param name="agentId">Id of the agent to be assigned, -1 if unspecified</param>
        /// <returns>True if succesfull, otherwise false</returns>
        public bool TryCommit(int jobId, int agentId = -1)
        {
            try
            {
                IJobBuilderService channel = channelFactory.CreateChannel();
                Tuple<bool, string> result = channel.CommitJob(jobId, agentId);
                if (result.Item1)
                {
                    return true;
                }
                else
                {
                    throw new Exception(result.Item2);
                }
            }
            catch (Exception ex)
            {
                LastCaughtException = ex;
                return false;
            }
        }

        /// <summary>
        /// Tries to create a new job
        /// </summary>
        /// <param name="jobData">Job data of the created job</param>
        /// <returns>True if operation succesfull, otherwise false</returns>
        public bool TryCreateJob(out JobData jobData)
        {
            try
            {
                jobData = CreateJob();
                return true;
            }
            catch (Exception ex)
            {
                jobData = new JobData() { JobId = -1 };
                LastCaughtException = ex;
                return false;
            }
        }

        /// <summary>
        /// Tries to create a new list task
        /// </summary>
        /// <param name="parentTaskId">Parent task of this list task</param>
        /// <param name="isOrdered">True if job is ordered, false if is unordered</param>
        /// <param name="listTaskId">TaskId of the new list task</param>
        /// <returns>True if operation succesfull, otherwise false</returns>
        public bool TryCreateListTask(int parentTaskId, bool isOrdered, out Tuple<int, string> result)
        {
            try
            {
                IJobBuilderService channel = channelFactory.CreateChannel();
                result = channel.CreateListTask(parentTaskId, isOrdered);
                return true;
            }
            catch (Exception ex)
            {
                result = new Tuple<int, string>(-1, ex.Message);
                LastCaughtException = ex;
                return false;
            }
        }

        /// <summary>
        /// Tries to create a new node task
        /// </summary>
        /// <param name="parentTaskId">Parent task of this service task</param>
        /// <param name="nodeId">Id of the node to service at</param>
        /// <param name="serviceType">ServiceType to perform</param>
        /// <param name="expectedDuration">Estimated duration of the service task</param>
        /// <param name="serviceTaskId">TaskId of the new service task</param>
        /// <returns>True if operation succesfull, otherwise false</returns>
        public bool TryCreateNodeTask(int parentTaskId, int nodeId, ServiceType serviceType, TimeSpan expectedDuration, out Tuple<int, string> result)
        {
            try
            {
                result = CreateNodeTask(parentTaskId, nodeId, serviceType, expectedDuration);
                return true;
            }
            catch (Exception ex)
            {
                result = new Tuple<int, string>(-1, ex.Message);
                LastCaughtException = ex;
                return false;
            }
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposed)
            {
                return;
            }

            isDisposed = true;

            base.Dispose(isDisposing);
        }
    }
}