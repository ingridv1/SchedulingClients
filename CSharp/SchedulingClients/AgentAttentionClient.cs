using GAClients;
using SchedulingClients.AgentAttentionServiceReference;
using System;
using System.ServiceModel;

namespace SchedulingClients
{
    public class AgentAttentionClient : AbstractCallbackClient<IAgentAttentionService>, IAgentAttentionClient
    {
		private AgentAttentionServiceCallback callback = new AgentAttentionServiceCallback();

		private TimeSpan heartbeat;

		private bool isDisposed = false;

		AgentAttentionData agentAttentionData = null;

		/// <summary>
		/// Creates an AgentAttentionClient
		/// </summary>
		/// <param name="netTcpUri">net.tcp address of the job state service</param>
		/// <param name="heartbeat">Heartbeat</param>
		public AgentAttentionClient(Uri netTcpUri, TimeSpan heartbeat = default(TimeSpan))
			: base(netTcpUri)
		{
			this.heartbeat = heartbeat < TimeSpan.FromMilliseconds(1000) ? TimeSpan.FromMilliseconds(1000) : heartbeat;
			callback.AgentAttentionChange += Callback_AgentAttentionChange;
		}

		/// <summary>
		/// The state of agents that require attention
		/// </summary>
		public AgentAttentionData AgentAttentionData
		{
			get
			{
				return agentAttentionData;
			}

			private set
			{
				if (agentAttentionData != value)
				{
					agentAttentionData = value;
					OnNotifyPropertyChanged();
				}
			}
		}

		/// <summary>
		/// Hearbeat time
		/// </summary>
		public TimeSpan Heartbeat { get { return heartbeat; } }

		protected override void Dispose(bool isDisposing)
		{
			Logger.Debug("Dispose({0})", isDisposing);

			if (isDisposed)
			{
				return;
			}

			callback.AgentAttentionChange -= Callback_AgentAttentionChange;
			isDisposed = true;

			base.Dispose(isDisposing);
		}

		private void Callback_AgentAttentionChange(AgentAttentionData newAgentAttentionData)
		{
			AgentAttentionData = newAgentAttentionData;
		}

		protected override void HeartbeatThread()
		{
			Logger.Debug("HeartbeatThread()");

			ChannelFactory<IAgentAttentionService> channelFactory = CreateChannelFactory();
			IAgentAttentionService agentAttentionService = channelFactory.CreateChannel();

			bool? exceptionCaught;

			while (!Terminate)
			{
				exceptionCaught = null;

				try
				{
					Logger.Trace("SubscriptionHeartbeat({0})", Key);
					agentAttentionService.SubscriptionHeartbeat(Key);
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
					agentAttentionService = channelFactory.CreateChannel();
				}

				heartbeatReset.WaitOne(Heartbeat);
			}

			Logger.Debug("HeartbeatThread exit");
		}

		protected override void SetInstanceContext()
		{
			this.context = new InstanceContext(this.callback);
		}
	}
}
