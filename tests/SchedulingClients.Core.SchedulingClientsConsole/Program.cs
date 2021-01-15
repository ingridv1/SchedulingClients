using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseClients.Core;
using CommandLine;
using GAAPICommon.Core;
using SchedulingClients.Core;
using SchedulingClients.Core.SchedulingClientsConsole.Options;

namespace SchedulingClients.Core.SchedulingClientsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = @"Scheduling Clients Console";

            EndpointSettings endpointSettings = null;

            Parser.Default.ParseArguments<ConfigureEndpointSettingsOptions>(args)
                .WithParsed<ConfigureEndpointSettingsOptions>(o =>
                {
                    endpointSettings = o.CreateTcpEndpointSettings();
                }
                )
                .WithNotParsed<ConfigureEndpointSettingsOptions>(o =>
                {
                    Environment.Exit(-1);
                });

            IAgentClient agentClient = ClientFactory.CreateTcpAgentClient(endpointSettings);
            IJobStateClient jobStateClient = ClientFactory.CreateTcpJobStateClient(endpointSettings);            

            while(true)
            {
                Console.Write("sc>");
                args = Console.ReadLine().Split();

                Parser.Default.ParseArguments
                    <Agent_GetAllAgentsInService,
                    JobState_GetCurrentJobSummaryForAgentId>
                    (args)
                    .MapResult(
                        (Agent_GetAllAgentsInService opts) => opts.ExecuteOption(agentClient),
                        (JobState_GetCurrentJobSummaryForAgentId opts) => opts.ExecuteOption(jobStateClient),
                        errs => ServiceCallResultFactory.FromClientException(new Exception("Operation failed"))
                        );
            }
        }
    }
}
