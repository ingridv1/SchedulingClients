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

        private void getAllAgentDataButton_Click(object sender, RoutedEventArgs e)
        {
            AgentClient client = DataContext as AgentClient;
            IEnumerable<AgentData> agentDatas;
            client.TryGetAllAgentData(out agentDatas);

            agentDataDataGrid.ItemsSource = agentDatas;
        }
    }
}