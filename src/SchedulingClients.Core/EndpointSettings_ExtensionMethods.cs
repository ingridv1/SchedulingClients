using BaseClients.Core;
using System;

namespace SchedulingClients.Core
{
    public static class EndpointSettings_ExtensionMethods
    {
        public static Uri TcpAgentService(this EndpointSettings portSettings)
            => new Uri(portSettings.ToTcpBase(), "agent.svc");

        public static Uri TcpTaskStateService(this EndpointSettings portSettings)
            => new Uri(portSettings.ToTcpBase(), "taskState.svc");

        public static Uri TcpAgentBatteryStatusService(this EndpointSettings portSettings)
            => new Uri(portSettings.ToTcpBase(), "agentBatteryStatus.svc");

        public static Uri TcpJobBuilderService(this EndpointSettings portSettings)
            => new Uri(portSettings.ToTcpBase(), "jobBuilder.svc");

        public static Uri TcpJobsStateService(this EndpointSettings portSettings)
            => new Uri(portSettings.ToTcpBase(), "jobsState.svc");

        public static Uri TcpJobStateService(this EndpointSettings portSettings)
            => new Uri(portSettings.ToTcpBase(), "jobState.svc");

        public static Uri TcpMapService(this EndpointSettings portSettings)
            => new Uri(portSettings.ToTcpBase(), "map.svc");

        public static Uri TcpServicingService(this EndpointSettings portSettings)
            => new Uri(portSettings.ToTcpBase(), "servicing.svc");

        public static Uri TcpAgentAttentionService(this EndpointSettings portSettings)
            => new Uri(portSettings.ToTcpBase(), "agentAttention.svc");

        public static Uri TcpAgentStatecastService(this EndpointSettings portSettings)
            => new Uri(portSettings.ToTcpBase(), "agentStatecast.svc");
    }
}