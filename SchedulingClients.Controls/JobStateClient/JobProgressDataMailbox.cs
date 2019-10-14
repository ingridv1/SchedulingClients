using GACore;
using SchedulingClients.JobStateServiceReference;

namespace SchedulingClients.Controls.JobStateClient
{
	public class JobProgressDataMailbox : GenericMailbox<int, JobProgressData>
	{
		public JobProgressDataMailbox(int agentId, JobProgressData taskProgressData)
			: base(agentId, taskProgressData)
		{
		}
	}
}