using System.Windows;
using System.Windows.Controls;

namespace SchedulingClients.UserControls
{
    /// <summary>
    /// Interaction logic for JobsStateClientControl.xaml
    /// </summary>
    public partial class JobsStateClientControl : UserControl
    {
        public JobsStateClientControl()
        {
            InitializeComponent();
        }

        private void abortAllJobsButton_Click(object sender, RoutedEventArgs e)
        {
            JobsStateClient jobsStateClient = DataContext as JobsStateClient;
            bool success;
            jobsStateClient.TryAbortAllJobs(out success);
        }

        private void abortJobButton_Click(object sender, RoutedEventArgs e)
        {
            bool couldAbort;

            JobsStateClient jobsStateClient = DataContext as JobsStateClient;
            jobsStateClient.TryAbortJob((int)abortJobId.Value, out couldAbort);
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            JobsStateClient jobsStateClient = DataContext as JobsStateClient;
        }

        private void abortTaskButton_Click(object sender, RoutedEventArgs e)
        {
            bool couldAbort;

            JobsStateClient jobsStateClient = DataContext as JobsStateClient;
            jobsStateClient.TryAbortTask((int)abortTaskId.Value, out couldAbort);
        }

		private void resolveTaskFaultButton_Click(object sender, RoutedEventArgs e)
		{
			bool resolveSuccess;

			JobsStateClient jobsStateClient = DataContext as JobsStateClient;
			jobsStateClient.TryResolveFaultedTask((int)resolveTaskFaultId.Value, out resolveSuccess);
		}

		private void resolveJobFaultButton_Click(object sender, RoutedEventArgs e)
		{
			bool resolveSuccess;

			JobsStateClient jobsStateClient = DataContext as JobsStateClient;
			jobsStateClient.TryResolveFaultedJob((int)resolveJobFaultId.Value, out resolveSuccess);
		}
	}
}