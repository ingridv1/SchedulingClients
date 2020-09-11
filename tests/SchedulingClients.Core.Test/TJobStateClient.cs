namespace SchedulingClients.Core.Test
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