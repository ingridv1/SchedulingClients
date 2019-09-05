using SchedulingClients.JobBuilderServiceReference;
using SchedulingClients.MapServiceReference;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SchedulingClients.UserControls
{
    public partial class JobBuilderClientControl : UserControl
    {
        private IMapClient mapClient = null;

        public JobBuilderClientControl()
        {
            InitializeComponent();
        }

        public void Configure(IMapClient client)
        {
            mapClient = client;
        }

        private void createJobButton_Click(object sender, RoutedEventArgs e)
        {
            IJobBuilderClient client = DataContext as IJobBuilderClient;
            JobData jobData;
            client.TryCreateJob(out jobData);
        }

        private void multiPickJobTest_Click(object sender, RoutedEventArgs e)
        {
            IJobBuilderClient client = DataContext as IJobBuilderClient;

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
            IJobBuilderClient client = DataContext as IJobBuilderClient;

            string parameterAlias = parameterAliasTextBox.Text;

#warning Unsafe
            client.TryIssueDirective(taskIdUpDown.Value ?? 0, parameterAlias, (byte)(valueUpDown.Value ?? 0));
        }

        private void moveJobButton_Click(object sender, RoutedEventArgs e)
        {
            IJobBuilderClient client = DataContext as IJobBuilderClient;

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
            IJobBuilderClient client = DataContext as IJobBuilderClient;

			client.TryBeginEditingJob(editJobIdUpDown.Value ?? 0);
		}

		private void finishEditingJobButton_Click(object sender, RoutedEventArgs e)
		{
            IJobBuilderClient client = DataContext as IJobBuilderClient;

			client.TryFinishEditingJob(editJobIdUpDown.Value ?? 0);
		}


		private void beginEditingTaskButton_Click(object sender, RoutedEventArgs e)
		{
            IJobBuilderClient client = DataContext as IJobBuilderClient;

			client.TryBeginEditingTask(editTaskIdUpDown.Value ?? 0);
		}

		private void finishEditingTaskButton_Click(object sender, RoutedEventArgs e)
		{
            IJobBuilderClient client = DataContext as IJobBuilderClient;

			client.TryFinishEditingTask(editTaskIdUpDown.Value ?? 0);
		}

		private void orderedListTaskButton_Click(object sender, RoutedEventArgs e)
		{
            IJobBuilderClient client = DataContext as IJobBuilderClient;

			int newTaskId;

			client.TryCreateOrderedListTask(parentTaskIdUpDown.Value ?? 0, out newTaskId);
		}

		private void addGoToNodeTaskToParentButton_Click(object sender, RoutedEventArgs e)
		{
            IJobBuilderClient client = DataContext as IJobBuilderClient;

			int newGoToNodeTaskId;

			client.TryCreateGoToNodeTask(addNodeTaskParentUpDown.Value ?? 0, addNodeTaskIdUpDown.Value ?? 0, out newGoToNodeTaskId);
		}

        private void addAwaitTaskToParentButton_Click(object sender, RoutedEventArgs e)
        {
            IJobBuilderClient client = DataContext as IJobBuilderClient;

            int newMoveId;

            client.TryCreateAwaitingTask(addNodeTaskParentUpDown.Value ?? 0, addNodeTaskIdUpDown.Value ?? 0, out newMoveId);
        }

		private void addServiceTaskToParentButton_Click(object sender, RoutedEventArgs e)
		{
			IJobBuilderClient client = DataContext as IJobBuilderClient;

			int newServiceId;

			client.TryCreateServicingTask(addNodeTaskParentUpDown.Value ?? 0, addNodeTaskIdUpDown.Value ?? 0, JobBuilderServiceReference.ServiceType.Execution, out newServiceId);
		}

		private void AddChargeTaskToParentButton_Click(object sender, RoutedEventArgs e)
		{
			IJobBuilderClient client = DataContext as IJobBuilderClient;

			int newChargeId;

			client.TryCreateChargeTask(addNodeTaskParentUpDown.Value ?? 0, addNodeTaskIdUpDown.Value ?? 0, out newChargeId);
		}

		private void addSleepTaskToParentButton_Click(object sender, RoutedEventArgs e)
		{
			IJobBuilderClient client = DataContext as IJobBuilderClient;

			int newSleepId;
			double sleepSeconds;
			try
			{
				sleepSeconds = Convert.ToDouble(sleepDurationBox.Text);
			}
			catch(Exception ex)
			{
				MessageBox.Show("Could not convert the given value to a double. Please only use numerals for this value.", "Failed to parse integer", MessageBoxButton.OK);
				return;
			}

			client.TryCreateSleepingTask(addNodeTaskParentUpDown.Value ?? 0, addNodeTaskIdUpDown.Value ?? 0, out newSleepId, TimeSpan.FromSeconds(sleepSeconds));
		}

		private void commitJobButton_Click(object sender, RoutedEventArgs e)
        {
            IJobBuilderClient client = DataContext as IJobBuilderClient;

            bool success;
            client.TryCommit(jobIdUpDown.Value ?? 1, out success, agentIdUpDown.Value ?? -1);
        }
	}
}