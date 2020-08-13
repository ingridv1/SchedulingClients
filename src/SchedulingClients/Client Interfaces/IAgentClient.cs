using BaseClients.Architecture;
using GAAPICommon.Architecture;
using GACore.Architecture;
using SchedulingClients.AgentServiceReference;
using System.Collections.Generic;

namespace SchedulingClients
{
    public interface IAgentClient : IClient
	{
		IServiceCallResult<AgentDto[]> GetAllAgentData();

        IServiceCallResult<AgentDto[]> GetAllAgentsInLifetimeState(AgentLifetimeState agentLifetimeState);

        IServiceCallResult SetAgentLifetimeState(int agentId, AgentLifetimeState desiredState);
    }
}
