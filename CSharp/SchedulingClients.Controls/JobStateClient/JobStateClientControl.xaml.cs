using System.Windows;
using System.Windows.Controls;

namespace SchedulingClients.Controls.JobStateClient
{
	/// <summary>
	/// Interaction logic for JobStateClientControl.xaml
	/// </summary>
	public partial class JobStateClientControl : UserControl
	{
		public JobStateClientControl()
		{
			InitializeComponent();
		}

		private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (e.NewValue is IJobStateClient)
			{
				JobProgressDataMonitor monitor = FindResource("jpdMonitor") as JobProgressDataMonitor;
				monitor.Configure(e.NewValue as IJobStateClient);
			}
		}
	}
}