using System.Net;

namespace SchedulingClients
{
    public struct EndpointSettings
    {
        public const int DEFAULTHTTPPORT = 41916;

        public const int DEFAULTTCPPORT = 41917;

        private readonly int httpPort;

        private readonly IPAddress ipAddress;

        private readonly int tcpPort;

        public EndpointSettings(IPAddress ipAddress = default(IPAddress), int httpPort = DEFAULTHTTPPORT, int tcpPort = DEFAULTTCPPORT)
        {
            this.ipAddress = ipAddress == null ? IPAddress.Loopback : ipAddress;
            this.httpPort = httpPort;
            this.tcpPort = tcpPort;
        }

        public int HttpPort { get { return httpPort; } }

        public IPAddress IPAddress { get { return ipAddress; } }

        public int TcpPort { get { return tcpPort; } }
    }
}