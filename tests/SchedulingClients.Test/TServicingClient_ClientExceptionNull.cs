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
	[Category("Servicing")]
	public class TServicingClient_ClientExceptionNull : AbstractClientTest
	{
		[OneTimeSetUp]
		public override void OneTimeSetup()
		{
			base.OneTimeSetup();
			IServicingClient client = ClientFactory.CreateTcpServicingClient(settings);
			clients.Add(client);
		}

		IServicingClient ServicingClient => clients.First(e => e is IServicingClient) as IServicingClient;

		[Test]
		[Category("ClientExceptionNull")]
		public void TryGetServicingClient_ClientExceptionNull()
		{
			bool success;
			ServiceOperationResult result = ServicingClient.TrySetServiceComplete(1, out success);

			Assert.IsNull(result.ClientException);
		}
	}
}
