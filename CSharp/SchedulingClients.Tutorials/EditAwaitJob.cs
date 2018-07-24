using NUnit.Framework;
using Moq;
using SchedulingClients.JobStateServiceReference;
using SchedulingClients.Client_Interfaces;

namespace SchedulingClients.Tutorials
{
    [TestFixture]
    public partial class Examples
    {
        /// <summary>
        /// This assumes the job in the AwaitJobWithDirectives example is already present
        /// 
        ///     Now we want to edit this further to make the agent drop the load at node 15
        ///    
        /// Assumes that kingpin can perform a directive where 
        ///     Parameter id 2 takes a byte value
        ///     A byte value of 11 corresponds to drop an item 
        /// </summary>
        [Test]
        public void EditAwaitJob()
        {
            Mock<IJobBuilderClient> moqJobBuilder = new Mock<IJobBuilderClient>();
            IJobBuilderClient jobBuilder = moqJobBuilder.Object;

            Mock<IJobStateClient> moqJobState = new Mock<IJobStateClient>();
            IJobStateClient jobState = moqJobState.Object;

            //////////////////
            // Actual Calls //
            //////////////////

            JobSummaryData jobSummary;
            jobState.TryGetJobSummary(5, out jobSummary);

            // Determine from the job summary which part of the job you wish to edit.

            if (jobBuilder.TryBeginEditingJob(5).IsSuccessfull)
            {
                // We can edit the job -- add a GoTo Task
                int goToTaskId;
                jobBuilder.TryCreateGoToTask(jobSummary.RootOrderedListTaskId, 15, out goToTaskId);

                // Add a directive
                jobBuilder.TryIssueDirective(goToTaskId, '2', (byte)11); // Assume parameter id '2' vallue 11 is drop

                // Finish editing
                jobBuilder.TryFinishEditingJob(jobSummary.JobId);
            }
        }
    }
}
