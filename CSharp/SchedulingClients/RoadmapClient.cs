using System;
using System.Collections.Generic;
using System.Linq;
using SchedulingClients.RoadmapServiceReference;

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

            IRoadmapService channel = channelFactory.CreateChannel();
            return channel.GetAllNodeData();
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
                LastCaughtException = ex;
                nodeData = Enumerable.Empty<NodeData>();
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