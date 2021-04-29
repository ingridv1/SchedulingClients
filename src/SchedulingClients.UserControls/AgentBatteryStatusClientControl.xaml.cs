using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using SchedulingClients.AgentBatteryStatusServiceReference;

namespace SchedulingClients.UserControls
{
    /// <summary>
    /// Interaction logic for AgentBatteryStatusClientControl.xaml
    /// </summary>
    public partial class AgentBatteryStatusClientControl : UserControl
    {
        public AgentBatteryStatusClientControl()
        {
            InitializeComponent();
        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            IAgentBatteryStatusClient agentBatteryStatusClient = DataContext as IAgentBatteryStatusClient;
            IEnumerable<AgentBatteryStatusData> agentBatteryStatusDatas;
            agentBatteryStatusClient.TryGetAllAgentData(out agentBatteryStatusDatas);

            agentBatteryStatusDataDataGrid.ItemsSource = agentBatteryStatusDatas;
        }
    }
}
