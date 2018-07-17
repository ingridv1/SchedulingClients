using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using NLog;
using System.IO;
using NLog.Targets;
using NLog.Config;
using GAClients;

namespace SchedulingClients.DemoClientApp
{
    public class DemoClient : IDisposable
    {
        private readonly string logFolderPath;

        private ObservableCollection<IClient> clients = new ObservableCollection<IClient>();

        private EndpointSettings endpointSettings;

        private bool isDisposed = false;

        private ReadOnlyObservableCollection<IClient> readOnlyClients;

        public DemoClient(IPAddress ipAddress, int httpPort, int tcpPort )
        {
            this.endpointSettings = new EndpointSettings(ipAddress, httpPort, tcpPort);
            readOnlyClients = new ReadOnlyObservableCollection<IClient>(clients);

            logFolderPath = Path.Combine(Path.GetTempPath(), "Scheduling Clients Demo Client App");
            Directory.CreateDirectory(logFolderPath);

            Configure();
        }

        ~DemoClient()
        {
            Dispose(false);
        }

		public AgentAttentionClient AgentAttentionClient { get { return (AgentAttentionClient)clients.FirstOrDefault(e => e is AgentAttentionClient); } }

		public AgentClient AgentClient { get { return (AgentClient)clients.FirstOrDefault(e => e is AgentClient); } }

        public AgentBatteryStatusClient AgentBatteryStatusClient { get { return (AgentBatteryStatusClient)clients.FirstOrDefault(e => e is AgentBatteryStatusClient); } }

		public AgentStatecastClient AgentStatecastClient { get { return (AgentStatecastClient)clients.FirstOrDefault(e => e is AgentStatecastClient); } }

		public ReadOnlyObservableCollection<IClient> Clients { get { return readOnlyClients; } }

        public FleetManagerClient FleetManagerClient { get { return (FleetManagerClient)clients.FirstOrDefault(e => e is FleetManagerClient); } }

        public bool IsDisposed { get { return isDisposed; } }

        public JobBuilderClient JobBuilderClient { get { return (JobBuilderClient)clients.FirstOrDefault(e => e is JobBuilderClient); } }

        public JobsStateClient JobsStateClient { get { return (JobsStateClient)clients.FirstOrDefault(e => e is JobsStateClient); } }

        public JobStateClient JobStateClient { get { return (JobStateClient)clients.FirstOrDefault(e => e is JobStateClient); } }

        public string LogFolderPath { get { return logFolderPath; } }

        public MapClient RoadmapClient { get { return (MapClient)clients.FirstOrDefault(e => e is MapClient); } }

        public ServicingClient ServicingClient { get { return (ServicingClient)clients.FirstOrDefault(e => e is ServicingClient); } }

        public VersionClient VersionClient { get { return (VersionClient)clients.FirstOrDefault(e => e is VersionClient); } }

        public void Configure()
        {
            clients.Add(ClientFactory.CreateTcpAgentClient(endpointSettings));
            clients.Add(ClientFactory.CreateTcpAgentBatteryStatusClient(endpointSettings));
            clients.Add(ClientFactory.CreateTcpFleetManagerClient(endpointSettings));

            clients.Add(ClientFactory.CreateTcpJobBuilderClient(endpointSettings));

            clients.Add(ClientFactory.CreateTcpJobStateClient(endpointSettings));
            clients.Add(ClientFactory.CreateTcpJobsStateClient(endpointSettings));

            clients.Add(ClientFactory.CreateTcpRoadmapClient(endpointSettings));
            clients.Add(ClientFactory.CreateTcpServicingClient(endpointSettings));

			clients.Add(ClientFactory.CreateTcpAgentAttentionClient(endpointSettings));
			clients.Add(ClientFactory.CreateTcpAgentStatecastClient(endpointSettings));

            clients.Add(ClientFactory.CreateTcpVersionClient(endpointSettings));

            LogManager.Configuration = new LoggingConfiguration();

            foreach (IClient client in clients)
            {
                client.Logger = GetLogger(client);
            }
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

        private Logger GetLogger(IClient client)
        {
            string name = client.GetType().Name;

            FileTarget target = new FileTarget(name);
            target.Layout = @"${processtime} ${level: padding = -8:padCharacter = } ${message}";
            target.FileName = Path.Combine(new[] { logFolderPath, name + ".log" });

            LoggingRule rule = new LoggingRule(name, LogLevel.Trace, target);
            LogManager.Configuration.LoggingRules.Add(rule);
            LogManager.Configuration.AddTarget(target);

            LogManager.ReconfigExistingLoggers();

            return LogManager.GetLogger(name);
        }
    }
}