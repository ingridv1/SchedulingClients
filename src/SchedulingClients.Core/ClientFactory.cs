using BaseClients.Core;

namespace SchedulingClients.Core
{
    /// <summary>
    /// Factory class for creating clients
    /// </summary>
    public static class ClientFactory
    {
        /// <summary>
        /// Creates a new Tcp based Agent Client instance.
        /// </summary>
        /// <param name="endpointSettings">Endpoint settings specifying port and IP address to use</param>
        /// <returns>Tcp based IAgentClient instance</returns>
        public static IAgentClient CreateTcpAgentClient(EndpointSettings portSettings)
        {
            return new AgentClient(portSettings.TcpAgentService());
        }

        /// <summary>
        /// Creates a new Tcp based Job Builder Client instance.
        /// </summary>
        /// <param name="endpointSettings">Endpoint settings specifying port and IP address to use</param>
        /// <returns>Tcp based IJobBuilderClient instance</returns>
        public static IJobBuilderClient CreateTcpJobBuilderClient(EndpointSettings portSettings)
        {
            return new JobBuilderClient(portSettings.TcpJobBuilderService());
        }

        /// <summary>
        /// Creates a new Tcp based Jobs State Client instance.
        /// </summary>
        /// <param name="endpointSettings">Endpoint settings specifying port and IP address to use</param>
        /// <returns>Tcp based IJobsStateClient instance</returns>
        public static IJobsStateClient CreateTcpJobsStateClient(EndpointSettings portSettings)
        {
            return new JobsStateClient(portSettings.TcpJobsStateService());
        }

        /// <summary>
        /// Creates a new Tcp based Job State Client instance.
        /// </summary>
        /// <param name="endpointSettings">Endpoint settings specifying port and IP address to use</param>
        /// <returns>Tcp based IJobStateClient instance</returns>
        public static IJobStateClient CreateTcpJobStateClient(EndpointSettings portSettings)
        {
            return new JobStateClient(portSettings.TcpJobStateService());
        }

        /// <summary>
        /// Creates a new Tcp based Map Client instance.
        /// </summary>
        /// <param name="endpointSettings">Endpoint settings specifying port and IP address to use</param>
        /// <returns>Tcp based IMapClient instance</returns>
        public static IMapClient CreateTcpMapClient(EndpointSettings portSettings)
        {
            return new MapClient(portSettings.TcpMapService());
        }

        /// <summary>
        /// Creates a new Tcp based Servicing Client instance.
        /// </summary>
        /// <param name="endpointSettings">Endpoint settings specifying port and IP address to use</param>
        /// <returns>Tcp based IServicingClient instance</returns>
        public static IServicingClient CreateTcpServicingClient(EndpointSettings portSettings)
        {
            return new ServicingClient(portSettings.TcpServicingService());
        }

        /// <summary>
        /// Creates a new Tcp based Task State Client instance.
        /// </summary>
        /// <param name="endpointSettings">Endpoint settings specifying port and IP address to use</param>
        /// <returns>Tcp based ITaskStateClient instance</returns>
        public static ITaskStateClient CreateTcpTaskStateClient(EndpointSettings portSettings)
        {
            return new TaskStateClient(portSettings.TcpTaskStateService());
        }
    }
}