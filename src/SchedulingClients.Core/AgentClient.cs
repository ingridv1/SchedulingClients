using BaseClients.Core;
using GAAPICommon.Architecture;
using GAAPICommon.Core.Dtos;
using SchedulingClients.Core.AgentServiceReference;
using System;

namespace SchedulingClients.Core
{
    internal class AgentClient : AbstractClient<IAgentService>, IAgentClient
    {
        public AgentClient(Uri netTcpUri)
            : base(netTcpUri)
        {
        }

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