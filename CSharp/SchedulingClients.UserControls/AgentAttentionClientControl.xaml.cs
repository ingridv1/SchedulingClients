using SchedulingClients.AgentAttentionServiceReference;
using System.Windows;
using System.Windows.Controls;

namespace SchedulingClients.UserControls
{
    /// <summary>
    /// Interaction logic for AgentAttentionClientControl.xaml
    /// </summary>
    public partial class AgentAttentionClientControl : UserControl
	{
		public AgentAttentionClientControl()
		{
			InitializeComponent();
        }
        
        private void AgentAttentionClient_AgentAttentionChange(AgentAttentionData agentAttentionData)
        {
            agentAttentionDataGrid.ItemsSource = agentAttentionData.RequiringAttention;
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            AgentAttentionClient agentAttentionClient = DataContext as AgentAttentionClient;

            agentAttentionClient.AgentAttentionChange += AgentAttentionClient_AgentAttentionChange;
        }
    }
}
