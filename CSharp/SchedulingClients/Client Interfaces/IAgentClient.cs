using System.Collections.Generic;
using SchedulingClients.AgentServiceReference;
using BaseClients;

namespace SchedulingClients
{
    public interface IAgentClient : IClient
	{
		ServiceOperationResult TryGetAllAgentData(out IEnumerable<AgentData> agentDatas);

		ServiceOperationResult TryGetAllAgentsInLifetimeState(out IEnumerable<AgentData> agentDatas, AgentLifetimeState agentLifetimeState);
	}
}
