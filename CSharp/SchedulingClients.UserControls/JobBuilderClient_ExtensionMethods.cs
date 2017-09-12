using SchedulingClients.JobBuilderServiceReference;
using System;
using System.Linq;
using SchedulingClients.MapServiceReference;
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
                        NodeData pickNode = GetRandomNode(nodes, MapServiceReference.ServiceType.ManualLoadHandling);

                        if (pickNode != null)
                        {
                            int nodeTaskId;
                            jobBuilder.TryCreateServicingTask(unorderedListTaskId, pickNode.MapItemId, JobBuilderServiceReference.ServiceType.ManualLoadHandling, out nodeTaskId, TimeSpan.FromSeconds(30));
                        }
                    }

                    NodeData dropNode = GetRandomNode(nodes, MapServiceReference.ServiceType.ManualLoadHandling);

                    if (dropNode != null)
                    {
                        int dropNodeId;
                        jobBuilder.TryCreateServicingTask(jobData.OrderedListTaskId, dropNode.MapItemId, JobBuilderServiceReference.ServiceType.ManualLoadHandling, out dropNodeId, TimeSpan.FromSeconds(10));
                    }

                    NodeData parkNode = GetRandomNode(nodes, MapServiceReference.ServiceType.Park);

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

        private static NodeData GetRandomNode(IEnumerable<NodeData> nodes, MapServiceReference.ServiceType serviceType)
        {
            List<NodeData> subSet = nodes.Where(e => e.Services.Contains(serviceType)).ToList();

            if (subSet.Any())
            {
                Random random = new Random();
                return subSet[random.Next(0, subSet.Count)];
            }

            return null;
        }
    }
}