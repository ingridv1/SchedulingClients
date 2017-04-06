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

        public IEnumerable<MoveData> GetAllMoveData()
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("RoadmapClient");
            }

            ChannelFactory<IRoadmapService> channelFactory = CreateChannelFactory();
            IRoadmapService channel = channelFactory.CreateChannel();

            MoveData[] moveData = channel.GetAllMoveData();
            channelFactory.Close();
            return moveData;
        }

        /// <summary>
        /// Gets node data for every node in the roadmap
        /// </summary>
        /// <returns>IEnumerable of NodeData</returns>
        public IEnumerable<NodeData> GetAllNodeData()
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("RoadmapClient");
            }

            ChannelFactory<IRoadmapService> channelFactory = CreateChannelFactory();
            IRoadmapService channel = channelFactory.CreateChannel();

            NodeData[] nodeData = channel.GetAllNodeData();
            channelFactory.Close();
            return nodeData;
        }

        public byte[] GetMappingKeyCardSignature()
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("RoadmapClient");
            }

            ChannelFactory<IRoadmapService> channelFactory = CreateChannelFactory();
            IRoadmapService channel = channelFactory.CreateChannel();

            byte[] signature = channel.GetMappingKeyCardSignature();
            channelFactory.Close();
            return signature;
        }

        public IEnumerable<WaypointData> GetTrajectory(int moveId)
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("RoadmapClient");
            }

            ChannelFactory<IRoadmapService> channelFactory = CreateChannelFactory();
            IRoadmapService channel = channelFactory.CreateChannel();

            WaypointData[] waypointData = channel.GetTrajectory(moveId);
            channelFactory.Close();
            return waypointData;
        }

        public bool TryGetAllMoveData(out IEnumerable<MoveData> moveData)
        {
            try
            {
                moveData = GetAllMoveData();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Warn(ex);
                LastCaughtException = ex;
                moveData = Enumerable.Empty<MoveData>();
                return false;
            }
        }

        /// <summary>
        /// Tries to get node data for every node in the roadmap
        /// </summary>
        /// <param name="nodeData">IEnumerable of NodeData</param>
        /// <returns>True if operation succesfull, otherwise false</returns>
        public bool TryGetAllNodeData(out IEnumerable<NodeData> nodeData)
        {
            try
            {
                nodeData = GetAllNodeData();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Warn(ex);
                LastCaughtException = ex;
                nodeData = Enumerable.Empty<NodeData>();
                return false;
            }
        }

        public bool TryGetMappingKeyCardSignature(out byte[] signature)
        {
            try
            {
                signature = GetMappingKeyCardSignature();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Warn(ex);
                LastCaughtException = ex;
                signature = null;
                return false;
            }
        }

        public bool TryGetTrajectory(int moveId, out IEnumerable<WaypointData> waypointData)
        {
            try
            {
                waypointData = GetTrajectory(moveId);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Warn(ex);
                LastCaughtException = ex;
                waypointData = Enumerable.Empty<WaypointData>();
                return false;
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
    }
}