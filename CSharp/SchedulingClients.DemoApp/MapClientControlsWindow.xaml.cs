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
	}
}
