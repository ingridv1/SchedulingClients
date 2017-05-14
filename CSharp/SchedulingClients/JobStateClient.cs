using System;
using SchedulingClients.JobStateServiceReference;
using System.ServiceModel;

namespace SchedulingClients
{
    public class JobStateClient : AbstractClient<IJobStateService>
    {
        private bool isDisposed = false;

        /// <summary>
        /// Creates a JobStateClient
        /// </summary>
        /// <param name="netTcpUri">net.tcp address of the job state service</param>
        public JobStateClient(Uri netTcpUri)
            : base(netTcpUri)
        {
        }

        /// <summary>
        /// Gets the state of a specific job
        /// </summary>
        /// <param name="jobId">Job id</param>
        /// <param name="jobState">State job is in</param>
        /// <returns>ServiceOperationResult</returns>
        public ServiceOperationResult TryGetJobState(int jobId, out JobStateData jobState)
        {
            Logger.Info("TryGetJobState()");

            try
            {
                var result = GetJobState(jobId);
                jobState = result.Item1;
                return ServiceOperationResult.FromServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                jobState = null;
                return HandleClientException(ex);
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

        private Tuple<JobStateData, ServiceCallData> GetJobState(int jobId)
        {
            Logger.Debug("GetJobState()");

            if (isDisposed)
            {
                throw new ObjectDisposedException("JobStateClient");
            }
            Tuple<JobStateData, ServiceCallData> result;

            using (ChannelFactory<IJobStateService> channelFactory = CreateChannelFactory())
            {
                IJobStateService channel = channelFactory.CreateChannel();
                result = channel.GetJobState(jobId);
                channelFactory.Close();
            }

            return result;
        }
    }
}