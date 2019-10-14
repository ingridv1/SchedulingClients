using SchedulingClients.JobBuilderServiceReference;
using System;
using System.Linq;
using SchedulingClients.MapServiceReference;
using System.Collections.Generic;
using System.Windows;
using BaseClients;
using GACore.Architecture;

namespace SchedulingClients.UserControls
{
    public static class JobBuilderClient_ExtensionMethods
    {
        private static int HandleCreatedUnorderedListTask(IJobBuilderClient jobBuilder, int parentListTaskId)
        {
            int unorderedListTaskId;

            ServiceOperationResult result = jobBuilder.TryCreateUnorderedListTask(parentListTaskId, out unorderedListTaskId);

            if (!result.IsSuccessfull)
            {
                MessageBox.Show("Failed to create unordered list task");
            }

            return unorderedListTaskId;
        }

        public static void MultiPickJobTest(this IJobBuilderClient jobBuilder, IEnumerable<NodeData> nodes)
        {
            JobData jobData;

            if (jobBuilder.TryCreateJob(out jobData) == true)
            {
                int unorderedListTaskId = HandleCreatedUnorderedListTask(jobBuilder, jobData.RootOrderedListTaskId);

                if (unorderedListTaskId >= 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        NodeData pickNode = GetRandomNode(nodes, ServiceType.ManualLoadHandling);

                        if (pickNode != null)
                        {
                            int nodeTaskId;
                            jobBuilder.TryCreateServicingTask(unorderedListTaskId, pickNode.MapItemId, ServiceType.ManualLoadHandling, out nodeTaskId, TimeSpan.FromSeconds(30));
                        }
                    }

                    NodeData dropNode = GetRandomNode(nodes, ServiceType.ManualLoadHandling);

                    if (dropNode != null)
                    {
                        int dropNodeId;
                        jobBuilder.TryCreateServicingTask(jobData.RootOrderedListTaskId, dropNode.MapItemId, ServiceType.ManualLoadHandling, out dropNodeId, TimeSpan.FromSeconds(10));
                    }

                    NodeData parkNode = GetRandomNode(nodes, ServiceType.Park);

                    if (parkNode != null)
                    {
                        int parkNodeId;
                        jobBuilder.TryCreateServicingTask(jobData.RootOrderedListTaskId, parkNode.MapItemId, ServiceType.Park, out parkNodeId, TimeSpan.FromSeconds(10));
                    }
                }

                bool success;
                if (jobBuilder.TryCommit(jobData.JobId, out success) != true)
                {
                    MessageBox.Show(string.Format("Failed to commit job with jobId: {0}", jobData.JobId));
                }
            }
            else
            {
                MessageBox.Show("Failed to create job.");
            }
        }

        public static void MoveJobTest(this IJobBuilderClient jobBuilder, IEnumerable<NodeData> nodes, bool isFinalised)
        {
#warning NEEDS REFACTOR

            JobData jobData;

            if (jobBuilder.TryCreateJob(out jobData) == true)
            {
                int atomicMoveListTaskId;
                jobBuilder.TryCreateAtomicMoveListTask(jobData.RootOrderedListTaskId, out atomicMoveListTaskId);

               // NodeData pickNode = GetRandomNode(nodes, MapServiceReference.ServiceType.ManualLoadHandling);
                //NodeData pickNode2 = GetRandomNode(nodes, MapServiceReference.ServiceType.Charge);

                int pickNodeId, pickNodeId2;
               // jobBuilder.TryCreateMovingTask(piplineId, pickNode.MapItemId, out pickNodeId);
                //jobBuilder.TryCreateMovingTask(piplineId, pickNode2.MapItemId, out pickNodeId2);

                bool success;
                jobBuilder.TryCommit(jobData.JobId, out success);
            }
        }

        private static NodeData GetRandomNode(IEnumerable<NodeData> nodes, ServiceType serviceType)
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