using System.Windows;
using System.Windows.Controls;

namespace SchedulingClients.Controls.TaskStateClient
{
	/// <summary>
	/// Interaction logic for TaskStateClientControl.xaml
	/// </summary>
	public partial class TaskStateClientControl : UserControl
	{
		public TaskStateClientControl()
		{
			InitializeComponent();
		}

		private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (e.NewValue is ITaskStateClient)
			{
				TaskProgressDataMonitor monitor = FindResource("tpdMonitor") as TaskProgressDataMonitor;
				monitor.Configure(e.NewValue as ITaskStateClient);
			}
		}
	}
}