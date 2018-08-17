//using System;
//using SchedulingClients.FleetManagerServiceReference;

//namespace SchedulingClients
//{
//    public class FleetManagerServiceCallback : IFleetManagerServiceCallback
//    {
//        public FleetManagerServiceCallback()
//        {
//        }

//        public event Action<FleetState> FleetStateUpdate;

//        public void OnCallback(FleetState fleetState)
//        {
//            Action<FleetState> handlers = FleetStateUpdate;

//            if(handlers != null)
//            {
//                foreach(Action<FleetState> handler in handlers.GetInvocationList())
//                {
//                    handler.BeginInvoke(fleetState, null, null);
//                }
//            }
//        }
//    }
//}
