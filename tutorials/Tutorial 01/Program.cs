using BaseClients.Core;
using FleetClients.Core;
using FleetClients.Core.Client_Interfaces;
using GAAPICommon.Architecture;
using SchedulingClients.Core;
using SchedulingClients.Core.JobBuilderServiceReference;
using SchedulingClients.Core.JobStateServiceReference;
using SchedulingClients.Core.MapServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;

namespace Tutorial_01
{
    /// <summary>
    /// A simple tutorial that
    ///     * Creates a virtual vehicle (via the fleet manager client API)
    ///         see: https://github.com/GuidanceAutomation/FleetClients
    ///     * Gets all the nodes in the map (via the map manager client API)
    ///     * Creates a job that sends the next available to a random node
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Here we create an endpoint settings object that defines where the fleet manager service is currently running
            // For this demo we are assuming it is running on localhost, using the default TCP port of 41917.
            EndpointSettings endpointSettings = new EndpointSettings(IPAddress.Loopback, 41916, 41917);

            IEnumerable<int> nodeIds = Enumerable.Empty<int>(); // Create an array to store node ids in

            NodeDto startNode = null;

            // Using the map manager client, get the ids of all nodes in the map
            using (IMapClient mapClient = SchedulingClients.Core.ClientFactory.CreateTcpMapClient(endpointSettings))
            {
                IServiceCallResult<NodeDto[]> nodeResults = mapClient.GetAllNodes();

                if (!nodeResults.IsSuccessful())
                    Console.WriteLine($"Failed to get nodes, serviceCode:{nodeResults.ServiceCode}");
                else
                    nodeIds = nodeResults.Value.Select(e => e.Id);

                startNode = nodeResults.Value.First();
            }
            
            // Now we create a fleet manager client using the client factory, and create a virtual vehicle at pose at the first node.
            //  see: https://github.com/GuidanceAutomation/FleetClients
            using (IFleetManagerClient fleetManagerClient = FleetClients.Core.ClientFactory.CreateTcpFleetManagerClient(endpointSettings))
            {
                IServiceCallResult result = fleetManagerClient.CreateVirtualVehicle(IPAddress.Parse("192.168.0.1"), startNode.X, startNode.Y, startNode.HeadingRad);

                if (!result.IsSuccessful())
                    Console.WriteLine($"Failed to create virtual vehicle serviceCode:{result.ServiceCode}");
            }


            Random random = new Random(); // Random number generator
            bool continueFlag = true;

            while (continueFlag)
            {
                Console.WriteLine("Press <any> key to create a random GoTo job, 'q' to quit");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Q:
                        {
                            continueFlag = false;
                            break;
                        }

                    default:
                        {
                            // Use the job builder client to create a new goto job. 
                            using (IJobBuilderClient jobBuilder = SchedulingClients.Core.ClientFactory.CreateTcpJobBuilderClient(endpointSettings))
                            {
                                // Boiler plate code to pick a random node from the array of nodes.
                                int index = random.Next(0, nodeIds.Count());
                                int nodeId = nodeIds.ElementAt(index);

                                Console.WriteLine($"Sending to node:{nodeId}");

                                IServiceCallResult<JobDto> createResult = jobBuilder.CreateJob();
                                if (!createResult.IsSuccessful())
                                    Console.WriteLine($"Failed to create job, serviceCode:{createResult.ServiceCode}");

                                IServiceCallResult<int> gotoResult = jobBuilder.CreateGoToNodeTask(createResult.Value.RootOrderedListTaskId, nodeId);
                                if (!gotoResult.IsSuccessful())
                                    Console.WriteLine($"Failed to create goto task, serviceCode:{gotoResult.ServiceCode}");

                                IServiceCallResult commitResult = jobBuilder.CommitJob(createResult.Value.JobId);
                                if (!commitResult.IsSuccessful())
                                    Console.WriteLine($"Failed to commit job, serviceCode:{commitResult.ServiceCode}");
                            }

                            break;
                        }
                }
            }
        }
    }
}