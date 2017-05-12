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
            JobData jobData;

            if (jobBuilder.TryCreateJob(out jobData) == true)
            {
                int unorderedListTaskId;
                if (jobBuilder.TryCreateListTask(jobData.OrderedListTaskId, false, out unorderedListTaskId) == true)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        NodeData pickNode = GetRandomNode(nodes, RoadmapServiceReference.ServiceType.Pick);

                        if (pickNode != null)
                        {
                            int nodeTaskId;
                            jobBuilder.TryCreateServicingTask(unorderedListTaskId, pickNode.MapItemId, JobBuilderServiceReference.ServiceType.Pick, out nodeTaskId, TimeSpan.FromSeconds(30));
                        }
                    }

                    NodeData dropNode = GetRandomNode(nodes, RoadmapServiceReference.ServiceType.Drop);

                    if (dropNode != null)
                    {
                        int dropNodeId;
                        jobBuilder.TryCreateServicingTask(jobData.OrderedListTaskId, dropNode.MapItemId, JobBuilderServiceReference.ServiceType.Drop, out dropNodeId, TimeSpan.FromSeconds(10));
                    }

                    NodeData parkNode = GetRandomNode(nodes, RoadmapServiceReference.ServiceType.Park);

                    if (parkNode != null)
                    {
                        int parkNodeId;
                        jobBuilder.TryCreateServicingTask(jobData.OrderedListTaskId, parkNode.MapItemId, JobBuilderServiceReference.ServiceType.Park, out parkNodeId, TimeSpan.FromSeconds(10));
                    }
                }

                bool success;
                jobBuilder.TryCommit(jobData.JobId, out success);
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