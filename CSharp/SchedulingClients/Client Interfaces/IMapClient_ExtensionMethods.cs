using SchedulingClients.MapServiceReference;
using System.Collections.Generic;
using System.Linq;

namespace SchedulingClients.Client_Interfaces
{
    public static class IMapClient_ExtensionMethods
    {
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
