using GAClients;
using SchedulingClients.AgentStatecastserviceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingClients
{
	public class AgentStatecastClient : AbstractClient<IAgentStatecastService>
	{
		private bool isDisposed = false;

		public AgentStatecastClient(Uri netTcpUri)
			:base(netTcpUri)
		{
		}

		public ServiceOperationResult TryGetEnumStatecastParameter(int agentId, string parameterAlias, out byte parameterData)
		{
			Logger.Info("TryGetEnumStatecastParameter()");

			try
			{
				var result = GetEnumStatecastParameter(agentId, parameterAlias);
				parameterData = result.Item1;
				return ServiceOperationResultFactory.FromAgentStatecastServiceCallData(result.Item2);
			}
			catch(Exception ex)
			{
				parameterData = 0;
				return HandleClientException(ex);
			}
		}

		public ServiceOperationResult TryGetFloatStatecastParameter(int agentId, string parameterAlias, out float parameterData)
		{
			Logger.Info("TryGetFloatStatecastParameter()");

			try
			{
				var result = GetFloatStatecastParameter(agentId, parameterAlias);
				parameterData = result.Item1;
				return ServiceOperationResultFactory.FromAgentStatecastServiceCallData(result.Item2);
			}
			catch (Exception ex)
			{
				parameterData = 0;
				return HandleClientException(ex);
			}
		}

		public ServiceOperationResult TryGetShortStatecastParameter(int agentId, string parameterAlias, out short parameterData)
		{
			Logger.Info("TryGetShortStatecastParameter()");

			try
			{
				var result = GetShortStatecastParameter(agentId, parameterAlias);
				parameterData = result.Item1;
				return ServiceOperationResultFactory.FromAgentStatecastServiceCallData(result.Item2);
			}
			catch (Exception ex)
			{
				parameterData = 0;
				return HandleClientException(ex);
			}
		}

		public ServiceOperationResult TryGetUShortStatecastParameter(int agentId, string parameterAlias, out ushort parameterData)
		{
			Logger.Info("TryGetUShortStatecastParameter()");

			try
			{
				var result = GetUShortStatecastParameter(agentId, parameterAlias);
				parameterData = result.Item1;
				return ServiceOperationResultFactory.FromAgentStatecastServiceCallData(result.Item2);
			}
			catch (Exception ex)
			{
				parameterData = 0;
				return HandleClientException(ex);
			}
		}

		public ServiceOperationResult TryGetIPAddressStatecastParameter(int agentId, string parameterAlias, out IPAddress parameterData)
		{
			Logger.Info("TryGetfloatStatecastParameter()");

			try
			{
				var result = GetIPAddressStatecastParameter(agentId, parameterAlias);
				parameterData = result.Item1;
				return ServiceOperationResultFactory.FromAgentStatecastServiceCallData(result.Item2);
			}
			catch (Exception ex)
			{
				parameterData = IPAddress.None;
				return HandleClientException(ex);
			}
		}

		public ServiceOperationResult TryGetStatecastDescription(int agentId, out CastType statecastDescription)
		{
			Logger.Info("TryGetStatecastDescription()");

			try
			{
				var result = GetStatecastDescription(agentId);
				statecastDescription = result.Item1;
				return ServiceOperationResultFactory.FromAgentStatecastServiceCallData(result.Item2);
			}
			catch (Exception ex)
			{
				statecastDescription = new CastType();
				return HandleClientException(ex);
			}
		}

		private Tuple<byte, ServiceCallData> GetEnumStatecastParameter(int agentId, string parameterAlias)
		{
			Logger.Debug(String.Format("GetEnumStatecastParameter(agentId:{0}, parameterAlias:{1})", agentId, parameterAlias));

			if (isDisposed)
			{
				throw new ObjectDisposedException("AgentStatecastClient");
			}

			Tuple<byte, ServiceCallData> result;

			using (ChannelFactory<IAgentStatecastService> channelFactory = CreateChannelFactory())
			{
				IAgentStatecastService channel = channelFactory.CreateChannel();
				result = channel.GetEnumStatecastValue(agentId, parameterAlias);
				channelFactory.Close();
			}

			return result;
		}

		private Tuple<float, ServiceCallData> GetFloatStatecastParameter(int agentId, string parameterAlias)
		{
			Logger.Debug(String.Format("GetFloatStatecastParameter(agentId:{0}, parameterAlias:{1})", agentId, parameterAlias));

			if (isDisposed)
			{
				throw new ObjectDisposedException("AgentStatecastClient");
			}

			Tuple<float, ServiceCallData> result;

			using (ChannelFactory<IAgentStatecastService> channelFactory = CreateChannelFactory())
			{
				IAgentStatecastService channel = channelFactory.CreateChannel();
				result = channel.GetFloatStatecastValue(agentId, parameterAlias);
				channelFactory.Close();
			}

			return result;
		}

		private Tuple<short, ServiceCallData> GetShortStatecastParameter(int agentId, string parameterAlias)
		{
			Logger.Debug(String.Format("GetShortStatecastParameter(agentId:{0}, parameterAlias:{1})", agentId, parameterAlias));

			if (isDisposed)
			{
				throw new ObjectDisposedException("AgentStatecastClient");
			}

			Tuple<short, ServiceCallData> result;

			using (ChannelFactory<IAgentStatecastService> channelFactory = CreateChannelFactory())
			{
				IAgentStatecastService channel = channelFactory.CreateChannel();
				result = channel.GetShortStatecastValue(agentId, parameterAlias);
				channelFactory.Close();
			}

			return result;
		}

		private Tuple<ushort, ServiceCallData> GetUShortStatecastParameter(int agentId, string parameterAlias)
		{
			Logger.Debug(String.Format("GetUShortStatecastParameter(agentId:{0}, parameterAlias:{1})", agentId, parameterAlias));

			if (isDisposed)
			{
				throw new ObjectDisposedException("AgentStatecastClient");
			}

			Tuple<ushort, ServiceCallData> result;

			using (ChannelFactory<IAgentStatecastService> channelFactory = CreateChannelFactory())
			{
				IAgentStatecastService channel = channelFactory.CreateChannel();
				result = channel.GetUShortStatecastValue(agentId, parameterAlias);
				channelFactory.Close();
			}

			return result;
		}

		private Tuple<IPAddress, ServiceCallData> GetIPAddressStatecastParameter(int agentId, string parameterAlias)
		{
			Logger.Debug(String.Format("GetIPAddressStatecastParameter(agentId:{0}, parameterAlias:{1})", agentId, parameterAlias));

			if (isDisposed)
			{
				throw new ObjectDisposedException("AgentStatecastClient");
			}

			Tuple<IPAddress, ServiceCallData> result;

			using (ChannelFactory<IAgentStatecastService> channelFactory = CreateChannelFactory())
			{
				IAgentStatecastService channel = channelFactory.CreateChannel();
				result = channel.GetIPAddressStatecastValue(agentId, parameterAlias);
				channelFactory.Close();
			}

			return result;
		}

		private Tuple<CastType, ServiceCallData> GetStatecastDescription(int agentId)
		{
			Logger.Debug(String.Format("GetStatecastDescription(agentId:{0})", agentId));

			if (isDisposed)
			{
				throw new ObjectDisposedException("AgentStatecastClient");
			}

			Tuple<CastType, ServiceCallData> result;

			using (ChannelFactory<IAgentStatecastService> channelFactory = CreateChannelFactory())
			{
				IAgentStatecastService channel = channelFactory.CreateChannel();
				result = channel.GetStatecastDescription(agentId);
				channelFactory.Close();
			}

			return result;
		}
	}
}
