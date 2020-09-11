using BaseClients.Core;
using GAAPICommon.Architecture;
using SchedulingClients.Core.AgentServiceReference;
using System;

namespace SchedulingClients.Core
{
    internal class AgentClient : AbstractClient<IAgentService>, IAgentClient
    {
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
        public IServiceCallResult<AgentDto[]> GetAllAgents()
        {
            Logger.Trace("GetAllAgentData()");
            return HandleAPICall<AgentDto[]>(e => e.GetAllAgentData());
        }

        public IServiceCallResult<AgentDto[]> GetAllAgentsInLifetimeState(AgentLifetimeState agentLifetimeState)
        {
            Logger.Trace($"GetAllAgentsInLifetimeState() agentLifetimeState:{agentLifetimeState}");
            return HandleAPICall<AgentDto[]>(e => e.GetAllAgentsInLifetimeState(agentLifetimeState));
        }

        public IServiceCallResult SetAgentLifetimeState(int agentId, AgentLifetimeState agentLifetimeState)
        {
            Logger.Trace($"SetAgentLifetimeState() agentId:{agentId} agentLifeTimeState:{agentLifetimeState}");
            return HandleAPICall(e => e.SetAgentLifetimeState(agentId, agentLifetimeState));
        }
    }
}