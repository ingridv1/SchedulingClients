using BaseClients;
using SchedulingClients.AgentBatteryStatusServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingClients
{
    public interface IAgentBatteryStatusClient : IClient
    {
        ServiceOperationResult TryGetAllAgentData(out IEnumerable<AgentBatteryStatusData> agentBatteryStatusDatas);
    }
}
