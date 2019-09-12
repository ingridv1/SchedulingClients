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
	/// Interaction logic for TaskStateClientControlsWindow.xaml
	/// </summary>
	public partial class TaskStateClientControlsWindow : Window
	{
		public TaskStateClientControlsWindow()
		{
			InitializeComponent();

			string html = Markdown.ToHtml(Properties.Resources.TaskStateClientControlsWindowDescription);
			webBrowser.NavigateToString(html);
		}
	}
}
