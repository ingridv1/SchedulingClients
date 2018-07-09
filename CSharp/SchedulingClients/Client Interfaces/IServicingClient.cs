using GAClients;
using SchedulingClients.ServicingServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingClients
{
	public interface IServicingClient : ICallbackClient
	{
		ServiceOperationResult TrySetServiceComplete(int taskId, out bool success);

		event Action<ServiceStateData> ServiceRequest;
	}
}
