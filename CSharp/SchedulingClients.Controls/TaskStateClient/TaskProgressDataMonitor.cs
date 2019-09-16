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
	public class TaskProgressDataMonitor : INotifyPropertyChanged
	{
		private ObservableCollection<TaskProgressDataMailbox> mailboxes = new ObservableCollection<TaskProgressDataMailbox>();

		private ReadOnlyObservableCollection<TaskProgressDataMailbox> readonlyMailboxes;

		private readonly object lockObject = new object();

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnNotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private ITaskStateClient client = null;

		public ReadOnlyObservableCollection<TaskProgressDataMailbox> Mailboxes => readonlyMailboxes;

		public TaskProgressDataMonitor()
		{
			readonlyMailboxes = new ReadOnlyObservableCollection<TaskProgressDataMailbox>(mailboxes);

			BindingOperations.EnableCollectionSynchronization(Mailboxes, lockObject);
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
				TaskProgressDataMailbox messsageBox = mailboxes.FirstOrDefault(e => e.Key == taskProgressData.AssignedAgentId);

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
