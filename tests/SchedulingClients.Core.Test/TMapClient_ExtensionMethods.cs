using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SchedulingClients.Core.MapServiceReference;

namespace SchedulingClients.Core.Test
{
    [TestFixture]
    public class TMapClient_ExtensionMethods
    {
        [Test]
        public void ToPercentageComplete_Empty()
        {
            IEnumerable<OccupyingMandateMapItemDto> empty = Enumerable.Empty<OccupyingMandateMapItemDto>();
            Assert.AreEqual(double.NaN, empty.ToPercentageComplete());
        }

        [Test]
        [TestCase(1,1,100)]
        [TestCase(2, 1, 50)]
        [TestCase(2, 2, 100)]
        [TestCase(5, 0, 0)]
        [TestCase(5, 1, 20)]
        [TestCase(5, 2, 40)]
        [TestCase(5, 3, 60)]
        [TestCase(5, 4, 80)]
        [TestCase(5, 5, 100)]
        public void ToPercentageComplete(int numItems, int numComplete, double expected)
        {
            List<OccupyingMandateMapItemDto> dataSet = new List<OccupyingMandateMapItemDto>();

            for(int i = 0; i < numItems; i++)
            {
                dataSet.Add(new OccupyingMandateMapItemDto()
                {
                    MapItemId = i,
                    IsOccupied = i < numComplete
                });
            }

            Assert.AreEqual(expected, dataSet.ToPercentageComplete());
        }
    }
}
