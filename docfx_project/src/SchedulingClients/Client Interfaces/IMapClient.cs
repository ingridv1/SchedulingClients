using BaseClients;
using SchedulingClients.MapServiceReference;
using System;
using System.Collections.Generic;

namespace SchedulingClients
{
    public interface IMapClient : ICallbackClient
    {
        ServiceOperationResult TryGetAllMoveData(out IEnumerable<MoveData> moveData);

        ServiceOperationResult TryGetAllNodeData(out IEnumerable<NodeData> nodeData);

        ServiceOperationResult TryGetAllParameterData(out IEnumerable<ParameterData> parameterData);

        ServiceOperationResult TryGetTrajectory(int moveId, out IEnumerable<WaypointData> waypointData);

        ServiceOperationResult TryGetOccupyingMandateProgressData(out OccupyingMandateProgressData occupyingMandateProgressData);

        ServiceOperationResult TrySetOccupyingMandate(HashSet<int> mapItemIds, TimeSpan timeout);

        ServiceOperationResult TryClearOccupyingMandate();

        OccupyingMandateProgressData OccupyingMandateProgressData { get; }
    }
}
