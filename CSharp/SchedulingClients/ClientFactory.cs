using GAClients;

namespace SchedulingClients
{
    public static class ClientFactory
    {
        public static AgentClient GetAgentClient(EndpointSettings portSettings)
        {
            return new AgentClient(portSettings.TcpAgentService());
        }

        public static FleetManagerClient GetFleetManagerClient(EndpointSettings portSettings)
        {
            return new FleetManagerClient(portSettings.TcpFleetManagerService());
        }

        public static JobBuilderClient GetJobBuilderClient(EndpointSettings portSettings)
        {
            return new JobBuilderClient(portSettings.TcpJobBuilderService());
        }

        public static JobsStateClient GetJobsStateClient(EndpointSettings portSettings)
        {
            return new JobsStateClient(portSettings.TcpJobsStateService());
        }

        public static JobStateClient GetJobStateClient(EndpointSettings portSettings)
        {
            return new JobStateClient(portSettings.TcpJobStateService());
        }

        public static MapClient GetRoadmapClient(EndpointSettings portSettings)
        {
            return new MapClient(portSettings.TcpMapService());
        }

        public static ServicingClient GetServicingClient(EndpointSettings portSettings)
        {
            return new ServicingClient(portSettings.TcpServicingService());
        }

        public static AgentBatteryStatusClient GetAgentBatteryStatusClient(EndpointSettings portSettings)
        {
            return new AgentBatteryStatusClient(portSettings.TcpAgentBatteryStatusService());
        }

		public static AgentAttentionClient GetAgentAttentionClient(EndpointSettings portSettings)
		{
			return new AgentAttentionClient(portSettings.TcpAgentAttentionService());
		}

		public static AgentStatecastClient GetAgentStatecastClient(EndpointSettings portSettings)
		{
			return new AgentStatecastClient(portSettings.TcpAgentStatecastService());
		}
    }
}