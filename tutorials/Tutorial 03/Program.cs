using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FleetClients.Core;
using GAAPICommon.Architecture;
using BaseClients.Core;
using System.Net;
using FleetClients.Core.Client_Interfaces;
using SchedulingClients.Core;
using GAAPICommon.Core.Dtos;
using SchedulingClients.Core.JobBuilderServiceReference;

namespace Tutorial_03
{
    class Program
    {
        static void Main(string[] args)
        {
            bool terminate = false;

            // Here we create an endpoint settings object that defines where the fleet manager service is currently running
            // For this demo we are assuming it is running on localhost, using the default TCP port of 41917.
            EndpointSettings endpointSettings = new EndpointSettings(IPAddress.Loopback, 41916, 41917);

            while (!terminate)
            {
                WriteMenu();

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.C:
                        {
                            HandleCreateVehicle(endpointSettings);
                            break;
                        }

                    case ConsoleKey.J:
                        {
                            HandleCreateJob(endpointSettings);
                            break;
                        }

                    case ConsoleKey.M:
                        {
                            HandleWriteMap();
                            break;
                        }

                    case ConsoleKey.Q:
                        {
                            terminate = true;
                            break;
                        }

                    default:
                        return; 
                }
            }

        }

        private static void WriteMenu()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);

            Console.WriteLine("Tutorial 03");
            Console.WriteLine($"\tPress 'c' to create a new vehicle");
            Console.WriteLine($"\tPress 'j' to inject job");
            Console.WriteLine($"\tPress 'm' to write out map file");
            Console.WriteLine($"\tPress 'q' to quit");
        }

        private static void HandleCreateVehicle(EndpointSettings endpointSettings)
        {
            // Now we create a fleet manager client using the client factory, and create a virtual vehicle at pose at the node defined as origin.
            //  see: https://github.com/GuidanceAutomation/FleetClients
            using (IFleetManagerClient fleetManagerClient = FleetClients.Core.ClientFactory.CreateTcpFleetManagerClient(endpointSettings))
            {
                IServiceCallResult result = fleetManagerClient.CreateVirtualVehicle(IPAddress.Parse("192.168.0.1"), 0, 0,0);

                if (!result.IsSuccessful())
                    Console.WriteLine($"Failed to create virtual vehicle serviceCode:{result.ServiceCode}");

                IServiceCallResult enableResult = fleetManagerClient.SetKingpinState(IPAddress.Parse("192.168.0.1"), VehicleControllerState.Enabled);

                if (!enableResult.IsSuccessful())
                    Console.WriteLine($"Failed to enable virtual vehicle serviceCode:{result.ServiceCode}");
            }
        }


        private static void HandleCreateJob(EndpointSettings endpointSettings)
        {
            IEnumerable<NodeDto> nodes = null;

            // Using the map manager client, get the ids of all nodes in the map
            using (IMapClient mapClient = SchedulingClients.Core.ClientFactory.CreateTcpMapClient(endpointSettings))
            {
                IServiceCallResult<NodeDto[]> nodeResults = mapClient.GetAllNodes();

                if (!nodeResults.IsSuccessful())
                    Console.WriteLine($"Failed to get nodes, serviceCode:{nodeResults.ServiceCode}");
                else
                    nodes = nodeResults.Value;
            }

            // Create a multijob
            using (IJobBuilderClient jobBuilder = SchedulingClients.Core.ClientFactory.CreateTcpJobBuilderClient(endpointSettings))
            {
                IServiceCallResult<JobDto> createResult = jobBuilder.CreateJob();
                if (!createResult.IsSuccessful())
                    Console.WriteLine($"Failed to create job, serviceCode:{createResult.ServiceCode}");

                IServiceCallResult<int> createUnorderedListTaskResult = jobBuilder.CreateUnorderedListTask(createResult.Value.RootOrderedListTaskId);
                if (!createUnorderedListTaskResult.IsSuccessful())
                    Console.WriteLine($"Failed to create unordered list task, serviceCode:{createResult.ServiceCode}");

                string[] targets = new string[] { "A0", "B0", "C0", "A1", "B1", "C1" };

                foreach(string target in targets)
                {
                    AddGoToTask(jobBuilder, createUnorderedListTaskResult.Value, nodes, target);
                }


                IServiceCallResult commitResult = jobBuilder.CommitJob(createResult.Value.JobId);
                if (!commitResult.IsSuccessful())
                    Console.WriteLine($"Failed to commit job, serviceCode:{commitResult.ServiceCode}");
            }
        }

        private static void AddGoToTask(IJobBuilderClient client, int unorderedListTaskId, IEnumerable<NodeDto> nodes, string alias)
        {
            NodeDto target = nodes.FirstOrDefault(e => e.Alias == alias);

            IServiceCallResult<int> gotoResult = client.CreateGoToNodeTask(unorderedListTaskId, target.Id);

            if (!gotoResult.IsSuccessful())
                Console.WriteLine($"Failed to create goto task, serviceCode:{gotoResult.ServiceCode}");
        }

        private static void HandleWriteMap()
        {
            string tempFolder = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempFolder);

            File.WriteAllBytes($"{tempFolder}\\map.sqlite", Properties.Resources.Aisle3Loop);
            System.Diagnostics.Process.Start(tempFolder);
        }
    }
}
