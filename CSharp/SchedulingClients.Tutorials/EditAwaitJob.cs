using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;

namespace SchedulingClients.Tutorials
{
    [TestFixture]
    public partial class Examples
    {
        [Test]
        public void EditAwaitJob()
        {
            Mock<IJobBuilderClient> moqJobBuilder = new Mock<IJobBuilderClient>();
            IJobBuilderClient jobBuilder = moqJobBuilder.Object;
        }
    }
}
