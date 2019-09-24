using System.Windows;
using System.Windows.Controls;

namespace SchedulingClients.Controls.MapClient
{
	public partial class BoundingBoxControl : UserControl
	{
		public BoundingBoxControl()
		{
			InitializeComponent();
		}

		public Rect ToRect()
		{
			Point min = new Point(xRange.Minimum, yRange.Minimum);
			Point max = new Point(xRange.Maximum, yRange.Maximum);

			return new Rect(min, max);
		}
	}
}
