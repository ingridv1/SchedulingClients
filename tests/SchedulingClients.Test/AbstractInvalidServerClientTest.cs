using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BaseClients;
using System.Net;
using BaseClients.Architecture;
using BaseClients.Core;

namespace SchedulingClients.Test
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
            foreach(IClient client in clients)
            {
                client.Dispose();
            }
        }
    }
}
