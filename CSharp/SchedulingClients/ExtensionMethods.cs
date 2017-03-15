using SchedulingClients.JobBuilderServiceReference;
using SchedulingClients.RoadmapServiceReference;
using System.Linq;
using System.Text;

namespace SchedulingClients
{
    public static class ExtensionMethods
    {
        public static string ToJobDataString(this JobData jobData)
        {
            return string.Format("JobData: JobId:{0}, OrderedListTaskId:{1}", jobData.JobId, jobData.OrderedListTaskId);
        }

        public static string ToNodeDataString(this NodeData nodeData)
        {
            return string.Format("NodeData: MapItemId:{0}, Alias:{1}, {2}, {3}", nodeData.MapItemId, nodeData.Alias, nodeData.ToPoseString(), nodeData.ToServicesString());
        }

        public static string ToPoseString(this NodeData nodeData)
        {
            return string.Format("X:{0} Y:{1} Heading:{2}", nodeData.X, nodeData.Y, nodeData.HeadingRad);
        }

        public static string ToServicesString(this NodeData nodeData)
        {
            if (nodeData.Services.Any())
            {
                StringBuilder builder = new StringBuilder("Services: ");

                foreach (RoadmapServiceReference.ServiceType serviceType in nodeData.Services)
                {
                    builder.AppendFormat("{0}", serviceType);
                }

                return builder.ToString();
            }

            return "Services unsupported";
        }
    }
}