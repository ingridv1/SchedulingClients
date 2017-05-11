using SchedulingClients.JobBuilderServiceReference;
using System;
using System.Linq;
using System.ServiceModel;
using SchedulingClients.RoadmapServiceReference;
using System.Collections.Generic;

namespace SchedulingClients.UserControls
{
    public static class JobBuilderClient_ExtensionMethods
    {
        public static void MultiPickJobTest(this JobBuilderClient jobBuilder, IEnumerable<NodeData> nodes)
        {
            try
            {
                JobData jobData = jobBuilder.CreateJob();

                int unorderedListTaskId = jobBuilder.CreateListTask(jobData.OrderedListTaskId, false).Item1;

                for (int i = 0; i < 3; i++)
                {
                    NodeData pickNode = GetRandomNode(nodes, RoadmapServiceReference.ServiceType.Pick);

                    if (pickNode != null)
                    {
                        jobBuilder.CreateServicingTask(unorderedListTaskId, pickNode.MapItemId, JobBuilderServiceReference.ServiceType.Pick, TimeSpan.FromSeconds(30));
                    }
                }

                NodeData dropNode = GetRandomNode(nodes, RoadmapServiceReference.ServiceType.Drop);
                if (dropNode != null)
                {
                    jobBuilder.CreateServicingTask(jobData.OrderedListTaskId, dropNode.MapItemId, JobBuilderServiceReference.ServiceType.Drop, TimeSpan.FromSeconds(10));
                }

                NodeData parkNode = GetRandomNode(nodes, RoadmapServiceReference.ServiceType.Park);
                if (parkNode != null)
                {
                    jobBuilder.CreateServicingTask(jobData.OrderedListTaskId, parkNode.MapItemId, JobBuilderServiceReference.ServiceType.Park, TimeSpan.FromSeconds(10));
                }

                jobBuilder.Commit(jobData.JobId);
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

        private static NodeData GetRandomNode(IEnumerable<NodeData> nodes, RoadmapServiceReference.ServiceType serviceType)
        {
            List<NodeData> subSet = nodes.Where(e => e.Services.Contains(serviceType)).ToList();

            if (subSet.Any())
            {
                Random random = new Random();
                return subSet[random.Next(0, subSet.Count - 1)];
            }

            return null;
        }
    }
}