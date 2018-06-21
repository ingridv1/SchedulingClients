using SchedulingClients.JobBuilderServiceReference;
using SchedulingClients.MapServiceReference;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SchedulingClients.UserControls
{
    public partial class JobBuilderClientControl : UserControl
    {
        private MapClient mapClient = null;

        public JobBuilderClientControl()
        {
            InitializeComponent();
        }

        public void Configure(MapClient client)
        {
            mapClient = client;
        }

        private void createJobButton_Click(object sender, RoutedEventArgs e)
        {
            JobBuilderClient client = DataContext as JobBuilderClient;
            JobData jobData;
            client.TryCreateJob(out jobData);
        }

        private void multiPickJobTest_Click(object sender, RoutedEventArgs e)
        {
            JobBuilderClient client = DataContext as JobBuilderClient;

            if (mapClient != null)
            {
                IEnumerable<NodeData> nodeData;
                if (mapClient.TryGetAllNodeData(out nodeData) == true)
                {
                    client.MultiPickJobTest(nodeData);
                }
                else
                {
                    MessageBox.Show("Failed to get node data from map client");
                }
            }
            else
            {
                MessageBox.Show("Map client is null");
            }
        }

        private void directiveTest_Click(object sender, RoutedEventArgs e)
        {
            JobBuilderClient client = DataContext as JobBuilderClient;

#warning Unsafe
            client.TryIssueDirective(taskIdUpDown.Value ?? 0, parameterIdUpDown.Value ?? 0, (byte)(valueUpDown.Value ?? 0));
        }

        private void moveJobButton_Click(object sender, RoutedEventArgs e)
        {
            JobBuilderClient client = DataContext as JobBuilderClient;

            if (mapClient != null)
            {
                IEnumerable<NodeData> nodeData;
                if (mapClient.TryGetAllNodeData(out nodeData) == true)
                {
                    client.MoveJobTest(nodeData, finalisedPipelineCheck.IsChecked ?? true);
                }
            }
        }

		private void beginEditingJobButton_Click(object sender, RoutedEventArgs e)
		{
			JobBuilderClient client = DataContext as JobBuilderClient;

			client.TryBeginEditingJob(editJobIdUpDown.Value ?? 0);
		}

		private void finishEditingJobButton_Click(object sender, RoutedEventArgs e)
		{
			JobBuilderClient client = DataContext as JobBuilderClient;

			client.TryFinishEditingJob(editJobIdUpDown.Value ?? 0);
		}

		private void finaliseButton_Click(object sender, RoutedEventArgs e)
		{
			JobBuilderClient client = DataContext as JobBuilderClient;

			client.TryFinaliseTask(taskToFinaliseUpDown.Value ?? 0);
		}

		private void beginEditingTaskButton_Click(object sender, RoutedEventArgs e)
		{
			JobBuilderClient client = DataContext as JobBuilderClient;

			client.TryBeginEditingTask(editTaskIdUpDown.Value ?? 0);
		}

		private void finishEditingTaskButton_Click(object sender, RoutedEventArgs e)
		{
			JobBuilderClient client = DataContext as JobBuilderClient;

			client.TryFinishEditingTask(editTaskIdUpDown.Value ?? 0);
		}

		private void nonFinalisedTaskButton_Click(object sender, RoutedEventArgs e)
		{
			JobBuilderClient client = DataContext as JobBuilderClient;

			int newTaskId;

			client.TryCreateOrderedListTask(parentTaskIdUpDown.Value ?? 0, false, out newTaskId);
		}

		private void addNodeTaskToParentButton_Click(object sender, RoutedEventArgs e)
		{
			JobBuilderClient client = DataContext as JobBuilderClient;

			int newMoveId;

			client.TryCreateMovingTask(addNodeTaskParentUpDown.Value ?? 0, addNodeTaskIdUpDown.Value ?? 0, out newMoveId);
		}

        private void commitJobButton_Click(object sender, RoutedEventArgs e)
        {
            JobBuilderClient client = DataContext as JobBuilderClient;

            bool success;
            client.TryCommit(jobIdUpDown.Value ?? 1, out success);
        }
    }
}