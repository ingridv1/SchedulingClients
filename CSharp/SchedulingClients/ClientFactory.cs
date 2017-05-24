using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static RoadmapClient GetRoadmapClient(EndpointSettings portSettings)
        {
            return new RoadmapClient(portSettings.TcpMapService());
        }

        public static ServicingClient GetServicingClient(EndpointSettings portSettings)
        {
            return new ServicingClient(portSettings.TcpServicingService());
        }
    }
}