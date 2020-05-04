using SchedulingClients.MapServiceReference;
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
using System.Windows.Shapes;

namespace SchedulingClients.DemoApp.MapClient
{
	/// <summary>
	/// Interaction logic for NodeDataWindow.xaml
	/// </summary>
	public partial class NodeDataWindow : Window
	{
		public NodeDataWindow()
		{
			InitializeComponent();
		}

		private void HandleRefresh()
		{
			try
			{
				IMapClient mapClient = DataContext as IMapClient;

				mapClient.TryGetAllNodeData(out IEnumerable<NodeData> nodeData);
				nodeDataControl.DataContext = nodeData;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Operation Failed", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void Window_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			HandleRefresh();
		}

		private void refreshButton_Click(object sender, RoutedEventArgs e)
		{
			HandleRefresh();
		}
	}
}
