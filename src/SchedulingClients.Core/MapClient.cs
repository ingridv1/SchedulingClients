using BaseClients.Core;
using GAAPICommon.Architecture;
using MoreLinq;
using SchedulingClients.Core.MapServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace SchedulingClients.Core
{
    internal class MapClient : AbstractCallbackClient<IMapService>, IMapClient
    {
        private bool isDisposed = false;

        private readonly MapServiceCallback callback = new MapServiceCallback();

        public static TimeSpan MinimumHeartbeat => TimeSpan.FromMilliseconds(10000);

        /// <summary>
        /// Creates a new MapClient
        /// </summary>
        /// <param name="netTcpUri">net.tcp address of the map service</param>
        public MapClient(Uri netTcpUri, TimeSpan heartbeat = default)
                    : base(netTcpUri, heartbeat)
        {
            callback.OccupyingMandateProgressChange += Callback_OccupyingMandateProgressChange;
        }

        private OccupyingMandateProgressDto occupyingMandateProgressDto = null;

        /// <summary>
        /// The current state of progress of the occupying mandate
        /// </summary>
        public OccupyingMandateProgressDto OccupyingMandateProgressDto
        {
            get { return occupyingMandateProgressDto; }

            private set
            {
                if (occupyingMandateProgressDto != value)
                {
                    occupyingMandateProgressDto = value;
                    OnProgressUpdated(occupyingMandateProgressDto);
                }
            }
        }

        public event Action<OccupyingMandateProgressDto> OccupyingMandateProgressUpdated;

        private void OnProgressUpdated(OccupyingMandateProgressDto occupyingMandateProgressDto)
        {
            Action<OccupyingMandateProgressDto> handlers = OccupyingMandateProgressUpdated;

            handlers?
               .GetInvocationList()
               .Cast<Action<OccupyingMandateProgressDto>>()
               .ForEach(e => e.BeginInvoke(occupyingMandateProgressDto, null, null));
        }

        private void Callback_OccupyingMandateProgressChange(OccupyingMandateProgressDto newProgressData)
        {
            OccupyingMandateProgressDto = newProgressData;
        }

        protected override void SetInstanceContext()
        {
            context = new InstanceContext(callback);
        }

        /// <summary>
        /// Gets all move data
        /// </summary>
        /// <param name="moveData">All moves in the roadmap</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult<MoveDto[]> GetAllMoveData()
        {
            Logger.Trace("GetAllMoveData()");
            return HandleAPICall<MoveDto[]>(e => e.GetAllMoveData());
        }

        /// <summary>
        /// Gets all node data
        /// </summary>
        /// <param name="nodeData">All nodes in the roadmap</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult<NodeDto[]> GetAllNodeData()
        {
            Logger.Trace("GetAllNodeData()");
            return HandleAPICall<NodeDto[]>(e => e.GetAllNodeData());
        }

        /// <summary>
        /// Gets all parameter data
        /// </summary>
        /// <param name="parameterData">All parameters in the map</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult<ParameterDto[]> GetAllParameterData()
        {
            Logger.Trace("GetAllParameterData()");
            return HandleAPICall<ParameterDto[]>(e => e.GetAllParameterData());
        }

        /// <summary>
        /// Gets the trajectory of a specific move
        /// </summary>
        /// <param name="moveId">Id of the move</param>
        /// <param name="waypointData">Waypoints for this move</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult<WaypointDto[]> GetTrajectory(int moveId)
        {
            Logger.Trace($"GetTrajectory() moveId:{moveId}");
            return HandleAPICall<WaypointDto[]>(e => e.GetTrajectory(moveId));
        }

        public IServiceCallResult<OccupyingMandateProgressDto> GetOccupyingMandateProgressData()
        {
            Logger.Trace("GetOccupyingMandateProgressData()");
            return HandleAPICall<OccupyingMandateProgressDto>(e => e.GetOccupyingMandateProgressData());
        }

        /// <summary>
        /// Attempts to remotely occupy an area of the map
        /// </summary>
        /// <param name="mapItemIds">Map Items to occupy off</param>
        /// <param name="timeout">Length of time to wait before abandoning the occupation attempt</param>
        /// <returns></returns>
        public IServiceCallResult SetOccupyingMandate(HashSet<int> mapItemIds, TimeSpan timeout)
        {
            if (mapItemIds == null)
                throw new ArgumentNullException("mapItemIds");

            Logger.Trace($"SetOccupyingMandate() {mapItemIds.Count} item(s)");
            return HandleAPICall(e => e.SetOccupyingMandate(mapItemIds.ToArray(), timeout));
        }

        /// <summary>
        /// Clears a previously occupied area of the map
        /// </summary>
        public IServiceCallResult ClearOccupyingMandate()
        {
            Logger.Info("ClearOccupyingMandate()");
            return HandleAPICall(e => e.ClearOccupyingMandate());
        }

        protected override void Dispose(bool isDisposing)
        {
            Logger.Debug("Dispose({0})", isDisposing);

            if (isDisposed)
                return;

            callback.OccupyingMandateProgressChange -= Callback_OccupyingMandateProgressChange;

            isDisposed = true;

            base.Dispose(isDisposing);
        }

        protected override void HandleSubscriptionHeartbeat(IMapService channel, Guid key)
        {
            channel.SubscriptionHeartbeat(key);
        }
    }
}