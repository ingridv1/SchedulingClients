using System.Net;
using System.Windows;

namespace SchedulingClients.DemoClientApp
{
    /// <summary>
    /// Interaction logic for StartupWindow.xaml
    /// </summary>
    public partial class StartupWindow : Window
    {
        public StartupWindow()
        {
            InitializeComponent();
            ipAddressControl.IPAddress = new IPAddress(new byte[] { 127, 0, 0, 1 });
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            Close();
            Application.Current.Shutdown(0);
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            ushort http = (ushort)httpPort.Value;
            ushort tcp = (ushort)tcpPort.Value;
 
            DemoClient demoClient = new DemoClient(ipAddressControl.IPAddress, http, tcp);

            MainWindow mainWindow = new MainWindow();
            mainWindow.Configure(demoClient);
            mainWindow.Show();

            Close();
        }

        private void orchestraDefaultsButton_Click(object sender, RoutedEventArgs e)
        {
            httpPort.Value = 41926;
            tcpPort.Value = 41927;
        }

        private void monitravDefaultsButton_Click(object sender, RoutedEventArgs e)
        {
            httpPort.Value = 41916;
            tcpPort.Value = 41917;
        }
    }
}