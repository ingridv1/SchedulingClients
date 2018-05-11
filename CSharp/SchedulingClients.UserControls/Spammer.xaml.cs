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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchedulingClients.UserControls
{
    /// <summary>
    /// Interaction logic for Spammer.xaml
    /// </summary>
    public partial class Spammer : UserControl
    {
        public Spammer()
        {
            InitializeComponent();
        }

        private void spamButton_Click(object sender, RoutedEventArgs e)
        {
            MapClient mapClient = DataContext as MapClient;

            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    IEnumerable<NodeData> mock;
                    mapClient.TryGetAllNodeData(out mock);
                    Application.Current.Dispatcher.BeginInvoke((Action) (() =>
                    {
                        spamIndicator.IsChecked = !spamIndicator.IsChecked;
                    }));
                }
            });
        }
    }
}
