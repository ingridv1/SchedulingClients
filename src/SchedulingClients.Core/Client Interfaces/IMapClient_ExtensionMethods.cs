using SchedulingClients.Core.MapServiceReference;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace SchedulingClients.Core
{
    public static class IMapClient_ExtensionMethods
    {
        public static Point ToPoint(this NodeDto node)
            => new Point(node.X, node.Y);

        public static bool IsWithin(this MoveDto move, IEnumerable<NodeDto> node, Rect boundingBox)
        {
            NodeDto source = node.First(e => e.Id == move.SourceId);
            NodeDto dest = node.First(e => e.Id == move.DestinationId);

            if (boundingBox.Contains(source.ToPoint()))
                return true;

            if (boundingBox.Contains(dest.ToPoint())) 
                return true;

            return false;
        }

        public static IEnumerable<MoveDto> Within(this IEnumerable<MoveDto> moves, IEnumerable<NodeDto> nodes, Rect boundingBox)
         => moves.Where(e => e.IsWithin(nodes, boundingBox));

        public static IEnumerable<NodeDto> Within(this IEnumerable<NodeDto> nodes, Rect boundingBox)
            => nodes.Where(e => boundingBox.Contains(e.ToPoint()));      

        public static double ToPercentageComplete(this IEnumerable<OccupyingMandateMapItemDto> dataSet)
        {
            if (dataSet == null) return 0.0;

            List<OccupyingMandateMapItemDto> listSet = dataSet.ToList();

            double numItems = listSet.Count;
            double numComplete = listSet.Where(e => e.IsOccupied).Count();

            return (numItems / numComplete) * 100;
        }

        public static double ToPercentageComplete(this OccupyingMandateProgressDto occupyingMandateProgressData)
        {
            if (occupyingMandateProgressData == null)
                return 0.0;

            return occupyingMandateProgressData.OccupyingMandateMapItemData.ToPercentageComplete();
        }
    }
}
