namespace SchedulingClients.Core.Test
{
    /*
	[TestFixture]
	[Category("JobBuilder")]
	public class TJobBuilderClient_ClientExceptionNull : AbstractInvalidServerClientTest
	{
		[OneTimeSetUp]
		public override void OneTimeSetup()
		{
			base.OneTimeSetup();

			IJobBuilderClient jobBuilderClient = ClientFactory.CreateTcpJobBuilderClient(settings);
			clients.Add(jobBuilderClient);
		}

		IJobBuilderClient JobBuilderClient => clients.First(e => e is IJobBuilderClient) as IJobBuilderClient;

		[Test]
		[Category("ClientExceptionNull")]
		public void TryCommit_ClientExceptionNull()
		{
			bool success;
			ServiceOperationResult result = JobBuilderClient.TryCommit(1, out success);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryCreateJob_ClientExceptionNull()
		{
			JobData jobData = null;
			ServiceOperationResult result = JobBuilderClient.TryCreateJob(out jobData);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryCreateOrderedListTask_ClientExceptionNull()
		{
			int taskId;
			ServiceOperationResult result = JobBuilderClient.TryCreateOrderedListTask(1, out taskId);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryCreateUnorderedListTask_ClientExceptionNull()
		{
			int taskId;
			ServiceOperationResult result = JobBuilderClient.TryCreateUnorderedListTask(1, out taskId);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryCreateAtomicMoveListTask_ClientExceptionNull()
		{
			int taskId;
			ServiceOperationResult result = JobBuilderClient.TryCreateAtomicMoveListTask(1, out taskId);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryCreateServicingTask_ClientExceptionNull()
		{
			int taskId;
			ServiceOperationResult result = JobBuilderClient.TryCreateServicingTask(1, 1, ServiceType.Fault, out taskId);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryCreateSleepingTask_ClientExceptionNull()
		{
			int taskId;
			ServiceOperationResult result = JobBuilderClient.TryCreateSleepingTask(1, 1, out taskId);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryCreateGoToNodeTask_ClientExceptionNull()
		{
			int goToNodeTaskId;
			ServiceOperationResult result = JobBuilderClient.TryCreateGoToNodeTask(1, 1, out goToNodeTaskId);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryCreateAwaitingTask_ClientExceptionNull()
		{
			int taskId;
			ServiceOperationResult result = JobBuilderClient.TryCreateAwaitingTask(1, 1, out taskId);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryIssueShortDirective_ClientExceptionNull()
		{
			short value = -12;
			ServiceOperationResult result = JobBuilderClient.TryIssueDirective(1, "test", value);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryIssueUShortDirective_ClientExceptionNull()
		{
			ushort value = 12;
			ServiceOperationResult result = JobBuilderClient.TryIssueDirective(1, "test", value);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryIssueByteDirective_ClientExceptionNull()
		{
			byte value = 12;
			ServiceOperationResult result = JobBuilderClient.TryIssueDirective(1, "test", value);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryIssueFloatDirective_ClientExceptionNull()
		{
			float value = 12.5f;
			ServiceOperationResult result = JobBuilderClient.TryIssueDirective(1, "test", value);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryIssueIPAddressDirective_ClientExceptionNull()
		{
			IPAddress value = IPAddress.Parse("192.66.0.1");
			ServiceOperationResult result = JobBuilderClient.TryIssueDirective(1, "test", value);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryBeginEditingJob_ClientExceptionNull()
		{
			ServiceOperationResult result = JobBuilderClient.TryBeginEditingJob(1);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryFinishEditingJob_ClientExceptionNull()
		{
			ServiceOperationResult result = JobBuilderClient.TryFinishEditingJob(1);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryBeginEditingTask_ClientExceptionNull()
		{
			ServiceOperationResult result = JobBuilderClient.TryBeginEditingTask(1);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryFinishEditingTask_ClientExceptionNull()
		{
			ServiceOperationResult result = JobBuilderClient.TryFinishEditingTask(1);

			Assert.IsNull(result.ClientException);
		}
	}*/
}