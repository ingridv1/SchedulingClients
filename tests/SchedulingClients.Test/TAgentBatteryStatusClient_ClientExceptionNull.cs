using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SchedulingClients.AgentBatteryStatusServiceReference;
using BaseClients;

namespace SchedulingClients.Test
{
	[TestFixture]
	[Category("AgentBatteryStatus")]
	public class TAgentBatteryStatusClient_ClientExceptionNull : AbstractClientTest
	{
		[OneTimeSetUp]
		public override void OneTimeSetup()
		{
			base.OneTimeSetup();
			IAgentBatteryStatusClient client = ClientFactory.CreateTcpAgentBatteryStatusClient(settings);
			clients.Add(client);
		}

		IAgentBatteryStatusClient AgentBatteryStatusClient => clients.First(e => e is IAgentBatteryStatusClient) as IAgentBatteryStatusClient;

		[Test]
		[Category("ClientExceptionNull")]
		public void TryGetAllAgentData_ClientExceptionNull()
		{
			IEnumerable<AgentBatteryStatusData> agentBatteryStatusData;
			ServiceOperationResult result = AgentBatteryStatusClient.TryGetAllAgentData(out agentBatteryStatusData);

			Assert.IsNull(result.ClientException);
		}
	}
}
