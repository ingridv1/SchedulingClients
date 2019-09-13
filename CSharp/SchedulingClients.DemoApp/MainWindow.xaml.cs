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

		private void TscControlButton_Click(object sender, RoutedEventArgs e)
		{
			IPAddress ipAddress = ipV4Control.ToIPAddress();

			if (ipAddress == null)
			{
				MessageBox.Show("IPv4 Address is invalid", "Invalid IP Address", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			using (ITaskStateClient client = SchedulingClients.ClientFactory.CreateTcpTaskStatecastClient(new EndpointSettings(ipAddress)))
			{
				TaskStateClientControlsWindow window = new TaskStateClientControlsWindow()
				{
					DataContext = client
				};

				window.ShowDialog();
			}
		}
	}
}
