using BaseClients;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingClients.Test
{
    /*
    [TestFixture]
    [Category("JobsState")]
    public class TJobsStateClient : AbstractInvalidServerClientTest
    {
        [OneTimeSetUp]
        public override void OneTimeSetup()
        {
            base.OneTimeSetup();

            IJobsStateClient jobsStateClient = ClientFactory.CreateTcpJobsStateClient(settings);
            clients.Add(jobsStateClient);
        }

        IJobsStateClient JobsStateClient => clients.First(e => e is IJobsStateClient) as IJobsStateClient;

        [Test]
        public void AssertZero()
        {
            IEnumerable<int> jobs;
            ServiceOperationResult result = JobsStateClient.TryGetActiveJobIdsForAgent(1, out jobs);

            Assert.IsTrue(result.IsSuccessfull);
            CollectionAssert.IsEmpty(jobs);

        }

    }*/
}
