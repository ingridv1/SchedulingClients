using BaseClients.Architecture;
using BaseClients.Core;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net;

namespace SchedulingClients.Core.Test
{
    public abstract class AbstractInvalidServerClientTest
    {
        protected List<IClient> clients = new List<IClient>();

        [OneTimeSetUp]
        public virtual void OneTimeSetup()
        {
            IPAddress ipAddress = IPAddress.Parse("192.168.255.255");
            settings = new EndpointSettings(ipAddress);
        }

        protected EndpointSettings settings;

        [OneTimeTearDown]
        public virtual void OneTimeTearDown()
        {
            foreach (IClient client in clients)
            {
                client.Dispose();
            }
        }
    }
}