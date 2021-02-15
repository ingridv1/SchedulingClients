using BaseClients.Core;
using System;
using System.Net;

namespace SchedulingClients.Core
{
    /// <summary>
    /// Factory class for creating clients
    /// </summary>
    public static class ClientFactory
    {
        /// <summary>
        /// Creates a new Tcp based IAgentClient instance.
        /// </summary>
        /// <param name="endpointSettings">Endpoint settings specifying port and IP address to use</param>
        /// <returns>Tcp based IAgentClient instance</returns>
        public static IAgentClient CreateTcpAgentClient(EndpointSettings portSettings)
        {
            return new AgentClient(portSettings.TcpAgentService());
        }

        /// <summary>
        /// Create a new Tcp based IAgentClient instance
        /// </summary>
        /// <param name="ipAddress">Scheduler IP address</param>
        /// <param name="tcpPort">TCP port to use (default 41917)</param>
        /// <returns>Tcp based IAgentClient instance</returns>
        public static IAgentClient CreateTcpAgentClient(IPAddress ipAddress, ushort tcpPort = 41917)
        {
            if (ipAddress == null) 
                throw new ArgumentNullException("ipAddress");

            EndpointSettings endpointSettings = new EndpointSettings(ipAddress, 41916, tcpPort);
            return CreateTcpAgentClient(endpointSettings);
        }

        /// <summary>
        /// Creates a new Tcp based IJobBuilderClient instance.
        /// </summary>
        /// <param name="endpointSettings">Endpoint settings specifying port and IP address to use</param>
        /// <returns>Tcp based IJobBuilderClient instance</returns>
        public static IJobBuilderClient CreateTcpJobBuilderClient(EndpointSettings portSettings)
        {
            return new JobBuilderClient(portSettings.TcpJobBuilderService());
        }

        /// <summary>
        /// Create a new Tcp based IJobBuilderClient instance
        /// </summary>
        /// <param name="ipAddress">Scheduler IP address</param>
        /// <param name="tcpPort">TCP port to use (default 41917)</param>
        /// <returns>Tcp based IJobBuilderClient instance</returns>
        public static IJobBuilderClient CreateTcpJobBuilderClient(IPAddress ipAddress, ushort tcpPort = 41917)
        {
            if (ipAddress == null)
                throw new ArgumentNullException("ipAddress");

            EndpointSettings endpointSettings = new EndpointSettings(ipAddress, 41916, tcpPort);
            return CreateTcpJobBuilderClient(endpointSettings);
        }

        /// <summary>
        /// Creates a new Tcp based IJobsStateClient instance.
        /// </summary>
        /// <param name="endpointSettings">Endpoint settings specifying port and IP address to use</param>
        /// <returns>Tcp based IJobsStateClient instance</returns>
        public static IJobsStateClient CreateTcpJobsStateClient(EndpointSettings portSettings)
        {
            return new JobsStateClient(portSettings.TcpJobsStateService());
        }

        /// <summary>
        /// Create a new Tcp based IJobsStateClient instance
        /// </summary>
        /// <param name="ipAddress">Scheduler IP address</param>
        /// <param name="tcpPort">TCP port to use (default 41917)</param>
        /// <returns>Tcp based IJobsStateClient instance</returns>
        public static IJobsStateClient CreateTcpJobsStateClient(IPAddress ipAddress, ushort tcpPort = 41917)
        {
            if (ipAddress == null)
                throw new ArgumentNullException("ipAddress");

            EndpointSettings endpointSettings = new EndpointSettings(ipAddress, 41916, tcpPort);
            return CreateTcpJobsStateClient(endpointSettings);
        }

        /// <summary>
        /// Creates a new Tcp based IJobStateClient instance.
        /// </summary>
        /// <param name="endpointSettings">Endpoint settings specifying port and IP address to use</param>
        /// <returns>Tcp based IJobStateClient instance</returns>
        public static IJobStateClient CreateTcpJobStateClient(EndpointSettings portSettings)
        {
            return new JobStateClient(portSettings.TcpJobStateService());
        }

        /// <summary>
        /// Create a new Tcp based IJobStateClient instance
        /// </summary>
        /// <param name="ipAddress">Scheduler IP address</param>
        /// <param name="tcpPort">TCP port to use (default 41917)</param>
        /// <returns>Tcp based IJobStateClient instance</returns>
        public static IJobStateClient CreateTcpJobStateClient(IPAddress ipAddress, ushort tcpPort = 41917)
        {
            if (ipAddress == null)
                throw new ArgumentNullException("ipAddress");

            EndpointSettings endpointSettings = new EndpointSettings(ipAddress, 41916, tcpPort);
            return CreateTcpJobStateClient(endpointSettings);
        }


        /// <summary>
        /// Creates a new Tcp based IMapClient instance.
        /// </summary>
        /// <param name="endpointSettings">Endpoint settings specifying port and IP address to use</param>
        /// <returns>Tcp based IMapClient instance</returns>
        public static IMapClient CreateTcpMapClient(EndpointSettings portSettings)
        {
            return new MapClient(portSettings.TcpMapService());
        }

        /// <summary>
        /// Create a new Tcp based IMapClient instance
        /// </summary>
        /// <param name="ipAddress">Scheduler IP address</param>
        /// <param name="tcpPort">TCP port to use (default 41917)</param>
        /// <returns>Tcp based IMapClient instance</returns>
        public static IMapClient CreateTcpMapClient(IPAddress ipAddress, ushort tcpPort = 41917)
        {
            if (ipAddress == null)
                throw new ArgumentNullException("ipAddress");

            EndpointSettings endpointSettings = new EndpointSettings(ipAddress, 41916, tcpPort);
            return CreateTcpMapClient(endpointSettings);
        }

        /// <summary>
        /// Creates a new Tcp based IServicingClient instance.
        /// </summary>
        /// <param name="endpointSettings">Endpoint settings specifying port and IP address to use</param>
        /// <returns>Tcp based IServicingClient instance</returns>
        public static IServicingClient CreateTcpServicingClient(EndpointSettings portSettings)
        {
            return new ServicingClient(portSettings.TcpServicingService());
        }

        /// <summary>
        /// Create a new Tcp based IServicingClient instance
        /// </summary>
        /// <param name="ipAddress">Scheduler IP address</param>
        /// <param name="tcpPort">TCP port to use (default 41917)</param>
        /// <returns>Tcp based IServicingClient instance</returns>
        public static IServicingClient CreateTcpServicingClient(IPAddress ipAddress, ushort tcpPort = 41917)
        {
            if (ipAddress == null)
                throw new ArgumentNullException("ipAddress");

            EndpointSettings endpointSettings = new EndpointSettings(ipAddress, 41916, tcpPort);
            return CreateTcpServicingClient(endpointSettings);
        }

        /// <summary>
        /// Creates a new Tcp based ITaskStateClient instance.
        /// </summary>
        /// <param name="endpointSettings">Endpoint settings specifying port and IP address to use</param>
        /// <returns>Tcp based ITaskStateClient instance</returns>
        public static ITaskStateClient CreateTcpTaskStateClient(EndpointSettings portSettings)
        {
            return new TaskStateClient(portSettings.TcpTaskStateService());
        }

        /// <summary>
        /// Create a new Tcp based ITaskStateClient instance
        /// </summary>
        /// <param name="ipAddress">Scheduler IP address</param>
        /// <param name="tcpPort">TCP port to use (default 41917)</param>
        /// <returns>Tcp based ITaskStateClient instance</returns>
        public static ITaskStateClient CreateTcpTaskStateClient(IPAddress ipAddress, ushort tcpPort = 41917)
        {
            if (ipAddress == null)
                throw new ArgumentNullException("ipAddress");

            EndpointSettings endpointSettings = new EndpointSettings(ipAddress, 41916, tcpPort);
            return CreateTcpTaskStateClient(endpointSettings);
        }
    }
}