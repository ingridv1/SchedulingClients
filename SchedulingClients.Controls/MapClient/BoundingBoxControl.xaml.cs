using System;
using System.Windows;
using System.Windows.Controls;

namespace SchedulingClients.Controls.MapClient
{
	public partial class BoundingBoxControl : UserControl
	{
		public static readonly RoutedEvent BoundingBoxUpdatedEvent =
			EventManager.RegisterRoutedEvent(
				"BoundingBoxUpdated",
				RoutingStrategy.Bubble,
				typeof(BoundingBoxEventHandler), 
				typeof(BoundingBoxControl));

		public delegate void BoundingBoxEventHandler(object sender, RectRoutedEventArgs e);

		public event BoundingBoxEventHandler BoundingBoxUpdated
		{
			add { AddHandler(BoundingBoxUpdatedEvent, value); }
			remove { RemoveHandler(BoundingBoxUpdatedEvent, value); }
		}

		public BoundingBoxControl()
		{
			InitializeComponent();
		}

		private void RaiseBoundingBoxUpdatedEvent()
		{
			RectRoutedEventArgs newEventArgs = new RectRoutedEventArgs(BoundingBoxControl.BoundingBoxUpdatedEvent)
			{
				Rect = ToRect()
			};

			RaiseEvent(newEventArgs);
		}

		public Rect ToRect()
		{
			Point min = new Point(xRange.LowerValue, yRange.LowerValue);
			Point max = new Point(xRange.HigherValue, yRange.HigherValue);

			return new Rect(min, max);
		}

		private void XRange_LowerValueChanged(object sender, RoutedEventArgs e)
		{
			RaiseBoundingBoxUpdatedEvent();
		}

		private void XRange_HigherValueChanged(object sender, RoutedEventArgs e)
		{
			RaiseBoundingBoxUpdatedEvent();
		}

		private void YRange_LowerValueChanged(object sender, RoutedEventArgs e)
		{
			RaiseBoundingBoxUpdatedEvent();
		}

		private void YRange_HigherValueChanged(object sender, RoutedEventArgs e)
		{
			RaiseBoundingBoxUpdatedEvent();
		}
	}
}
