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
    }
}