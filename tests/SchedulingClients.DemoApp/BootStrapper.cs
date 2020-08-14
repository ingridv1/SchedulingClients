using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BaseClients.Core;
using SchedulingClients.Core;
using System.Net;
using SchedulingClients.UI.ViewModel;

namespace SchedulingClients.DemoApp
{
    public static class BootStrapper
    {
        public static void Activate()
        {
            EndpointSettings endpointSettings = new EndpointSettings(IPAddress.Loopback);

            IMapClient mapClient = ClientFactory.CreateTcpMapClient(endpointSettings);

            ViewModelLocator.MapViewModel.Model = mapClient;
        }
    }
}
