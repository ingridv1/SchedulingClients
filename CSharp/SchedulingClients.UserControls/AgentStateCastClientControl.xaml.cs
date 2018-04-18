using SchedulingClients.AgentStatecastserviceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
			AgentStatecastClient client = DataContext as AgentStatecastClient;
			client.TryGetEnumStatecastParameter(enumVariableUpDown.Value ?? 0, enumAliasBox.Text, out var);
			enumBox.Text = var.ToString();
		}

		private void floatVariableButton_Click(object sender, RoutedEventArgs e)
		{
			float var;
			AgentStatecastClient client = DataContext as AgentStatecastClient;
			client.TryGetFloatStatecastParameter(floatVariableUpDown.Value ?? 0, floatAliasBox.Text, out var);
			floatBox.Text = var.ToString();
		}

		private void shortVariableButton_Click(object sender, RoutedEventArgs e)
		{
			short var;
			AgentStatecastClient client = DataContext as AgentStatecastClient;
			client.TryGetShortStatecastParameter(shortVariableUpDown.Value ?? 0, shortAliasBox.Text, out var);
			shortBox.Text = var.ToString();
		}

		private void ushortVariableButton_Click(object sender, RoutedEventArgs e)
		{
			ushort var;
			AgentStatecastClient client = DataContext as AgentStatecastClient;
			client.TryGetUShortStatecastParameter(ushortVariableUpDown.Value ?? 0, ushortAliasBox.Text, out var);
			ushortBox.Text = var.ToString();
		}

		private void ipVariableButton_Click(object sender, RoutedEventArgs e)
		{
			IPAddress var;
			AgentStatecastClient client = DataContext as AgentStatecastClient;
			client.TryGetIPAddressStatecastParameter(ipVariableUpDown.Value ?? 0, ipAliasBox.Text, out var);
			var ipVar = var.GetAddressBytes();
			ipBox1.Text = ipVar[0].ToString();
			ipBox2.Text = ipVar[1].ToString();
			ipBox3.Text = ipVar[2].ToString();
			ipBox4.Text = ipVar[3].ToString();
		}

		private void descriptionButton_Click(object sender, RoutedEventArgs e)
		{
			AgentStatecastClient client = DataContext as AgentStatecastClient;
			CastType castType = new CastType();

			client.TryGetStatecastDescription(descriptionUpDown.Value ?? 0, out castType);
			StringBuilder builder = new StringBuilder();
			builder.AppendLine(string.Format("Code:{0}", castType.Code.ToString()));
			builder.AppendLine(string.Format("Label:{0}", castType.Label));
			builder.AppendLine(string.Format("NumBytes:{0}", castType.NumBytes.ToString()));
			builder.AppendLine(string.Format("ExtensionData:{0}", castType.ExtensionData.ToString()));
			builder.AppendLine("Variables:");
			foreach (var var in castType.Variables)
			{
				builder.AppendLine(string.Format("-{0}", var.ToString()));
			}
			MessageBox.Show(builder.ToString());
		}
	}
}
