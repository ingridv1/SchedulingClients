using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;

namespace SchedulingClients.DemoClientApp
{
    public class DemoClient : IDisposable
    {
        private ObservableCollection<IClient> clients = new ObservableCollection<IClient>();

        private EndpointSettings endpointSettings;
        private bool isDisposed = false;

        private ReadOnlyObservableCollection<IClient> readOnlyClients;

        public DemoClient(IPAddress ipAddress, int httpPort, int tcpPort)
        {
            this.endpointSettings = new EndpointSettings(ipAddress, httpPort, tcpPort);

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

        public JobsStateClient JobsStateClient { get { return (JobsStateClient)clients.FirstOrDefault(e => e is JobsStateClient); } }

        public RoadmapClient RoadmapClient { get { return (RoadmapClient)clients.FirstOrDefault(e => e is RoadmapClient); } }

        public ServicingClient ServicingClient { get { return (ServicingClient)clients.FirstOrDefault(e => e is ServicingClient); } }

        public void Configure()
        {
            JobsStateClient jobsStateClient = new JobsStateClient(endpointSettings.TcpJobsStateService());
            clients.Add(jobsStateClient);

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