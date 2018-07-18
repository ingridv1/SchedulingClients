using SchedulingClients.AgentAttentionServiceReference;
using GAClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAClients;

namespace SchedulingClients
{
    public interface IAgentAttentionClient : ICallbackClient
    { 
        AgentAttentionData AgentAttentionData { get; }
        
       event Action<AgentAttentionData> AgentAttentionChange;
    } 
}
