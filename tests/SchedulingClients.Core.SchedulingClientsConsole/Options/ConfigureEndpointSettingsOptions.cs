using BaseClients.Core;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingClients.Core.SchedulingClientsConsole.Options
{
    [Verb("configure", HelpText = "Configure Endpoint Settings")]
    public class ConfigureEndpointSettingsOptions
    {
        [Option('i', "IPv4String", Required = false, Default = "127.0.0.1", HelpText = "Scheduler IPv4 Address")]
        public string IPv4String { get; set; }

        [Option('t', "TcpPort", Required = false, Default = (ushort)41917, HelpText = "TCP port of scheduler")]
        public ushort TcpPort { get; set; }

        public EndpointSettings CreateTcpEndpointSettings()
        {
            IPAddress ipAddress = IPAddress.Parse(IPv4String);
            return new EndpointSettings(ipAddress, 41916, TcpPort);
        }
    }
}
