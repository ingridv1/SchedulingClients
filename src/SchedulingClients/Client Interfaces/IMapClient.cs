using BaseClients.Architecture;
using GAAPICommon.Architecture;
using SchedulingClients.MapServiceReference;
using System;
using System.Collections.Generic;

namespace SchedulingClients
{
    public interface IMapClient : ICallbackClient
    {
        IServiceCallResult<MoveDto[]> GetAllMoveData();

        IServiceCallResult<NodeDto[]> GetAllNodeData();

        IServiceCallResult<ParameterDto[]> GetAllParameterData();

        IServiceCallResult<WaypointDto[]> GetTrajectory(int moveId);

        IServiceCallResult<OccupyingMandateMapItemDto> GetOccupyingMandateProgressData();

        IServiceCallResult SetOccupyingMandate(HashSet<int> mapItemIds, TimeSpan timeout);

        IServiceCallResult ClearOccupyingMandate();

        OccupyingMandateProgressDto OccupyingMandateProgressDto { get; }

        event Action<OccupyingMandateProgressDto> OccupyingMandateProgressUpdated;
    }
}
