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
            IJobsStateClient jobsStateClient = DataContext as IJobsStateClient;
            bool success;
            jobsStateClient.TryAbortAllJobs(out success);
        }

        private void abortJobButton_Click(object sender, RoutedEventArgs e)
        {
            bool couldAbort;

            IJobsStateClient jobsStateClient = DataContext as IJobsStateClient;
            jobsStateClient.TryAbortJob((int)abortJobId.Value, out couldAbort);
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            IJobsStateClient jobsStateClient = DataContext as IJobsStateClient;
        }

        private void abortTaskButton_Click(object sender, RoutedEventArgs e)
        {
            bool couldAbort;

            IJobsStateClient jobsStateClient = DataContext as IJobsStateClient;
            jobsStateClient.TryAbortTask((int)abortTaskId.Value, out couldAbort);
        }

        private void abortAllJobsForAgentButton_Click(object sender, RoutedEventArgs e)
        {
            int agentId = (int)abortAllJobsForAgentId.Value;

            bool success;

            IJobsStateClient jobsStateClient = DataContext as IJobsStateClient;
            jobsStateClient.TryAbortAllJobsForAgent(agentId, out success);
        }
    }
}