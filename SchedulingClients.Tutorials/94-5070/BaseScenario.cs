using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using SchedulingClients.JobBuilderServiceReference;
using GACore.Architecture;

namespace SchedulingClients.Tutorials
{
    [TestFixture]
    [Category("94-5070")]
    public class BaseScenario_94_5070
    {
        public void BaseScenario()
        {
            int receiveNodeId = 0;
            int dropNodeId = 6;
            int receive = 4;// enumeration for passive receive
            int drop = 3; // enumeration for passive drop

            Mock<IJobBuilderClient> moqJobBuilder = new Mock<IJobBuilderClient>();
            IJobBuilderClient jobBuilder = moqJobBuilder.Object;

            //////////////////
            // Actual Calls //
            //////////////////

            // Create Job
            JobData jobData;
            jobBuilder.TryCreateJob(out jobData);

            // Receive tote
            int receiveTaskId;
            jobBuilder.TryCreateServicingTask(jobData.RootOrderedListTaskId, receiveNodeId, ServiceType.Execution, out receiveTaskId);
            jobBuilder.TryIssueDirective(receiveTaskId, "DockType", receive);

            // Drop tote
            int dropTaskId;
            jobBuilder.TryCreateServicingTask(jobData.RootOrderedListTaskId, dropNodeId, ServiceType.Execution, out dropTaskId);
            jobBuilder.TryIssueDirective(receiveTaskId, "DockType", drop);

            // Go to the start
            int goToTaskId;
            jobBuilder.TryCreateGoToNodeTask(jobData.RootOrderedListTaskId, receiveNodeId, out goToTaskId);

            bool success;
            jobBuilder.TryCommit(jobData.JobId, out success); // Commits this job for next available agent. 
        }
    }
}
