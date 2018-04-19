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

		private void attentionRefreshButton_Click(object sender, RoutedEventArgs e)
		{
			AgentAttentionClient agentAttentionClient = DataContext as AgentAttentionClient;
			agentAttentionDataGrid.ItemsSource = agentAttentionClient.AgentAttentionData.RequiringAttention;
		}
	}
}
