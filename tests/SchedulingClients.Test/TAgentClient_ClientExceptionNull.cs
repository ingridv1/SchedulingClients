using GAAPICommon.Architecture;
using GACore.Architecture;
using NUnit.Framework;
using SchedulingClients.AgentServiceReference;
using System.Collections.Generic;
using System.Linq;

namespace SchedulingClients.Test
{
    [TestFixture]
	[Category("Agent")]
	public class TAgentClient_ClientExceptionNull : AbstractInvalidServerClientTest
	{
		[OneTimeSetUp]
		public override void OneTimeSetup()
		{
			base.OneTimeSetup();
			IAgentClient client = ClientFactory.CreateTcpAgentClient(settings);
			clients.Add(client);
		}

		IAgentClient AgentClient => clients.First(e => e is IAgentClient) as IAgentClient;

		[Test]
		[Category("ClientExceptionNull")]
		public void GetAllAgentData_ClientException()
		{
			IServiceCallResult result = AgentClient.GetAllAgentData();

			Assert.IsFalse(result.IsSuccessful());
			Assert.AreEqual(4, result.ServiceCode);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void GetAllAgentsInLifetimeState_ClientException()
		{
			IServiceCallResult<AgentDto[]> result = AgentClient.GetAllAgentsInLifetimeState(AgentLifetimeState.InService);

			Assert.IsFalse(result.IsSuccessful());
			Assert.AreEqual(4, result.ServiceCode);
		}
	}
}
