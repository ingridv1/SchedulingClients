using SchedulingClients.MapServiceReference;
using System;

namespace SchedulingClients
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

            if (handlers != null)
            {
                foreach(Action<OccupyingMandateProgressDto> handler in handlers.GetInvocationList())
                {
                    handler.BeginInvoke(callbackObject, null, null);
                }
            }
        }
    }
}
