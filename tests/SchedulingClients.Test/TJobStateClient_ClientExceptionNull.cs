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
	[Category("JobState")]
	public class TJobStateClient_ClientExceptionNull : AbstractInvalidServerClientTest
	{
		[OneTimeSetUp]
		public override void OneTimeSetup()
		{
			base.OneTimeSetup();
			IJobStateClient client = ClientFactory.CreateTcpJobStateClient(settings);
			clients.Add(client);
		}

		IJobStateClient JobStateClient => clients.First(e => e is IJobStateClient) as IJobStateClient;

		[Test]
		[Category("ClientExceptionNull")]
		public void TryGetJobSummary_ClientExceptionNull()
		{
			JobSummaryData data;
			ServiceOperationResult result = JobStateClient.TryGetJobSummary(1, out data);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryGetParentJobSummaryFromTaskId_ClientExceptionNull()
		{
			JobSummaryData data;
			ServiceOperationResult result = JobStateClient.TryGetParentJobSummaryFromTaskId(1, out data);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryGetCurrentJobSummaryForAgentId_ClientExceptionNull()
		{
			JobSummaryData data;
			ServiceOperationResult result = JobStateClient.TryGetCurrentJobSummaryForAgentId(1, out data);

			Assert.IsNull(result.ClientException);
		}
	}*/
}
