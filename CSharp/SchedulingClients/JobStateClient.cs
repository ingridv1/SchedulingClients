using System;
using SchedulingClients.JobStateServiceReference;
using System.ServiceModel;

namespace SchedulingClients
{
    public class JobStateClient : AbstractClient<IJobStateService>
    {
        private bool isDisposed = false;

        public JobStateClient(Uri netTcpUri)
            : base(netTcpUri)
        {
        }

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