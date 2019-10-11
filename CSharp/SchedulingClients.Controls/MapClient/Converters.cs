using SchedulingClients.MapServiceReference;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SchedulingClients.Controls.MapClient
{
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
