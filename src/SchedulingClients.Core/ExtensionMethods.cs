using GAAPICommon.Core.Dtos;
using SchedulingClients.Core.MapServiceReference;
using System;
using System.IO;

namespace SchedulingClients.Core
{
    public static class ExtensionMethods
    {
        public static string ToCSV(this MoveDto move)
        {
            if (move == null)
                throw new ArgumentNullException("move");

            return $"{move.Id},{move.Alias},{move.SourceId},{move.DestinationId}";
        }

        public static string ToCSV(this NodeDto node)
        {
            if (node == null)
                throw new ArgumentNullException("node");

            return $"{node.Id},{node.Alias},{node.Pose.X},{node.Pose.Y},{node.Pose.Heading}";
        }

        public static string ToCSVFile(this NodeDto[] nodes)
        {
            string filePath = GACore.Tools.GetTempFilenameWithExtension(".csv");

            using (StreamWriter file = new StreamWriter(filePath))
            {
                file.WriteLine("# Id, Alias, X, Y, Heading");

                foreach (NodeDto node in nodes)
                {
                    file.WriteLine(node.ToCSV());
                }
            }

            return filePath;
        }

        public static string ToCSVFile(this MoveDto[] moves)
        {
            string filePath = GACore.Tools.GetTempFilenameWithExtension(".csv");

            using (StreamWriter file = new StreamWriter(filePath))
            {
                file.WriteLine("# Id, Alias SourceId, DestinationId");

                foreach (MoveDto move in moves)
                {
                    file.WriteLine(move.ToCSV());
                }
            }

            return filePath;
        }
    }
}