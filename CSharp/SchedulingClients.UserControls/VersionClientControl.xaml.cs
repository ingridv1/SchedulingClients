using SchedulingClients.VersionServiceReference;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchedulingClients.UserControls
{
    /// <summary>
    /// Interaction logic for VersionClientControl.xaml
    /// </summary>
    public partial class VersionClientControl : UserControl
    {
        public VersionClientControl()
        {
            InitializeComponent();
        }

        private void refreshVersionInfo_Click(object sender, RoutedEventArgs e)
        {
            VersionClient client = DataContext as VersionClient;

            SemVerData schedulerVersion;
            client.TryGetSchedulerVersion(out schedulerVersion);
            schedulerVersionText.Text = schedulerVersion.ToSemVerString();

            IEnumerable<Tuple<SemVerData, DateTime, string>> pluginVersions;
            client.TryGetPluginVersions(out pluginVersions);
            pluginVersionsGrid.ItemsSource = pluginVersions.Select(pv => new Tuple<string, string, string>(pv.Item1.ToSemVerString(), pv.Item2.ToString(), pv.Item3)).ToList();
        }
    }
}
