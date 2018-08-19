using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BaseClients;
using System.Net;

namespace SchedulingClients.Test
{
    public abstract class AbstractClientTest
    {
        protected List<IClient> clients = new List<IClient>();

        [OneTimeSetUp]
        public virtual void OneTimeSetup()
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
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
