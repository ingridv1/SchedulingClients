using BaseClients.Core;
using SchedulingClients.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_02
{
    class Program
    {
        static void Main(string[] args)
        {
            // Here we create an endpoint settings object that defines where the fleet manager service is currently running
            // For this demo we are assuming it is running on localhost, using the default TCP port of 41917.
            EndpointSettings endpointSettings = new EndpointSettings(IPAddress.Loopback, 41916, 41917);

            Console.WriteLine("Press <any> to connect to scheduling client. Once connected press <any> key to quit.");
            Console.ReadKey(true);

            using (ISchedulingClient client = SchedulingClients.Core.ClientFactory.CreateTcpSchedulingClient(endpointSettings))
            {
                client.Updated += OnUpdated;

                Console.ReadKey(true);

                client.Updated -= OnUpdated;
            }
        }

        private static void OnUpdated(SchedulingClients.Core.SchedulingServiceReference.SchedulerStateDto dto)
        {
            Console.WriteLine($"Cycle: {dto.Cycle.ToString("d3")}  Instance: {dto.InstanceId} UpTime: {dto.UpTime}");
        }
    }
}
