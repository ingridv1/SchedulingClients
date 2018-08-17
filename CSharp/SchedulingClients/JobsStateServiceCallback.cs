//using SchedulingClients.JobsStateServiceReference;
//using System;

//namespace SchedulingClients
//{
//    public class JobsStateServiceCallback : IJobsStateServiceCallback
//    {
//        public JobsStateServiceCallback()
//        {
//        }

//        public event Action<JobsStateData> JobsStateChange;

//        public void OnCallback(JobsStateData callbackObject)
//        {
//            Action<JobsStateData> handlers = JobsStateChange;

//            if (handlers != null)
//            {
//                foreach (Action<JobsStateData> handler in handlers.GetInvocationList())
//                {
//                    handler.BeginInvoke(callbackObject, null, null);
//                }
//            }
//        }
//    }
//}