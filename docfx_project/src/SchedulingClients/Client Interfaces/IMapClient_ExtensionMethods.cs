using SchedulingClients.MapServiceReference;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace SchedulingClients.Client_Interfaces
{
    public static class IMapClient_ExtensionMethods
    {
        public static Point ToPoint(this NodeData nodeData)
            => new Point(nodeData.X, nodeData.Y);

        public static bool IsWithin(this MoveData moveData, IEnumerable<NodeData> nodeData, Rect boundingBox)
        {
            NodeData source = nodeData.First(e => e.MapItemId == moveData.SourceId);
            NodeData dest = nodeData.First(e => e.MapItemId == moveData.DestinationId);

            if (boundingBox.Contains(source.ToPoint())) return true;

            if (boundingBox.Contains(dest.ToPoint())) return true;

            return false;
        }

        public static IEnumerable<MoveData> Within(this IEnumerable<MoveData> moveData, IEnumerable<NodeData> nodeData, Rect boundingBox)
         => moveData.Where(e => e.IsWithin(nodeData, boundingBox));

        public static IEnumerable<NodeData> Within(this IEnumerable<NodeData> nodeData, Rect boundingBox)
            => nodeData.Where(e => boundingBox.Contains(e.ToPoint()));      

        public static double ToPercentageComplete(this IEnumerable<OccupyingMandateMapItemData> dataSet)
        {
            if (dataSet == null) return 0.0;

            List<OccupyingMandateMapItemData> listSet = dataSet.ToList();

            double numItems = listSet.Count;
            double numComplete = listSet.Where(e => e.IsOccupied).Count();

            return (numItems / numComplete) * 100;
        }

        public static double ToPercentageComplete(this OccupyingMandateProgressData occupyingMandateProgressData)
        {
            if (occupyingMandateProgressData == null) return 0.0;

            return occupyingMandateProgressData.OccupyingMandateMapItemData.ToPercentageComplete();
        }
    }
}
