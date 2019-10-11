using SchedulingClients.MapServiceReference;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Text;

namespace SchedulingClients.Controls.MapClient
{
	public class SerivcesToStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			ServiceType[] serviceTypes = value as ServiceType[];

			if (!serviceTypes.Any()) return "No supported services";

			StringBuilder builder = new StringBuilder();

			int numServices = serviceTypes.Count();

			for (int i = 0; i < numServices; i++)
			{
				if (i == numServices -1) builder.Append(serviceTypes[i].ToString());
				else builder.AppendLine(serviceTypes[i].ToString());
			}

			return builder.ToString();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}

	public class HasServicesConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			ServiceType[] serviceTypes = value as ServiceType[];
			return serviceTypes.Any();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
