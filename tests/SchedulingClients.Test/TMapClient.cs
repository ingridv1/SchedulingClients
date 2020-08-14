using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SchedulingClients.MapServiceReference;
using BaseClients;

namespace SchedulingClients.Test
{
    /*
    /// <summary>
    /// Requires a server to be running on local host to be succesfull with a populated map
    /// </summary>
    [Category("MapClient")]
    public class TMapClient : AbstractInvalidServerClientTest
    {
        [OneTimeSetUp]
        public override void OneTimeSetup()
        {
            base.OneTimeSetup();
            IMapClient client = ClientFactory.CreateTcpMapClient(settings);
            clients.Add(client);
        }

        IMapClient MapClient => clients.First(e => e is IMapClient) as IMapClient;

        [Test]
        public void GetMapItems()
        {
            IEnumerable<NodeData> nodeDataset;
            MapClient.TryGetAllNodeData(out nodeDataset);

            Assert.IsNotNull(nodeDataset);

            IEnumerable<MoveData> moveDataset;
            MapClient.TryGetAllMoveData(out moveDataset);

            Assert.IsNotNull(moveDataset);
        }

        [Test]
        public void GetTrajectory()
        { 
            IEnumerable<MoveData> moveDataset;
            MapClient.TryGetAllMoveData(out moveDataset);

            Assert.IsNotNull(moveDataset);

            foreach(MoveData moveData in moveDataset)
            {
                IEnumerable<WaypointData> waypointData = null;
                MapClient.TryGetTrajectory(moveData.Id, out waypointData);

                Assert.IsNotNull(waypointData);
                CollectionAssert.IsNotEmpty(waypointData);
            }
        }
    }*/
}
