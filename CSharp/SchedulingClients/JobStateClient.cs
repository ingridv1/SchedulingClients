using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SchedulingClients.JobStateServiceReference;
using System.Threading.Tasks;
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

        public JobStateData GetJobState(int jobId)
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("JobStateClient");
            }

            ChannelFactory<IJobStateService> channelFactory = CreateChannelFactory();
            IJobStateService channel = channelFactory.CreateChannel();

            JobStateData jobState = channel.GetJobState(jobId);
            channelFactory.Close();
            return jobState;
        }

        public bool TryGetJobState(int jobId, out JobStateData jobState)
        {
            Logger.Info("TryGetJobState()");

            try
            {
                jobState = GetJobState(jobId);
                return true;
            }
            catch (Exception ex)
            {
                LastCaughtException = ex;
                jobState = null;
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