using System;
using System.Net;

namespace SchedulingClients
{
    public static class EndpointSettings_ExtensionMethods
    {
        public static Uri TcpAgentService(this EndpointSettings portSettings)
        {
            return new Uri(portSettings.ToTcpBase(), "agent.svc");
        }

        public static Uri TcpFleetManagerService(this EndpointSettings portSettings)
        {
            return new Uri(portSettings.ToTcpBase(), "fleetManager.svc");
        }

        public static Uri TcpJobBuilderService(this EndpointSettings portSettings)
        {
            return new Uri(portSettings.ToTcpBase(), "jobBuilder.svc");
        }

        public static Uri TcpJobsStateService(this EndpointSettings portSettings)
        {
            return new Uri(portSettings.ToTcpBase(), "jobsState.svc");
        }

        public static Uri TcpJobStateService(this EndpointSettings portSettings)
        {
            return new Uri(portSettings.ToTcpBase(), "jobState.svc");
        }

        public static Uri TcpMapService(this EndpointSettings portSettings)
        {
            return new Uri(portSettings.ToTcpBase(), "map.svc");
        }

        public static Uri TcpServicingService(this EndpointSettings portSettings)
        {
            return new Uri(portSettings.ToTcpBase(), "servicing.svc");
        }

        private static Uri ToHttpBase(this EndpointSettings portSettings)
        {
            return new Uri("http://" + new IPEndPoint(portSettings.IPAddress, portSettings.HttpPort).ToString());
        }

        private static Uri ToTcpBase(this EndpointSettings portSettings)
        {
            return new Uri("net.tcp://" + new IPEndPoint(portSettings.IPAddress, portSettings.TcpPort).ToString());
        }
    }
}