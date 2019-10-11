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

namespace SchedulingClients.DemoApp.MapClient
{
	/// <summary>
	/// Interaction logic for OccupyingMandateWindow.xaml
	/// </summary>
	public partial class OccupyingMandateWindow : Window
	{
		public OccupyingMandateWindow()
		{
			InitializeComponent();

			string html = Markdown.ToHtml(Properties.Resources.OccupyingMandateWindowDescription);
			webBrowser.NavigateToString(html);
		}
	}
}
