﻿using System;
using SchedulingClients.JobStateServiceReference;

namespace SchedulingClients
{
    public class JobStateServiceCallback : IJobStateServiceCallback
    {
        public JobStateServiceCallback()
        {
        }

        public event Action<TaskProgressData> TaskProgressUpdate;

        public void OnCallback(TaskProgressData taskProgressData)
        {
            Action<TaskProgressData> handlers = TaskProgressUpdate;

            if (handlers != null)
            {
                foreach (Action<TaskProgressData> handler in handlers.GetInvocationList())
                {
                    handler.BeginInvoke(taskProgressData, null, null);
                }
            }
        }
    }
}