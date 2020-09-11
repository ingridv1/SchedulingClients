using GAAPICommon.Architecture;
using NUnit.Framework;
using SchedulingClients.Core;
using System.Linq;

namespace SchedulingClients.Core.Test
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

        private IServicingClient ServicingClient => clients.First(e => e is IServicingClient) as IServicingClient;

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