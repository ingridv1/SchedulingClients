using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SchedulingClients.FleetManagerServiceReference;
using System.IO;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Xml.Linq;
using GAClients;

namespace SchedulingClients.UserControls
{
    /// <summary>
    /// Interaction logic for FleetManagerClientControl.xaml
    /// </summary>
    public partial class FleetManagerClientControl : UserControl
    {
        public FleetManagerClientControl()
        {
            readonlyMailboxes = new ReadOnlyObservableCollection<KingpinStateMailbox>(mailboxes);
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

        private ObservableCollection<KingpinStateMailbox> mailboxes = new ObservableCollection<KingpinStateMailbox>();

        private ReadOnlyObservableCollection<KingpinStateMailbox> readonlyMailboxes;

        internal ReadOnlyObservableCollection<KingpinStateMailbox> Mailboxes { get { return readonlyMailboxes; } }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is FleetManagerClient)
            {
                FleetManagerClient client = e.NewValue as FleetManagerClient;
                client.PropertyChanged += Client_PropertyChanged;
                dataGrid.ItemsSource = mailboxes;
            }
        }

        private void HandleKingpinStates(IEnumerable<KingpinState> kingpinStates)
        {
            foreach(KingpinState kingpinState in kingpinStates.ToList())
            {
                KingpinStateMailbox mailbox = mailboxes.FirstOrDefault(e => e.KingpinState.IPAddress.Equals(kingpinState.IPAddress));

                if (mailbox != null)
                {
                    mailbox.Update(kingpinState);
                }
                else
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        mailboxes.Add(new KingpinStateMailbox(kingpinState));
                    });         
                }
            }
        }

        private void Client_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "LastFleetStateReceived":
                    {
                        FleetManagerClient client = sender as FleetManagerClient;
                        HandleKingpinStates(client.LastFleetStateReceived.KingpinStates);
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
        }

        private void getKingpinDescription_Click(object sender, RoutedEventArgs e)
        {
            FleetManagerClient client = DataContext as FleetManagerClient;

            KingpinStateMailbox mailbox = dataGrid.SelectedItem as KingpinStateMailbox;
            XDocument xDocument;

            ServiceOperationResult result = client.TryGetKingpinDescription(mailbox.KingpinState.IPAddress, out xDocument);

            if (result.IsSuccessfull)
            {
                string tempFile = Path.GetTempPath() + System.Guid.NewGuid().ToString() + ".xml";
                xDocument.Save(tempFile);

                System.Diagnostics.Process.Start(tempFile);
            }         
        }
    }
}