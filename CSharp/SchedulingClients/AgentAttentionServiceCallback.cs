using SchedulingClients.AgentAttentionServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingClients
{
	public class AgentAttentionServiceCallback : IAgentAttentionServiceCallback
	{
		public AgentAttentionServiceCallback()
		{
		}

		public event Action<AgentAttentionData> AgentAttentionChange;

		public void OnCallback(AgentAttentionData callbackObject)
		{
			Action<AgentAttentionData> handlers = AgentAttentionChange;

			if (handlers != null)
			{
				foreach (Action<AgentAttentionData> handler in handlers.GetInvocationList())
				{
					handler.BeginInvoke(callbackObject, null, null);
				}
			}
		}
	}
}
