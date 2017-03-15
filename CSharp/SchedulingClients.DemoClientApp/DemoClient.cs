using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows;

namespace SchedulingClients.DemoClientApp
{
    /// <summary>
    /// Simple client to the scheduling wrappers.
    /// </summary>
    public class DemoClient : IDisposable
    {
        private ObservableCollection<IClient> clients = new ObservableCollection<IClient>();

        private bool isConfigured = false;

        private bool isDisposed = false;

        private ReadOnlyObservableCollection<IClient> readOnlyClients;

        public DemoClient()
        {
            readOnlyClients = new ReadOnlyObservableCollection<IClient>(clients);
        }

        ~DemoClient()
        {
            Dispose(false);
        }

        public ReadOnlyObservableCollection<IClient> Clients { get { return readOnlyClients; } }

        public bool IsConfigured { get { return isConfigured; } }

        public bool IsDisposed { get { return isDisposed; } }

        public JobBuilderClient JobBuilderClient { get { return (JobBuilderClient)clients.FirstOrDefault(e => e is JobBuilderClient); } }

        public RoadmapClient MapClient { get { return (RoadmapClient)clients.FirstOrDefault(e => e is RoadmapClient); } }

        public ServicingClient ServicingClient { get { return (ServicingClient)clients.FirstOrDefault(e => e is ServicingClient); } }

        public void Configure(EndpointSettings endpointSettings)
        {
            if (IsConfigured)
            {
                return;
            }

            JobBuilderClient jobBuilderClient = new JobBuilderClient(endpointSettings.TcpJobBuilderService());
            clients.Add(jobBuilderClient);

            RoadmapClient mapClient = new RoadmapClient(endpointSettings.TcpMapService());
            clients.Add(mapClient);

            ServicingClient servicingClient = new ServicingClient(endpointSettings.TcpServicingService());
            clients.Add(servicingClient);

            isConfigured = true;
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
                if (!Application.Current.Dispatcher.HasShutdownStarted)
                {
                    Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        client.Dispose();
                        clients.Remove(client);
                    }));
                }
            }

            isDisposed = true;
        }
    }
}