using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchedulingClients.MapServiceReference;

namespace SchedulingClients
{
    public class MapClient : AbstractClient<IMapService>
    {
        public MapClient(Uri netTcpUri)
            : base(netTcpUri)
        {
        }

        public IEnumerable<NodeData> GetAllNodeData()
        {
            IMapService channel = channelFactory.CreateChannel();
            try
            {
                return channel.GetAllNodeData();
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<NodeData>();
            }
        }
    }
}