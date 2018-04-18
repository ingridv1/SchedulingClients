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
using SchedulingClients.AgentAttentionServiceReference;

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
