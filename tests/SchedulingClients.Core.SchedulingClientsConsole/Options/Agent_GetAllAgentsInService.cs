using BaseClients.Core;
using CommandLine;
using GAAPICommon.Architecture;
using GAAPICommon.Core.Dtos;
using SchedulingClients.Core.AgentServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingClients.Core.SchedulingClientsConsole.Options
{
    [Verb("ais", HelpText = "Get all agents in service")]
    public class Agent_GetAllAgentsInService : AbstractConsoleOption<IAgentClient>
    {

        protected override IServiceCallResult HandleExecution(IAgentClient client)
        {
            IServiceCallResult<AgentDto[]> result = client.GetAllAgentsInLifetimeState(AgentLifetimeState.InService);

            if (result.IsSuccessful())
            {
                foreach(AgentDto agent in result.Value)
                {
                    Console.WriteLine($"{agent.Id} - {agent.Alias} ({agent.IPAddress})");
                }
            }
            else
            {
                Console.WriteLine(result);
            }

            return result;
        }
    }
}
