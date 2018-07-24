using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAClients;
using SchedulingClients.JobBuilderServiceReference;

namespace SchedulingClients.Client_Interfaces
{
    public static class IJobBuilderClient_ExtensionMethods
    {
        public static ServiceOperationResult TryCreateGoToTask(this IJobBuilderClient client, int parentListTaskId, int nodeId, out int gotoTaskId, TimeSpan expectedDuration = default(TimeSpan))
        {
            return client.TryCreateServicingTask(parentListTaskId, nodeId, ServiceType.GoTo, out gotoTaskId, expectedDuration);
        }

        public static ServiceOperationResult TryCreateAwaitTask(this IJobBuilderClient client, int parentListTaskId, int nodeId, out int awaitTaskId)
        {
            return client.TryCreateServicingTask(parentListTaskId, nodeId, ServiceType.Await, out awaitTaskId, TimeSpan.Zero);
        }
    }
}
