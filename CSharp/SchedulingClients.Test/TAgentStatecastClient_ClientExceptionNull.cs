using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SchedulingClients.AgentStatecastServiceReference;
using BaseClients;
using System.Net;

namespace SchedulingClients.Test
{
	[TestFixture]
	[Category("AgentStatecast")]
	public class TAgentStatecastClient_ClientExceptionNull : AbstractClientTest
	{
		[OneTimeSetUp]
		public override void OneTimeSetup()
		{
			base.OneTimeSetup();
			IAgentStatecastClient client = ClientFactory.CreateTcpAgentStatecastClient(settings);
			clients.Add(client);
		}

		IAgentStatecastClient AgentStatecastClient => clients.First(e => e is IAgentStatecastClient) as IAgentStatecastClient;

		[Test]
		[Category("ClientExceptionNull")]
		public void TryGetStatecastVariableDefinitionData_ClientExceptionNull()
		{
			IEnumerable<StateCastVariableDefinitionData> data;
			ServiceOperationResult result = AgentStatecastClient.TryGetStateCastVariableDefinitionData(1, out data);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryGetEnumStatecastValue_ClientExceptionNull()
		{
			byte value;
			ServiceOperationResult result = AgentStatecastClient.TryGetEnumStatecastValue(1, "test", out value);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryGetFloatStatecastValue_ClientExceptionNull()
		{
			float value;
			ServiceOperationResult result = AgentStatecastClient.TryGetFloatStatecastValue(1, "test", out value);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryGetShortStatecastValue_ClientExceptionNull()
		{
			short value;
			ServiceOperationResult result = AgentStatecastClient.TryGetShortStatecastValue(1, "test", out value);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryGetUShortStatecastValue_ClientExceptionNull()
		{
			ushort value;
			ServiceOperationResult result = AgentStatecastClient.TryGetUShortStatecastValue(1, "test", out value);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryGetIntegerStatecastValue_ClientExceptionNull()
		{
			int value;
			ServiceOperationResult result = AgentStatecastClient.TryGetIntegerStatecastValue(1, "test", out value);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryGetUIntegerStatecastValue_ClientExceptionNull()
		{
			uint value;
			ServiceOperationResult result = AgentStatecastClient.TryGetUIntegerStatecastValue(1, "test", out value);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryGetIPAddressStatecastValue_ClientExceptionNull()
		{
			IPAddress value;
			ServiceOperationResult result = AgentStatecastClient.TryGetIPAddressStatecastValue(1, "test", out value);

			Assert.IsNull(result.ClientException);
		}
	}
}
