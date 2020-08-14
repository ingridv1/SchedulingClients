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
    public class TJobStateClient : AbstractInvalidServerClientTest
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
        [Category("ClientExceptionNull")]
        public void TryGetJobSummary_ClientExceptionNull()
        {
            JobSummaryData jobSummaryData;
            ServiceOperationResult result = JobStateClient.TryGetJobSummary(-1, out jobSummaryData);

            Assert.IsNull(result.ClientException);
        }

    }*/
}
