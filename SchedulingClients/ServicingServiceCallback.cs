using SchedulingClients.ServicingServiceReference;
using System;

namespace SchedulingClients
{
    public class ServicingServiceCallback : IServicingServiceCallback
    {
        public ServicingServiceCallback()
        {
        }

        public event Action<ServiceStateData> ServiceRequest;

        public void OnCallback(ServiceStateData serviceStateData)
        {
            Action<ServiceStateData> handlers = ServiceRequest;

            if (handlers != null)
            {
                foreach (Action<ServiceStateData> handler in handlers.GetInvocationList())
                {
                    handler.BeginInvoke(serviceStateData, null, null);
                }
            }
        }
    }
}