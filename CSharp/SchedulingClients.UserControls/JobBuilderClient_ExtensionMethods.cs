using SchedulingClients.JobBuilderServiceReference;
using System;

namespace SchedulingClients.UserControls
{
    public static class JobBuilderClient_ExtensionMethods
    {
        public static void MultiPickJobTest(this JobBuilderClient jobBuilder)
        {
            JobData jobData = jobBuilder.CreateJob();

            int unorderedListTaskId = jobBuilder.CreateListTask(jobData.OrderedListTaskId, false).Item1;

            int pickTask0Id = jobBuilder.CreateNodeTask(unorderedListTaskId, 1, ServiceType.Pick, TimeSpan.FromSeconds(30)).Item1;

            int pickTask1Id = jobBuilder.CreateNodeTask(unorderedListTaskId, 3, ServiceType.Pick, TimeSpan.FromSeconds(30)).Item1;

            int pickTask2Id = jobBuilder.CreateNodeTask(unorderedListTaskId, 7, ServiceType.Pick, TimeSpan.FromSeconds(30)).Item1;

            int dropTaskId = jobBuilder.CreateNodeTask(jobData.OrderedListTaskId, 10, ServiceType.Drop, TimeSpan.FromSeconds(10)).Item1;

            int parkTaskId = jobBuilder.CreateNodeTask(jobData.OrderedListTaskId, 12, ServiceType.Park, TimeSpan.FromMinutes(5)).Item1;

            bool success = jobBuilder.Commit(jobData.JobId);
        }
    }
}