using GAAPICommon.Core.Dtos;
using SchedulingClients.Core.MapServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace SchedulingClients.Core
{
    /// <summary>
    /// Extension methods to the IMapClient interface.
    /// </summary>
    public static class IMapClient_ExtensionMethods
    {
        /// <summary>
        /// Converts a node to a point.
        /// </summary>
        /// <param name="node">Node to convert</param>
        /// <returns>Point containing XY position of node.</returns>
        public static Point ToPoint(this NodeDto node)
        {
            if (node == null)
                throw new ArgumentNullException("node");

            return new Point(node.Pose.X, node.Pose.Y);
        }

        /// <summary>
        /// Determines if a move is within a bounding box.
        /// </summary>
        /// <param name="move">Target move</param>
        /// <param name="nodes">Enumerable of all nodes in the roadmap</param>
        /// <param name="boundingBox">Bounding box.</param>
        /// <returns>True if the move is within the bounding box.</returns>
        public static bool IsWithin(this MoveDto move, IEnumerable<NodeDto> nodes, Rect boundingBox)
        {
            if (move == null)
                throw new ArgumentNullException("move");

            if (nodes == null)
                throw new ArgumentNullException("nodes");

            NodeDto source = nodes.FirstOrDefault(e => e.Id == move.SourceId);

            if (source == null)
                throw new ArgumentOutOfRangeException("Nodes does not contain source node for move");

            NodeDto dest = nodes.FirstOrDefault(e => e.Id == move.DestinationId);

            if (dest == null)
                throw new ArgumentOutOfRangeException("Nodes does not contain destination node for move");

            if (boundingBox.Contains(source.ToPoint()))
                return true;

            if (boundingBox.Contains(dest.ToPoint()))
                return true;

            return false;
        }

        /// <summary>
        /// Filters an collection of moves that are within a bounding box.
        /// </summary>
        /// <param name="moves">Moves to be filtered.</param>
        /// <param name="nodes">All nodes in the roadmap.</param>
        /// <param name="boundingBox">Bounding box.</param>
        /// <returns>All moves within the bounding box.</returns>
        public static IEnumerable<MoveDto> Within(this IEnumerable<MoveDto> moves, IEnumerable<NodeDto> nodes, Rect boundingBox)
         => moves.Where(e => e.IsWithin(nodes, boundingBox));

        /// <summary>
        /// Filters a collection of nodes that are withing a bounding box.
        /// </summary>
        /// <param name="nodes">Nodes to be filtered.</param>
        /// <param name="boundingBox">Bounding box.</param>
        /// <returns>All nodes within the bounding box.</returns>
        public static IEnumerable<NodeDto> Within(this IEnumerable<NodeDto> nodes, Rect boundingBox)
            => nodes.Where(e => boundingBox.Contains(e.ToPoint()));

        /// <summary>
        /// Converts a collection of occupying mandate map items to a progress percentage.
        /// </summary>
        /// <param name="dataSet">Collection of occupying mandate map item dtos to be processed.</param>
        /// <returns>Percentage complete</returns>
        public static double ToPercentageComplete(this IEnumerable<OccupyingMandateMapItemDto> dataSet)
        {
            if (dataSet == null) 
                return 0.0;

            List<OccupyingMandateMapItemDto> listSet = dataSet.ToList();

            double numItems = listSet.Count;
            double numComplete = listSet.Where(e => e.IsOccupied).Count();

            return ( numComplete/ numItems) * 100;
        }

        /// <summary>
        /// Converts occupying mandate progress to a progress percentage.
        /// </summary>
        /// <param name="occupyingMandateProgressData">Occupying mandate progress to be processed.</param>
        /// <returns>Percentage complete</returns>
        public static double ToPercentageComplete(this OccupyingMandateProgressDto occupyingMandateProgress)
        {
            if (occupyingMandateProgress == null)
                return 0.0;

            return occupyingMandateProgress.OccupyingMandateMapItemData.ToPercentageComplete();
        }
    }
}