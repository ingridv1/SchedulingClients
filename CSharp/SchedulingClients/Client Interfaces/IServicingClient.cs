using GAClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingClients
{
	public interface IServicingClient
	{
		ServiceOperationResult TrySetServiceComplete(int taskId, out bool success);
	}
}
