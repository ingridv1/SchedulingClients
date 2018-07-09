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
		ServiceOperationResult TryGetJobState(int jobId, out JobStateData jobStateData);

		ServiceOperationResult TryGetParentJobStateFromTaskId(int taskId, out JobStateData jobStateData);

		event Action<TaskProgressData> TaskStateUpdated;
	}
}
