using System;
using SchedulingClients.JobStateServiceReference;
using System.ServiceModel;
using GAClients;

namespace SchedulingClients
{
    internal class JobStateClient : AbstractCallbackClient<IJobStateService>, IJobStateClient
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

        public event Action<TaskProgressData> TaskStateUpdated
        {
            add { callback.TaskProgressUpdate += value; }
            remove { callback.TaskProgressUpdate -= value; }
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
        public ServiceOperationResult TryGetJobState(int jobId, out JobStateData jobStateData)
        {
            Logger.Info("TryGetJobState()");

            try
            {
                var result = GetJobState(jobId);
                jobStateData = result.Item1;
                return ServiceOperationResultFactory.FromJobStateServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                jobStateData = null;
                return HandleClientException(ex);
            }
        }

        /// <summary>
        /// Gets the state of a specific job form the id one of its child tasks
        /// </summary>
        /// <param name="taskId">Task id</param>
        /// <param name="jobState">State job is in</param>
        /// <returns>ServiceOperationResult</returns>
        public ServiceOperationResult TryGetParentJobStateFromTaskId(int taskId, out JobStateData jobStateData)
        {
            Logger.Info("TryGetJobState()");

            try
            {
                var result = GetParentJobStateFromTaskId(taskId);
                jobStateData = result.Item1;
                return ServiceOperationResultFactory.FromJobStateServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                jobStateData = null;
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

        private Tuple<JobStateData, ServiceCallData> GetParentJobStateFromTaskId(int taskId)
        {
            Logger.Debug("GetParentJobStateFromTaskId()");

            if (isDisposed)
            {
                throw new ObjectDisposedException("JobStateClient");
            }

            Tuple<JobStateData, ServiceCallData> result;

            using (ChannelFactory<IJobStateService> channelFactory = CreateChannelFactory())
            {
                IJobStateService channel = channelFactory.CreateChannel();
                result = channel.GetParentJobStateFromTaskId(taskId);
                channelFactory.Close();
            }

            return result;
        }
    }
}