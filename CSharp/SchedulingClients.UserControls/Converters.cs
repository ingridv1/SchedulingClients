using SchedulingClients.MapServiceReference;
using System;
using System.Globalization;
using System.Linq;
using System.Text;
using UDPCasts;
using System.Windows.Data;

namespace SchedulingClients.UserControls
{
    public class DegStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            PoseIPStruct poseIP = (PoseIPStruct)value;
            return poseIP.ToPoseIPStringDeg();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ServiceTypeArrayToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ServiceType[] serviceTypes = value as ServiceType[];

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < serviceTypes.Count(); i++)
            {
                if (i + 1 < serviceTypes.Count())
                {
                    builder.AppendFormat("{0}, ", serviceTypes[i]);
                }
                else
                {
                    builder.AppendFormat("{0}", serviceTypes[i]);
                }
            }
            return builder.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}