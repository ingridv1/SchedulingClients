using BaseClients.Core;
using GAAPICommon.Architecture;
using GAAPICommon.Core;
using GAAPICommon.Core.Dtos;
using GACore.Architecture;
using SchedulingClients.Core.AgentServiceReference;
using System;
using System.ServiceModel;

namespace SchedulingClients.Core
{
    internal class AgentClient : AbstractClient<IAgentService>, IAgentClient
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

        /// <summary>
        /// Gets all available data on registered agents
        /// </summary>
        /// <param name="agentDatas"></param>
        /// <returns>Array of AgentDtos</returns>
        public IServiceCallResult<AgentDto[]> GetAllAgentData()
        {
            Logger.Trace("GetAllAgentData()");

            try
            {
                using (ChannelFactory<IAgentService> channelFactory = CreateChannelFactory())
                {
                    IAgentService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto<AgentDto[]> result = channel.GetAllAgentData();
                    channelFactory.Close();

                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ServiceCallResultFactory<AgentDto[]>.FromClientException(ex);
            }
        }

        public IServiceCallResult<AgentDto[]> GetAllAgentsInLifetimeState(AgentLifetimeState agentLifetimeState)
        {
            Logger.Trace("GetAllAgentsInLifetimeState()");

            try
            {
                using (ChannelFactory<IAgentService> channelFactory = CreateChannelFactory())
                {
                    IAgentService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto<AgentDto[]> result = channel.GetAllAgentsInLifetimeState(agentLifetimeState);
                    channelFactory.Close();

                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ServiceCallResultFactory<AgentDto[]>.FromClientException(ex);
            }
        }

        public IServiceCallResult SetAgentLifetimeState(int agentId, AgentLifetimeState desiredState)
        {
            Logger.Trace("SetAgentLifetimeState()");

            try
            {
                using (ChannelFactory<IAgentService> channelFactory = CreateChannelFactory())
                {
                    IAgentService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto result = channel.SetAgentLifetimeState(agentId,desiredState);
                    channelFactory.Close();

                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ServiceCallResultFactory.FromClientException(ex);
            }
        }
    }
}