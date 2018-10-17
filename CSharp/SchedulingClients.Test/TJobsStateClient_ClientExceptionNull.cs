using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BaseClients;

namespace SchedulingClients.Test
{
	[TestFixture]
	[Category("JobsState")]
	public class TJobsStateClient_ClientExceptionNull : AbstractClientTest
	{
		[OneTimeSetUp]
		public override void OneTimeSetup()
		{
			base.OneTimeSetup();
			IJobsStateClient client = ClientFactory.CreateTcpJobsStateClient(settings);
			clients.Add(client);
		}

		IJobsStateClient JobsStateClient => clients.First(e => e is IJobsStateClient) as IJobsStateClient;

		[Test]
		[Category("ClientExceptionNull")]
		public void TryAbortAllJobs_ClientExceptionNull()
		{
			bool success;
			ServiceOperationResult result = JobsStateClient.TryAbortAllJobs(out success);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryAbortJob_ClientExceptionNull()
		{
			bool success;
			ServiceOperationResult result = JobsStateClient.TryAbortJob(1, out success);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryAbortTask_ClientExceptionNull()
		{
			bool success;
			ServiceOperationResult result = JobsStateClient.TryAbortTask(1, out success);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryGetActiveJobIdsForAgent_ClientExceptionNull()
		{
			IEnumerable<int> jobIds;
			ServiceOperationResult result = JobsStateClient.TryGetActiveJobIdsForAgent(1, out jobIds);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryResolveFaultedTask_ClientExceptionNull()
		{
			bool success;
			ServiceOperationResult result = JobsStateClient.TryResolveFailingTask(1, out success);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryResolveFaultedJob_ClientExceptionNull()
		{
			bool success;
			ServiceOperationResult result = JobsStateClient.TryResolveFailingJob(1, out success);

			Assert.IsNull(result.ClientException);
		}
	}
}
