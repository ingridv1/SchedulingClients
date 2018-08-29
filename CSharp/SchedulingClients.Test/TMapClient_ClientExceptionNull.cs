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
	[TestFixture]
	[Category("Map")]
	public class TMapClient_ClientExceptionNull : AbstractClientTest
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
			List<int> ids = new List<int> { 1, 2, 3 };
			bool success;

			ServiceOperationResult result = MapClient.TryRegisterBlockingMandate(ids, 1, 10, out success);

			Assert.IsNull(result.ClientException);
		}

		[Test]
		[Category("ClientExceptionNull")]
		public void TryClearBlockingMandate_ClientExceptionNull()
		{
			ServiceOperationResult result = MapClient.TryClearBlockingMandate(1);

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
	}
}
