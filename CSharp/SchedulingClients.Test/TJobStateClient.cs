using BaseClients;
using NUnit.Framework;
using SchedulingClients.JobStateServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingClients.Test
{
    [TestFixture]
    [Category("JobState")]
    public class TJobStateClient : AbstractClientTest
    {
        [OneTimeSetUp]
        public override void OneTimeSetup()
        {
            base.OneTimeSetup();

            IJobStateClient jobStateClient = ClientFactory.CreateTcpJobStateClient(settings);
            clients.Add(jobStateClient);
        }

        IJobStateClient JobStateClient => clients.First(e => e is IJobStateClient) as IJobStateClient;

        [Test]
        public void AssertZero()
        {
            JobSummaryData jobSummaryData;
            ServiceOperationResult result = JobStateClient.TryGetJobSummary(-1, out jobSummaryData);

            Assert.IsFalse(result.IsSuccessfull);
        }

    }
}
