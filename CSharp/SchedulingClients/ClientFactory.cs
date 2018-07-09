using GAClients;

namespace SchedulingClients
{
    public static class ClientFactory
    {
        public static IAgentClient GetAgentClient(EndpointSettings portSettings)
        {
            return new AgentClient(portSettings.TcpAgentService());
        }

        public static IFleetManagerClient GetFleetManagerClient(EndpointSettings portSettings)
        {
            return new FleetManagerClient(portSettings.TcpFleetManagerService());
        }

        public static IJobBuilderClient GetJobBuilderClient(EndpointSettings portSettings)
        {
            return new JobBuilderClient(portSettings.TcpJobBuilderService());
        }

        public static IJobsStateClient GetJobsStateClient(EndpointSettings portSettings)
        {
            return new JobsStateClient(portSettings.TcpJobsStateService());
        }

        public static IJobStateClient GetJobStateClient(EndpointSettings portSettings)
        {
            return new JobStateClient(portSettings.TcpJobStateService());
        }

        public static IMapClient GetRoadmapClient(EndpointSettings portSettings)
        {
            return new MapClient(portSettings.TcpMapService());
        }

        public static IServicingClient GetServicingClient(EndpointSettings portSettings)
        {
            return new ServicingClient(portSettings.TcpServicingService());
        }

        public static IAgentBatteryStatusClient GetAgentBatteryStatusClient(EndpointSettings portSettings)
        {
            return new AgentBatteryStatusClient(portSettings.TcpAgentBatteryStatusService());
        }

		public static IAgentAttentionClient GetAgentAttentionClient(EndpointSettings portSettings)
		{
			return new AgentAttentionClient(portSettings.TcpAgentAttentionService());
		}

		public static IAgentStatecastClient GetAgentStatecastClient(EndpointSettings portSettings)
		{
			return new AgentStatecastClient(portSettings.TcpAgentStatecastService());
		}

        public static IVersionClient GetVersionClient(EndpointSettings portSettings)
        {
            return new VersionClient(portSettings.TcpVersionService());
        }
    }
}