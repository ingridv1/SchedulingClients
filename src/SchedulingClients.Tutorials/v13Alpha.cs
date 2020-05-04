using BaseClients;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchedulingClients.JobBuilderServiceReference;
using GACore.Architecture;

namespace SchedulingClients.Tutorials
{
    /// <summary>
    ///  Really simple scenario describing how a topload + atomic moves would work.
    /// </summary>
    public class v13Alpha
    {

        /// <summary>
        /// Assumes we have something like
        /// 
        /// -- Node5 --> [Move 6] --> Node ?? --> [Move 7] --> Node ?? --> [Move ??] --> Node 10
        /// 
        /// And we want to trigger the drive by prepare at node 5
        /// this will automatically roll into the drive by traffic light CS
        /// 
        /// AGV will then drive atomically along moves 6 & 7 without stopping in a predictable manner.
        /// 
        /// Finally await further instruction at 10.        /// 
        /// </summary>
        public void Topload()
        {
            IJobBuilderClient jobBuilderClient = ClientFactory.CreateTcpJobBuilderClient(new EndpointSettings());

            // First create job:
            JobData jobData;
            jobBuilderClient.TryCreateJob(out jobData);

            // Add the prepare at node 5
            int prepareTaskId;
            jobBuilderClient.TryCreateServicingTask(jobData.RootOrderedListTaskId, 5, ServiceType.Execution, out prepareTaskId);

            // 16 is DriveBy_Prepare
            jobBuilderClient.TryIssueDirective(prepareTaskId, "CoordinatedScenario", 16);

            // Create atomic moves to follow - begin by creating an atomic move list task
            int atomicMoveListTask;
            jobBuilderClient.TryCreateAtomicMoveListTask(jobData.RootOrderedListTaskId, out atomicMoveListTask);

            // Add atomic moves to this atomic move list task:
            int atomicMove6;
            jobBuilderClient.TryCreateAtomicMoveTask(atomicMoveListTask, 6, out atomicMove6);

            int atomicMove7;
            jobBuilderClient.TryCreateAtomicMoveTask(atomicMoveListTask, 7, out atomicMove7);

            // Finally add an await at Node 10:
            int awaitTaskId;
            jobBuilderClient.TryCreateAwaitingTask(jobData.RootOrderedListTaskId, 10, out awaitTaskId);

            // Commit
            bool success;
            jobBuilderClient.TryCommit(jobData.JobId, out success);
        }
    }
}
