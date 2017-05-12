using SchedulingClients.RoadmapServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using NLog;

namespace SchedulingClients
{
    public class RoadmapClient : AbstractClient<IRoadmapService>
    {
        private bool isDisposed = false;

        /// <summary>
        /// Creates a new RoadmapClient
        /// </summary>
        /// <param name="netTcpUri">net.tcp address of the roadmap service</param>
        public RoadmapClient(Uri netTcpUri)
                    : base(netTcpUri)
        {
        }

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

        public ServiceOperationResult TryGetMappingKeyCardSignature(out byte[] signature)
        {
            Logger.Info("TryGetMappingKeyCardSignature()");

            try
            {
                var result = GetMappingKeyCardSignature();
                signature = result.Item1;
                return ServiceOperationResult.FromServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                signature = null;
                return HandleClientException(ex);
            }
        }

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
            Logger.Info("GetAllMoveData()");

            if (isDisposed)
            {
                throw new ObjectDisposedException("RoadmapClient");
            }

            Tuple<MoveData[], ServiceCallData> result;

            using (ChannelFactory<IRoadmapService> channelFactory = CreateChannelFactory())
            {
                IRoadmapService channel = channelFactory.CreateChannel();
                result = channel.GetAllMoveData();
                channelFactory.Close();
            }

            return result;
        }

        private Tuple<NodeData[], ServiceCallData> GetAllNodeData()
        {
            Logger.Info("GetAllNodeData()");

            if (isDisposed)
            {
                throw new ObjectDisposedException("RoadmapClient");
            }

            Tuple<NodeData[], ServiceCallData> result;

            using (ChannelFactory<IRoadmapService> channelFactory = CreateChannelFactory())
            {
                IRoadmapService channel = channelFactory.CreateChannel();
                result = channel.GetAllNodeData();
                channelFactory.Close();
            }

            return result;
        }

        private Tuple<byte[], ServiceCallData> GetMappingKeyCardSignature()
        {
            Logger.Info("GetMappingKeyCardSignature()");

            if (isDisposed)
            {
                throw new ObjectDisposedException("RoadmapClient");
            }

            Tuple<byte[], ServiceCallData> result;

            using (ChannelFactory<IRoadmapService> channelFactory = CreateChannelFactory())
            {
                IRoadmapService channel = channelFactory.CreateChannel();
                result = channel.GetMappingKeyCardSignature();
                channelFactory.Close();
            }

            return result;
        }

        private Tuple<WaypointData[], ServiceCallData> GetTrajectory(int moveId)
        {
            Logger.Info("GetTrajectory({0})", moveId);

            if (isDisposed)
            {
                throw new ObjectDisposedException("RoadmapClient");
            }

            Tuple<WaypointData[], ServiceCallData> result;

            using (ChannelFactory<IRoadmapService> channelFactory = CreateChannelFactory())
            {
                IRoadmapService channel = channelFactory.CreateChannel();
                result = channel.GetTrajectory(moveId);
                channelFactory.Close();
            }

            return result;
        }
    }
}