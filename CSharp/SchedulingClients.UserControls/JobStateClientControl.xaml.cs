using System;
using System.Windows;
using System.Windows.Controls;
using SchedulingClients.JobStateServiceReference;
using System.Collections.ObjectModel;

namespace SchedulingClients.UserControls
{
    /// <summary>
    /// Interaction logic for JobStateClientControl.xaml
    /// </summary>
    public partial class JobStateClientControl : UserControl
    {
        private ObservableCollection<TaskProgressData> recentData = new ObservableCollection<TaskProgressData>();

        public JobStateClientControl()
        {
            InitializeComponent();
            recentTaskProgressUpdatesDataGrid.DataContext = recentData;
        }

        private void Client_TaskStateUpdated(TaskProgressData obj)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                recentData.Add(obj);
            }));
        }

        private void getJobStateButton_Click(object sender, RoutedEventArgs e)
        {
            JobStateData jobStateData;

            JobStateClient jobStateClient = DataContext as JobStateClient;
            if (jobStateClient.TryGetJobState((int)getJobStateId.Value, out jobStateData) == true)
            {
                jobStateDataControl.DataContext = jobStateData;
            }
        }

        private void getJobStateFromTaskIdButton_Click(object sender, RoutedEventArgs e)
        {
            JobStateData jobStateData;

            JobStateClient jobStateClient = DataContext as JobStateClient;
            if (jobStateClient.TryGetParentJobStateFromTaskId((int)getJobStateFromTaskId.Value, out jobStateData) == true)
            {
                jobStateDataControl.DataContext = jobStateData;
            }
        }

        private void UserControl_DataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is JobStateClient)
            {
                JobStateClient client = e.NewValue as JobStateClient;
                client.TaskStateUpdated += Client_TaskStateUpdated;
            }
        }
    }
}