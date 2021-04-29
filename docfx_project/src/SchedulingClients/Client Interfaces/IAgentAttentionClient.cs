using SchedulingClients.AgentAttentionServiceReference;
using BaseClients;
using System;

namespace SchedulingClients
{
    public interface IAgentAttentionClient : ICallbackClient
    {
        event Action<AgentAttentionData[]> AgentAttentionChange;
    }
}
