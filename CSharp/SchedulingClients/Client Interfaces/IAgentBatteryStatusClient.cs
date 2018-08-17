using BaseClients;
using SchedulingClients.AgentBatteryStatusServiceReference;
using System.Collections.Generic;

namespace SchedulingClients
{
    public interface IAgentBatteryStatusClient : IClient
    {
        ServiceOperationResult TryGetAllAgentData(out IEnumerable<AgentBatteryStatusData> agentBatteryStatusDatas);
    }
}
