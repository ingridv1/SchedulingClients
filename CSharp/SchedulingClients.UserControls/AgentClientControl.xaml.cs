using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
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
            AgentClient client = DataContext as AgentClient;
            AgentLifetimeState state = (AgentLifetimeState)lifeTimeComboBox.SelectedItem;
            IEnumerable<AgentData> agentDatas;

            client.TryGetAllAgentsInLifetimeState(out agentDatas, state);

            agentDataLifeTimeDataGrid.ItemsSource = agentDatas;
        }

        private void getAllAgentDataButton_Click(object sender, RoutedEventArgs e)
        {
            AgentClient client = DataContext as AgentClient;
            IEnumerable<AgentData> agentDatas;
            client.TryGetAllAgentData(out agentDatas);

            agentDataDataGrid.ItemsSource = agentDatas;
        }
    }
}