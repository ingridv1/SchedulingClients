using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BaseClients;
using GAAPICommon.Architecture;
using System.IO.IsolatedStorage;
using SchedulingClients.Core;

namespace SchedulingClients.Test
{
	
	[TestFixture]
	[Category("Servicing")]
	public class TServicingClient_ClientExceptionNull : AbstractInvalidServerClientTest
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
			IServiceCallResult result = ServicingClient.SetServiceComplete(1);

			Assert.IsFalse(result.IsSuccessful());
			Assert.AreEqual(4, result.ServiceCode);
		}
	}
}
