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
    /// Interaction logic for FleetManagerClientControl.xaml
    /// </summary>
    public partial class FleetManagerClientControl : UserControl
    {
        public FleetManagerClientControl()
        {
            InitializeComponent();
        }

        private void freezeButton_Click(object sender, RoutedEventArgs e)
        {
            FleetManagerClient fleetManagerClient = DataContext as FleetManagerClient;
            bool success;
            fleetManagerClient.TryRequestFreeze(out success);
        }

        private void unfreezeButton_Click(object sender, RoutedEventArgs e)
        {
            FleetManagerClient fleetManagerClient = DataContext as FleetManagerClient;
            bool success;
            fleetManagerClient.TryRequestUnfreeze(out success);
        }

        private void subscribeButton_Click(object sender, RoutedEventArgs e)
        {
            FleetManagerClient fleetManagerClient = DataContext as FleetManagerClient;
            bool success;
            fleetManagerClient.TrySubscribeFleetStateCastHeartbeat(out success);
        }
    }
}