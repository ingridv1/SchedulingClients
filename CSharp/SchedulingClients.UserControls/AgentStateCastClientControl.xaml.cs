using SchedulingClients.AgentStatecastServiceReference;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace SchedulingClients.UserControls
{
    /// <summary>
    /// Interaction logic for AgentStateCastClientControl.xaml
    /// </summary>
    public partial class AgentStateCastClientControl : UserControl
	{
		public AgentStateCastClientControl()
		{
			InitializeComponent();
		}

		private void enumVariableButton_Click(object sender, RoutedEventArgs e)
		{
			byte var;
            IAgentStatecastClient client = DataContext as IAgentStatecastClient;
			client.TryGetEnumStatecastValue(enumVariableUpDown.Value ?? 0, enumAliasBox.Text, out var);
			enumBox.Text = var.ToString();
		}

		private void floatVariableButton_Click(object sender, RoutedEventArgs e)
		{
			float var;
            IAgentStatecastClient client = DataContext as IAgentStatecastClient;
			client.TryGetFloatStatecastValue(floatVariableUpDown.Value ?? 0, floatAliasBox.Text, out var);
			floatBox.Text = var.ToString();
		}

		private void shortVariableButton_Click(object sender, RoutedEventArgs e)
		{
			short var;
            IAgentStatecastClient client = DataContext as IAgentStatecastClient;
			client.TryGetShortStatecastValue(shortVariableUpDown.Value ?? 0, shortAliasBox.Text, out var);
			shortBox.Text = var.ToString();
		}

		private void ushortVariableButton_Click(object sender, RoutedEventArgs e)
		{
			ushort var;
            IAgentStatecastClient client = DataContext as IAgentStatecastClient;
			client.TryGetUShortStatecastValue(ushortVariableUpDown.Value ?? 0, ushortAliasBox.Text, out var);
			ushortBox.Text = var.ToString();
		}

		private void ipVariableButton_Click(object sender, RoutedEventArgs e)
		{
			IPAddress var;
            IAgentStatecastClient client = DataContext as IAgentStatecastClient;
			client.TryGetIPAddressStatecastValue(ipVariableUpDown.Value ?? 0, ipAliasBox.Text, out var);
			var ipVar = var.GetAddressBytes();
			ipBox1.Text = ipVar[0].ToString();
			ipBox2.Text = ipVar[1].ToString();
			ipBox3.Text = ipVar[2].ToString();
			ipBox4.Text = ipVar[3].ToString();
		}

        private void uintegerVariableButton_Click(object sender, RoutedEventArgs e)
        {
            uint var;
            IAgentStatecastClient client = DataContext as IAgentStatecastClient;
            client.TryGetUIntegerStatecastValue(uintegerVariableUpDown.Value ?? 0, uintegerAliasBox.Text, out var);
            uintegerBox.Text = var.ToString();
        }

        private void integerVariableButton_Click(object sender, RoutedEventArgs e)
        {
            int var;
            IAgentStatecastClient client = DataContext as IAgentStatecastClient;
            client.TryGetIntegerStatecastValue(integerVariableUpDown.Value ?? 0, integerAliasBox.Text, out var);
            integerBox.Text = var.ToString();
        }
    }
}
