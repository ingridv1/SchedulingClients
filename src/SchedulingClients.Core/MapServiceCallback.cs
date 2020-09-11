using MoreLinq;
using SchedulingClients.Core.MapServiceReference;
using System;
using System.Linq;

namespace SchedulingClients.Core
{
    public class MapServiceCallback : IMapServiceCallback
    {
        public MapServiceCallback()
        {
        }

        public event Action<OccupyingMandateProgressDto> OccupyingMandateProgressChange;

        public void OnCallback(OccupyingMandateProgressDto callbackObject)
        {
            Action<OccupyingMandateProgressDto> handlers = OccupyingMandateProgressChange;

            handlers?
                   .GetInvocationList()
                   .Cast<Action<OccupyingMandateProgressDto>>()
                   .ForEach(e => e.BeginInvoke(callbackObject, null, null));
        }
    }
}