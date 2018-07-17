using GAClients;
using SchedulingClients.MapServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingClients
{
	public interface IMapClient : IClient
	{
		ServiceOperationResult TryGetAllMoveData(out IEnumerable<MoveData> moveData);

		ServiceOperationResult TryGetAllNodeData(out IEnumerable<NodeData> nodeData);

		ServiceOperationResult TryGetAllParameterData(out IEnumerable<ParameterData> parameterData);

		ServiceOperationResult TryGetTrajectory(int moveId, out IEnumerable<WaypointData> waypointData);

		ServiceOperationResult TryRegisterBlockingMandate(IEnumerable<int> mapItemIds, int mandateId, int millisecondsTimeout, out bool success);

		ServiceOperationResult TryClearBlockingMandate(int mandateId);


	}
}
