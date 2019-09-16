using SchedulingClients.TaskStateServiceReference;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using GACore;

namespace SchedulingClients.Controls.TaskStateClient
{
	public class TaskProgressDataMailbox : GenericMailbox<int, TaskProgressData>
	{
		public TaskProgressDataMailbox(int agentId, TaskProgressData taskProgressData)
			:base(agentId, taskProgressData)
		{
		}
	}
}
