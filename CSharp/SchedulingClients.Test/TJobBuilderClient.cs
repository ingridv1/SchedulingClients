using NUnit.Framework;
using SchedulingClients.JobBuilderServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseClients;
using System.Threading.Tasks;

namespace SchedulingClients.Test
{
    [TestFixture]
    [Category("JobBuilder")]
    public class TJobBuilderClient : AbstractClientTest
    {
        [OneTimeSetUp]
        public override void OneTimeSetup()
        {
            base.OneTimeSetup();

            IMapClient mapClient = ClientFactory.CreateTcpMapClient(settings);
            clients.Add(mapClient);

            IJobBuilderClient jobBuilderClient = ClientFactory.CreateTcpJobBuilderClient(settings);
            clients.Add(jobBuilderClient);  
        }

        IJobBuilderClient JobBuilderClient => clients.First(e => e is IJobBuilderClient) as IJobBuilderClient;

        IMapClient MapClient => clients.First(e => e is IMapClient) as IMapClient;

        [Test]
        public void CreateJob()
        {
            JobData jobData = null;
            ServiceOperationResult result = JobBuilderClient.TryCreateJob(out jobData);

            Assert.IsNotNull(jobData);
            Assert.IsTrue(result.IsSuccessfull);
        }

    }
}
