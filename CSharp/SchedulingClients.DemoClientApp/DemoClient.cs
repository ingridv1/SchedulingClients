using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Net;

namespace SchedulingClients.DemoClientApp
{
    public class DemoClient : IDisposable
    {
        private readonly int httpPort;

        private readonly IPAddress ipAddress;

        private readonly int tcpPort;

        private ObservableCollection<IClient> clients = new ObservableCollection<IClient>();

        private bool isDisposed = false;

        private ReadOnlyObservableCollection<IClient> readOnlyClients;

        public DemoClient(IPAddress ipAddress, int httpPort, int tcpPort)
        {
            this.ipAddress = ipAddress;
            this.httpPort = httpPort;
            this.tcpPort = tcpPort;

            readOnlyClients = new ReadOnlyObservableCollection<IClient>(clients);

            Configure();
        }

        ~DemoClient()
        {
            Dispose(false);
        }

        public ReadOnlyObservableCollection<IClient> Clients { get { return readOnlyClients; } }

        public bool IsDisposed { get { return isDisposed; } }

        public JobBuilderClient JobBuilderClient { get { return (JobBuilderClient)clients.FirstOrDefault(e => e is JobBuilderClient); } }

        public RoadmapClient RoadmapClient { get { return (RoadmapClient)clients.FirstOrDefault(e => e is RoadmapClient); } }

        public ServicingClient ServicingClient { get { return (ServicingClient)clients.FirstOrDefault(e => e is ServicingClient); } }

        public void Configure()
        {
            EndpointSettings endpointSettings = new EndpointSettings(ipAddress, httpPort, tcpPort);

            JobBuilderClient jobBuilderClient = new JobBuilderClient(endpointSettings.TcpJobBuilderService());
            clients.Add(jobBuilderClient);

            RoadmapClient mapClient = new RoadmapClient(endpointSettings.TcpMapService());
            clients.Add(mapClient);

            ServicingClient servicingClient = new ServicingClient(endpointSettings.TcpServicingService());
            clients.Add(servicingClient);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool isDisposing)
        {
            if (isDisposed)
            {
                return;
            }

            foreach (IClient client in clients.ToList())
            {
                client.Dispose();
                clients.Remove(client);
            }

            isDisposed = true;
        }
    }
}