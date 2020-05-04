using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SchedulingClients.AgentServiceReference;
using BaseClients;

namespace SchedulingClients.Test
{
	[TestFixture]
	[Category("Agent")]
	public class TAgentClient_ClientExceptionNull : AbstractClientTest
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
		public void TryGetAllAgentData_ClientExceptionNull()
		{
			IEnumerable<AgentData> agentData;
			ServiceOperationResult result = AgentClient.TryGetAllAgentData(out agentData);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryGetAllAgentsInLifetimeState_ClientExceptionNull()
		{
			IEnumerable<AgentData> agentData;
			ServiceOperationResult result = AgentClient.TryGetAllAgentsInLifetimeState(out agentData, AgentLifetimeState.InService);

			Assert.IsNull(result.ClientException);
		}
	}
}
