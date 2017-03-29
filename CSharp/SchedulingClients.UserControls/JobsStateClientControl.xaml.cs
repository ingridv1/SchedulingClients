using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

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
            jobsStateClient.TryAbortAllJobs();
        }

        private void abortJobButton_Click(object sender, RoutedEventArgs e)
        {
            bool couldAbort;

            JobsStateClient jobsStateClient = DataContext as JobsStateClient;
            jobsStateClient.TryAbortJob((int)abortJobId.Value, out couldAbort);
        }

        private void JobsStateClient_JobsStateChange(JobsStateServiceReference.JobsStateData obj)
        {
            throw new NotImplementedException();
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            JobsStateClient jobsStateClient = DataContext as JobsStateClient;
            jobsStateClient.JobsStateChange += JobsStateClient_JobsStateChange;
        }
    }
}