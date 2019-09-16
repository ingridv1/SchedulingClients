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
	/// Interaction logic for JobStateClientControlsWindow.xaml
	/// </summary>
	public partial class JobStateClientControlsWindow : Window
	{
		public JobStateClientControlsWindow()
		{
			InitializeComponent();

			string html = Markdown.ToHtml(Properties.Resources.JobStateClientControlsWindowDescription);
			webBrowser.NavigateToString(html);
		}
	}
}
