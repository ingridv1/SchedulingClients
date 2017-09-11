using SchedulingClients.MapServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using NLog;

namespace SchedulingClients
{
    public class RoadmapClient : AbstractClient<IMapService>
    {
        private bool isDisposed = false;

        /// <summary>
        /// Creates a new MapClient
        /// </summary>
        /// <param name="netTcpUri">net.tcp address of the map service</param>
        public RoadmapClient(Uri netTcpUri)
                    : base(netTcpUri)
        {
        }

        /// <summary>
        /// Gets all move data
        /// </summary>
        /// <param name="moveData">All moves in the roadmap</param>
        /// <returns>ServiceOperationResult</returns>
        public ServiceOperationResult TryGetAllMoveData(out IEnumerable<MoveData> moveData)
        {
            Logger.Info("TryGetAllMoveData()");

            try
            {
                var result = GetAllMoveData();
                moveData = result.Item1;
                return ServiceOperationResult.FromServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                moveData = Enumerable.Empty<MoveData>();
                return HandleClientException(ex);
            }
        }

        /// <summary>
        /// Gets all node data
        /// </summary>
        /// <param name="nodeData">All nodes in the roadmap</param>
        /// <returns>ServiceOperationResult</returns>
        public ServiceOperationResult TryGetAllNodeData(out IEnumerable<NodeData> nodeData)
        {
            Logger.Info("TryGetAllNodeData()");

            try
            {
                var result = GetAllNodeData();
                nodeData = result.Item1;
                return ServiceOperationResult.FromServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                nodeData = Enumerable.Empty<NodeData>();
                return HandleClientException(ex);
            }
        }

        /// <summary>
        /// Gets the trajectory of a specific move
        /// </summary>
        /// <param name="moveId">Id of the move</param>
        /// <param name="waypointData">Waypoints for this move</param>
        /// <returns>ServiceOperationResult</returns>
        public ServiceOperationResult TryGetTrajectory(int moveId, out IEnumerable<WaypointData> waypointData)
        {
            Logger.Info("TryGetTrajectory({0})", moveId);

            try
            {
                var result = GetTrajectory(moveId);
                waypointData = result.Item1;
                return ServiceOperationResult.FromServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                waypointData = null;
                return HandleClientException(ex);
            }
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposed)
            {
                return;
            }

            isDisposed = true;

            base.Dispose(isDisposing);
        }

        private Tuple<MoveData[], ServiceCallData> GetAllMoveData()
        {
            Logger.Debug("GetAllMoveData()");

            if (isDisposed)
            {
                throw new ObjectDisposedException("RoadmapClient");
            }

            Tuple<MoveData[], ServiceCallData> result;

            using (ChannelFactory<IMapService> channelFactory = CreateChannelFactory())
            {
                IMapService channel = channelFactory.CreateChannel();
                result = channel.GetAllMoveData();
                channelFactory.Close();
            }

            return result;
        }

        private Tuple<NodeData[], ServiceCallData> GetAllNodeData()
        {
            Logger.Debug("GetAllNodeData()");

            if (isDisposed)
            {
                throw new ObjectDisposedException("RoadmapClient");
            }

            Tuple<NodeData[], ServiceCallData> result;

            using (ChannelFactory<IMapService> channelFactory = CreateChannelFactory())
            {
                IMapService channel = channelFactory.CreateChannel();
                result = channel.GetAllNodeData();
                channelFactory.Close();
            }

            return result;
        }

        private Tuple<WaypointData[], ServiceCallData> GetTrajectory(int moveId)
        {
            Logger.Debug("GetTrajectory({0})", moveId);

            if (isDisposed)
            {
                throw new ObjectDisposedException("MapClient");
            }

            Tuple<WaypointData[], ServiceCallData> result;

            using (ChannelFactory<IMapService> channelFactory = CreateChannelFactory())
            {
                IMapService channel = channelFactory.CreateChannel();
                result = channel.GetTrajectory(moveId);
                channelFactory.Close();
            }

            return result;
        }
    }
}