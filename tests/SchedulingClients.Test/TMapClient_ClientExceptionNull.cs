using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SchedulingClients.MapServiceReference;
using BaseClients;

namespace SchedulingClients.Test
{
	/*
	[TestFixture]
	[Category("Map")]
	public class TMapClient_ClientExceptionNull : AbstractInvalidServerClientTest
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
		[Category("ClientExceptionNull")]
		public void TryGetAllMoveData_ClientExceptionNull()
		{
			IEnumerable<MoveData> moveData;
			ServiceOperationResult result = MapClient.TryGetAllMoveData(out moveData);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryGetAllNodeData_ClientExceptionNull()
		{
			IEnumerable<NodeData> nodeData;
			ServiceOperationResult result = MapClient.TryGetAllNodeData(out nodeData);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryGetTrajectory_ClientExeptionNull()
		{
			IEnumerable<WaypointData> waypointData;
			ServiceOperationResult result = MapClient.TryGetTrajectory(1, out waypointData);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryRegisterBlockingMandate_ClientExceptionNull()
		{
			HashSet<int> ids = new HashSet<int> { 1, 2, 3 };

			ServiceOperationResult result = MapClient.TrySetOccupyingMandate(ids, TimeSpan.FromMinutes(2));
			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryClearOccupyingMandate_ClientExceptionNull()
		{
			ServiceOperationResult result = MapClient.TryClearOccupyingMandate();

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryGetAllParameterData_ClientExceptionNull()
		{
			IEnumerable<ParameterData> parameterData;
			ServiceOperationResult result = MapClient.TryGetAllParameterData(out parameterData);

			Assert.IsNull(result.ClientException);
		}
	}*/
}
