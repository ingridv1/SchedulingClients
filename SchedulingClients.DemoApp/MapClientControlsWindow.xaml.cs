using Markdig;
using System.Windows;

namespace SchedulingClients.DemoApp
{
	public partial class MapClientControlsWindow : Window
	{
		public MapClientControlsWindow()
		{
			InitializeComponent();

			string html = Markdown.ToHtml(Properties.Resources.MapClientControlsDescription);
			webBrowser.NavigateToString(html);
		}

		private void occupyingMandateButton_Click(object sender, RoutedEventArgs e)
		{
			MapClient.OccupyingMandateWindow window = new MapClient.OccupyingMandateWindow();
			window.DataContext = this.DataContext;

			window.ShowDialog();
		}

		private void nodeDataButton_Click(object sender, RoutedEventArgs e)
		{
			MapClient.NodeDataWindow window = new MapClient.NodeDataWindow();
			window.DataContext = this.DataContext;

			window.ShowDialog();
		}
	}
}
