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
    public class Basic
    {
        /// <summary>
        /// This describes how to create a job to simply send a vehicle to a target node.
        /// </summary>
        [Test]
        public void GoTo()
        {
            // Setting up moq
            Mock<IJobBuilderClient> mockJobBuilder = new Mock<IJobBuilderClient>();

            //////////////////
            // Actual calls //
            //////////////////
            IJobBuilderClient jobBuilderClient = mockJobBuilder.Object;

            // First we create a job:
            JobData jobData;
            jobBuilderClient.TryCreateJob(out jobData);

            // JobData will contain
            // jobData.JobId -> Job identifier of the job we just created;
            // jobData.OrderedListTaskId -> This is the task Id of the root ordered list task.
        }
    }
}
