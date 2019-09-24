using Markdig;
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

namespace SchedulingClients.DemoApp
{
	/// <summary>
	/// Interaction logic for MapClientControlsWindow.xaml
	/// </summary>
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
