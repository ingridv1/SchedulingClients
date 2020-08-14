using NUnit.Framework;
using SchedulingClients.JobBuilderServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseClients;
using System.Threading.Tasks;
using System.Net;

namespace SchedulingClients.Test
{
    /*
    [TestFixture]
    [Category("JobBuilder")]
    public class TJobBuilderClient : AbstractInvalidServerClientTest
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
        public void CreateInvalidGoToTask()
        {
            int goToTaskId;
            ServiceOperationResult result = JobBuilderClient.TryCreateGoToNodeTask(1,2,out goToTaskId);

            Assert.IsFalse(result.IsSuccessfull);
            Assert.IsNull(result.ClientException);
            Assert.IsTrue(result.IsServiceError);
        }


        [Test]
        public void CommitInvalidJob()
        {
            bool success;

            ServiceOperationResult result = JobBuilderClient.TryCommit(-1, out success);

            Assert.IsFalse(result.IsSuccessfull);
            Assert.IsNull(result.ClientException);
            Assert.IsTrue(result.IsServiceError);
        }

        [Test]
        public void CreateJob()
        {
            JobData jobData = null;

            ServiceOperationResult result = JobBuilderClient.TryCreateJob(out jobData);         

            Assert.IsTrue(result.IsSuccessfull);
            Assert.IsNotNull(jobData);
        }
	}*/
}
