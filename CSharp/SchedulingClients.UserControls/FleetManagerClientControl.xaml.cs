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
using SchedulingClients.FleetManagerServiceReference;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

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

        private void commitMenuItem_Click(object sender, RoutedEventArgs e)
        {           

            FleetManagerClient fleetManagerClient = DataContext as FleetManagerClient;
            KingpinState state = fleetManagerClient.LastFleetStateReceived.KingpinStates.FirstOrDefault();

            // Crude bit of code to just add a straight line for a pose of zero and no waypoint
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();

            byte[] bytes;

            using (Stream resFileStream = assembly.GetManifestResourceStream(@"SchedulingClients.UserControls.Resources.extendedWaypointBytes.txt"))
            {
                bytes = new byte[resFileStream.Length];
                resFileStream.Read(bytes, 0, bytes.Length);
            }
            bool success;
            fleetManagerClient.TryCommitExtendedWaypoints(state.IPAddress, 1, bytes, out success);
        }
    }
}