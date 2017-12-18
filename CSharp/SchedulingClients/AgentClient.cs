using System;
using System.ServiceModel;
using SchedulingClients.AgentServiceReference;
using System.Collections.Generic;

namespace SchedulingClients
{
    public class AgentClient : AbstractClient<IAgentService>
    {
        private bool isDisposed = false;

        /// <summary>
        /// Creates a new agent client
        /// </summary>
        /// <param name="netTcpUri">net .tcp address of the agent client service</param>
        public AgentClient(Uri netTcpUri)
            : base(netTcpUri)
        {
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

        /// <summary>
        /// Gets all available data on registered agents
        /// </summary>
        /// <param name="agentDatas"></param>
        /// <returns>ServiceOperationResult</returns>
        public ServiceOperationResult TryGetAllAgentData(out IEnumerable<AgentData> agentDatas)
        {
            Logger.Info("TryGetAllAgentData()");

            try
            {
                var result = GetAllAgentData();
                agentDatas = result.Item1;
                return ServiceOperationResult.FromServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                agentDatas = new AgentData[] { };
                return HandleClientException(ex);
            }
        }

        public ServiceOperationResult TryGetAllAgentsInLifetimeState(out IEnumerable<AgentData> agentDatas, AgentLifetimeState agentLifetimeState)
        {
            Logger.Info("");

            try
            {
                var result = GetAllAgentsInLifetimeState(agentLifetimeState);
                agentDatas = result.Item1;
                return ServiceOperationResult.FromServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                agentDatas = new AgentData[] { };
                return HandleClientException(ex);
            }
        }

        private Tuple<AgentData[], ServiceCallData> GetAllAgentData()
        {
            Logger.Debug("GetAllAgentData()");

            if (isDisposed)
            {
                throw new ObjectDisposedException("AgentClient");
            }

            Tuple<AgentData[], ServiceCallData> result;

            using (ChannelFactory<IAgentService> channelFactory = CreateChannelFactory())
            {
                IAgentService channel = channelFactory.CreateChannel();
                result = channel.GetAllAgentData();
                channelFactory.Close();
                Logger.Trace("channelFactory closed");
            }

            return result;
        }

        private Tuple<AgentData[], ServiceCallData> GetAllAgentsInLifetimeState(AgentLifetimeState agentLifetimeState)
        {
            Logger.Debug("GetAllAgentsInLifetimeState()");

            if (isDisposed)
            {
                throw new ObjectDisposedException("AgentClient");
            }

            Tuple<AgentData[], ServiceCallData> result;

            using (ChannelFactory<IAgentService> channelFactory = CreateChannelFactory())
            {
                IAgentService channel = channelFactory.CreateChannel();
                result = channel.GetAllAgentsInLifetimeState(agentLifetimeState);
                channelFactory.Close();
                Logger.Trace("channelFactory closed");
            }

            return result;
        }
    }
}