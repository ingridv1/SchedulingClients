using BaseClients.Core;
using CommandLine;
using GAAPICommon.Architecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SchedulingClients.Core.JobStateServiceReference;
using System.Threading.Tasks;

namespace SchedulingClients.Core.SchedulingClientsConsole.Options
{
    [Verb("jsa", HelpText = "Get current job summary for agent")]
    public class JobState_GetCurrentJobSummaryForAgentId : AbstractConsoleOption<IJobStateClient>
    {
        [Option('i', "Id", Required = false, Default = -1, HelpText = "Id")]
        public int Id { get; set; }

        protected override IServiceCallResult HandleExecution(IJobStateClient client)
        {
            IServiceCallResult<JobSummaryDto> result = client.GetCurrentJobSummaryForAgentId(Id);

            Console.WriteLine($"Getting job summary for agent:{Id}");

            if (result.IsSuccessful())
            {
                Console.WriteLine($"JobId:{result.Value.JobId}");
            }
            else
            {
                Console.WriteLine(result.ExceptionMessage);
            }

            return result;
        }
    }
}
