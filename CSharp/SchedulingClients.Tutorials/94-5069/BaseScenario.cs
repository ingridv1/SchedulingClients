using Moq;
using NUnit.Framework;
using SchedulingClients.JobBuilderServiceReference;
using SchedulingClients;

namespace SchedulingClients.Tutorials
{
    [TestFixture]
    [Category("94-5069")]
    public partial class Examples945069
    {
        /// <summary>
        /// This describes how to send any agent:
        /// 
        ///     Receive an item at node 6 and then await for tasks at node 10
        /// 
        ///     This breaks down into three main calls:
        /// 
        ///     Service at node 6 with service type execute
        ///     Use a directive at node 6
        ///     Then drive towards node 10 and await for tasks
        ///     
        /// Assumes that kingpin can perform a directive where 
        ///     Parameter alias "BagV.CoordinatedScenario"
        ///     A byte value of 83 corresponds to DOCK_RIGHT_LOAD 
        /// </summary>
        [Test]
        public void AwaitJobWithDirectives()
        {
            Mock<IJobBuilderClient> moqJobBuilder = new Mock<IJobBuilderClient>();

            JobData jobDataMoq = new JobData() { JobId = 5, RootOrderedListTaskId = 8 };
            moqJobBuilder.Setup(e => e.TryCreateJob(out jobDataMoq));

            IJobBuilderClient jobBuilder = moqJobBuilder.Object;


            //////////////////
            // Actual Calls //
            //////////////////

            int nodeA = 6;

            // First we create a job
            JobData jobData;
            jobBuilder.TryCreateJob(out jobData);

            // Create a node task to go to the target node
            int nodeATaskId;
            jobBuilder.TryCreateServicingTask(jobData.RootOrderedListTaskId, nodeA, ServiceType.Execution, out nodeATaskId);

            // Issue a directive to this task, parameter "BagV.CoordinatedScenario", with value 83 'DOCK_RIGHT_LOAD'
            jobBuilder.TryIssueDirective(nodeATaskId, "BagV.CoordinatedScenario", (byte)83);

            // Create an await task
            int node10TaskId;
            jobBuilder.TryCreateAwaitingTask(jobData.RootOrderedListTaskId, 10, out node10TaskId);

            // Finally commit the job
            bool success;
            jobBuilder.TryCommit(jobData.JobId, out success);

        }
    }
}
