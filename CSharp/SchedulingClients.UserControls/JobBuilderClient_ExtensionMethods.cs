using SchedulingClients.JobBuilderServiceReference;
using System;
using System.ServiceModel;

namespace SchedulingClients.UserControls
{
    public static class JobBuilderClient_ExtensionMethods
    {
        public static void MultiPickJobTest(this JobBuilderClient jobBuilder)
        {
            try
            {
                JobData jobData = jobBuilder.CreateJob();

                int unorderedListTaskId = jobBuilder.CreateListTask(jobData.OrderedListTaskId, false).Item1;

                int pickTask0Id = jobBuilder.CreateServicingTask(unorderedListTaskId, 1, ServiceType.Pick, TimeSpan.FromSeconds(30)).Item1;

                int pickTask1Id = jobBuilder.CreateServicingTask(unorderedListTaskId, 3, ServiceType.Pick, TimeSpan.FromSeconds(30)).Item1;

                int pickTask2Id = jobBuilder.CreateServicingTask(unorderedListTaskId, 7, ServiceType.Pick, TimeSpan.FromSeconds(30)).Item1;

                int dropTaskId = jobBuilder.CreateServicingTask(jobData.OrderedListTaskId, 10, ServiceType.Drop, TimeSpan.FromSeconds(10)).Item1;

                int parkTaskId = jobBuilder.CreateServicingTask(jobData.OrderedListTaskId, 12, ServiceType.Park, TimeSpan.FromMinutes(5)).Item1;

                bool success = jobBuilder.Commit(jobData.JobId);
            }
            catch (Exception ex)
            {
                if (ex is EndpointNotFoundException)
                {
                    jobBuilder.Logger.Warn("EndpointNotFoundException - is the server running?");
                }
                else
                {
                    jobBuilder.Logger.Error(ex);
                }
            }
        }
    }
}