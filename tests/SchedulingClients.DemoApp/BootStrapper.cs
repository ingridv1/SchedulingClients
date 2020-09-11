using BaseClients.Core;
using SchedulingClients.Core;
using SchedulingClients.UI.ViewModel;
using System.Net;

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