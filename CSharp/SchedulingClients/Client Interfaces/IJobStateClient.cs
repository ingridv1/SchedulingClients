using GAClients;
using SchedulingClients.JobStateServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingClients
{
	public interface IJobStateClient : ICallbackClient
	{
#warning no longer required?
        //      ServiceOperationResult TryGetJobState(int jobId, out JobStateData jobStateData);

        //		ServiceOperationResult TryGetParentJobStateFromTaskId(int taskId, out JobStateData jobStateData);

        ServiceOperationResult TryGetJobSummary(int jobId, out JobSummaryData jobSummaryData);

        ServiceOperationResult TryGetParentJobSummaryFromTaskId(int taskId, out JobSummaryData jobSummaryData);

        event Action<JobProgressData> JobProgressUpdated;
    }
}
