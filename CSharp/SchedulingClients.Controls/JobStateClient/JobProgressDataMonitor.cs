using System.Linq;

namespace SchedulingClients.Controls.JobStateClient
{
	public class JobProgressDataMonitor : GenericDataMonitor<JobProgressDataMailbox>
	{
		private IJobStateClient client = null;

		public JobProgressDataMonitor()
			: base()
		{
		}

		public void Configure(IJobStateClient newClient)
		{
			lock (lockObject)
			{
				if (client != null)
				{
					client.JobProgressUpdated -= Client_JobProgressUpdated;
				}

				this.client = newClient;
				this.client.JobProgressUpdated += Client_JobProgressUpdated;
			}
		}

		private void Client_JobProgressUpdated(JobStateServiceReference.JobProgressData jobProgressData)
		{
			lock (lockObject)
			{
				JobProgressDataMailbox messsageBox = Mailboxes.FirstOrDefault(e => e.Key == jobProgressData.AssignedAgentId);

				if (messsageBox == null)
				{
					mailboxes.Add(new JobProgressDataMailbox(jobProgressData.AssignedAgentId, jobProgressData));
				}
				else
				{
					messsageBox.Update(jobProgressData);
				}
			}
		}
	}
}