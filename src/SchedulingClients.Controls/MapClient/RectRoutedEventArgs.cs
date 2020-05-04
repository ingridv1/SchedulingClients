using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchedulingClients.Controls.MapClient
{
	public class RectRoutedEventArgs : RoutedEventArgs
	{
		public Rect Rect { get; set; }

		public RectRoutedEventArgs(RoutedEvent routedEvent)
			:base(routedEvent)
		{
		}
	}
}
