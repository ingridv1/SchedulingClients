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
using Markdig;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using SchedulingClients.Controls.TaskStateClient;
using SchedulingClients.Client_Interfaces;
using BaseClients;

namespace SchedulingClients.DemoApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		TaskStateClientControl nullControl = null;

		public MainWindow()
		{
			InitializeComponent();

			string html = Markdown.ToHtml(Properties.Resources.MainWindowDescription);
			webBrowser.NavigateToString(html);
		}

		private EndpointSettings? HandleCreateEndpointSetttings()
		{
			IPAddress ipAddress = ipV4Control.ToIPAddress();

			if (ipAddress == null)
			{
				MessageBox.Show("IPv4 Address is invalid", "Invalid IP Address", MessageBoxButton.OK, MessageBoxImage.Error);
				return null;
			}

			return new EndpointSettings(ipAddress);
		}

		private void TscControlButton_Click(object sender, RoutedEventArgs e)
		{
			EndpointSettings? endpointSettings = HandleCreateEndpointSetttings();
			if (endpointSettings == null) return;

			using (ITaskStateClient client = SchedulingClients.ClientFactory.CreateTcpTaskStateClient((EndpointSettings)endpointSettings))
			{
				TaskStateClientControlsWindow window = new TaskStateClientControlsWindow()
				{
					DataContext = client
				};

				window.ShowDialog();
			}
		}

		private void JscControlButton_Click(object sender, RoutedEventArgs e)
		{
			EndpointSettings? endpointSettings = HandleCreateEndpointSetttings();
			if (endpointSettings == null) return;

			using (IJobStateClient client = SchedulingClients.ClientFactory.CreateTcpJobStateClient((EndpointSettings)endpointSettings))
			{
				JobStateClientControlsWindow window = new JobStateClientControlsWindow()
				{
					DataContext = client
				};

				window.ShowDialog();
			}
		}

		private void McControlButton_Click(object sender, RoutedEventArgs e)
		{
			EndpointSettings? endpointSettings = HandleCreateEndpointSetttings();
			if (endpointSettings == null) return;

			using (IMapClient client = SchedulingClients.ClientFactory.CreateTcpMapClient((EndpointSettings)endpointSettings))
			{
				MapClientControlsWindow window = new MapClientControlsWindow()
				{
					DataContext = client
				};

				window.ShowDialog();
			}
		}
	}
}
