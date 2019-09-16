using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SchedulingClients.Controls.TaskStateClient
{
	public class TaskProgressDataMonitor : GenericDataMonitor<TaskProgressDataMailbox>
	{
		private ITaskStateClient client = null;

		public TaskProgressDataMonitor()
			:base()
		{
		}

		public void Configure(ITaskStateClient newClient)
		{
			lock (lockObject)
			{
				if (client != null)
				{
					client.TaskProgressUpdated -= Client_TaskProgressUpdated;
				}

				this.client = newClient;
				this.client.TaskProgressUpdated += Client_TaskProgressUpdated;
			}
		}

		private void Client_TaskProgressUpdated(TaskStateServiceReference.TaskProgressData taskProgressData)
		{
			lock (lockObject)
			{
				TaskProgressDataMailbox messsageBox = Mailboxes.FirstOrDefault(e => e.Key == taskProgressData.AssignedAgentId);

				if (messsageBox == null)
				{
					mailboxes.Add(new TaskProgressDataMailbox(taskProgressData.AssignedAgentId, taskProgressData));
				}
				else
				{
					messsageBox.Update(taskProgressData);
				}
			}
		}
	}
}
