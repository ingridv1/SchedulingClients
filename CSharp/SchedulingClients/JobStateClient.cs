using System;
using SchedulingClients.JobStateServiceReference;
using System.ServiceModel;

namespace SchedulingClients
{
    public class JobStateClient : AbstractCallbackClient<IJobStateService>
    {
        public JobStateServiceCallback callback = new JobStateServiceCallback();

        private TimeSpan heartbeat;

        private bool isDisposed = false;

        /// <summary>
        /// Creates a JobStateClient
        /// </summary>
        /// <param name="netTcpUri">net.tcp address of the job state service</param>
        public JobStateClient(Uri netTcpUri, TimeSpan hearbeat = default(TimeSpan))
            : base(netTcpUri)
        {
            this.heartbeat = heartbeat < TimeSpan.FromMilliseconds(1000) ? TimeSpan.FromMilliseconds(1000) : heartbeat;
        }

        /// <summary>
        /// Heartbeat time
        /// </summary>
        public TimeSpan Heartbeat { get { return heartbeat; } }

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

        protected override void HeartbeatThread()
        {
            Logger.Debug("HeartbeatThread()");

            ChannelFactory<IJobStateService> channelFactory = CreateChannelFactory();
            IJobStateService servicingService = channelFactory.CreateChannel();

            bool? exceptionCaught;

            while (!Terminate)
            {
                exceptionCaught = null;

                try
                {
                    Logger.Trace("SubscriptionHeartbeat({0})", Key);
                    servicingService.SubscriptionHeartbeat(Key);
                    IsConnected = true;
                    exceptionCaught = false;
                }
                catch (EndpointNotFoundException)
                {
                    Logger.Warn("HeartbeatThread - EndpointNotFoundException. Is the server running?");
                    exceptionCaught = true;
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                    exceptionCaught = true;
                }

                if (exceptionCaught == true)
                {
                    channelFactory.Abort();
                    IsConnected = false;

                    channelFactory = CreateChannelFactory(); // Create a new channel as this one is dead
                    servicingService = channelFactory.CreateChannel();
                }

                heartbeatReset.WaitOne(Heartbeat);
            }

            Logger.Debug("HeartbeatThread exit");
        }

        protected override void SetInstanceContext()
        {
            this.context = new InstanceContext(this.callback);
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