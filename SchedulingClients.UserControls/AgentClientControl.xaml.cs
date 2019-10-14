using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using SchedulingClients.AgentServiceReference;

namespace SchedulingClients.UserControls
{
    /// <summary>
    /// Interaction logic for AgentClientControl.xaml
    /// </summary>
    public partial class AgentClientControl : UserControl
    {
        public AgentClientControl()
        {
            InitializeComponent();
        }

        private void getAgentLifeTimeDataButton_Click(object sender, RoutedEventArgs e)
        {
            IAgentClient client = DataContext as IAgentClient;
            AgentLifetimeState state = (AgentLifetimeState)lifeTimeComboBox.SelectedItem;
            IEnumerable<AgentData> agentDatas;

            client.TryGetAllAgentsInLifetimeState(out agentDatas, state);

            agentDataLifeTimeDataGrid.ItemsSource = agentDatas;
        }

        private void getAllAgentDataButton_Click(object sender, RoutedEventArgs e)
        {
            IAgentClient client = DataContext as IAgentClient;
            IEnumerable<AgentData> agentDatas;
            client.TryGetAllAgentData(out agentDatas);

            agentDataDataGrid.ItemsSource = agentDatas;
        }

        private void setAgentLifetimeStateButton_Click(object sender, RoutedEventArgs e)
        {
            IAgentClient client = DataContext as IAgentClient;
            AgentLifetimeState desired = (AgentLifetimeState)desiredLifetimeStateComboBox.SelectedItem;
            int agentId = (int)agentLifetimeStateIdUpDown.Value;

            bool success;
            client.TrySetAgentLifetimeState(agentId, desired, out success);

            if (success)
            {
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Failed to set agent lifetime state");
            }
        }
    }
}