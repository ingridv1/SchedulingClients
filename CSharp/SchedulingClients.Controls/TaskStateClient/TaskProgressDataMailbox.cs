using SchedulingClients.TaskStateServiceReference;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SchedulingClients.Controls.TaskStateClient
{
	public class TaskProgressDataMailbox : INotifyPropertyChanged
	{
		private readonly int agentId;

		private TaskProgressData taskProgressData = null;

		public TaskProgressData TaskProgressData
		{
			get { return taskProgressData; }

			private set
			{
				taskProgressData = value;
				OnNotifyPropertyChanged();
			}
		}

		public TaskProgressDataMailbox(TaskProgressData taskProgressData)
		{
			if (taskProgressData == null) throw new ArgumentNullException("taskProgressData");

			this.agentId = taskProgressData.AssignedAgentId;
			this.taskProgressData = taskProgressData;
		}

		public void Update(TaskProgressData taskProgressData)
		{
			if (AgentId != taskProgressData.AssignedAgentId) throw new ArgumentOutOfRangeException("taskProgressData invalid agentId");

			TaskProgressData = taskProgressData;
		}

		public int AgentId => agentId;

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnNotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
