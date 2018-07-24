using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SchedulingClients.JobBuilderServiceReference;
using Moq;

namespace SchedulingClients.Tutorials
{
    [TestFixture]
    public partial class Examples
    {
        /// <summary>
        /// This describes how to create a job to simply send any agent
        ///     GoTo node 6
        /// </summary>
        [Test]
        public void GoTo()
        {
            // Setting up moq
            Mock<IJobBuilderClient> mockJobBuilder = new Mock<IJobBuilderClient>();
#warning setup moq here

            IJobBuilderClient jobBuilderClient = mockJobBuilder.Object;
            
            //////////////////
            // Actual calls //
            //////////////////

            // First we create a job:
            JobData jobData;
            jobBuilderClient.TryCreateJob(out jobData);

            // JobData will contain
            // jobData.JobId -> Job identifier of the job we just created;
            // jobData.OrderedListTaskId -> This is the task Id of the root ordered list task.

            // Now we create the GoTo task 
            // Here we are adding it the the orderedListTask
            // Sending to node 6
            // With the ServiceType GoTo:

            int gotoTaskId;
            jobBuilderClient.TryCreateServicingTask(jobData.RootOrderedListTaskId, 6, ServiceType.GoTo, out gotoTaskId);

            // Finally we commit the job
            bool success;
            jobBuilderClient.TryCommit(jobData.JobId, out success);
        }
    }
}
