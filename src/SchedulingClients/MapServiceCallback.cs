using SchedulingClients.MapServiceReference;
using System;

namespace SchedulingClients
{
    public class MapServiceCallback : IMapServiceCallback
    {
        public MapServiceCallback()
        {
        }

        public event Action<OccupyingMandateProgressData> OccupyingMandateProgressChange;

        public void OnCallback(OccupyingMandateProgressData callbackObject)
        {
            Action<OccupyingMandateProgressData> handlers = OccupyingMandateProgressChange;

            if (handlers != null)
            {
                foreach(Action<OccupyingMandateProgressData> handler in handlers.GetInvocationList())
                {
                    handler.BeginInvoke(callbackObject, null, null);
                }
            }
        }
    }
}
