using MoreLinq;
using SchedulingClients.Core.ServicingServiceReference;
using System;
using System.Linq;

namespace SchedulingClients.Core
{
    internal class ServicingServiceCallback : IServicingServiceCallback
    {
        public ServicingServiceCallback()
        {
        }

        public event Action<ServiceStateDto> ServiceRequest;

        public void OnCallback(ServiceStateDto serviceStateData)
        {
            Action<ServiceStateDto> handlers = ServiceRequest;

            handlers?
                   .GetInvocationList()
                   .Cast<Action<ServiceStateDto>>()
                   .ForEach(e => e.BeginInvoke(serviceStateData, null, null));
        }
    }
}