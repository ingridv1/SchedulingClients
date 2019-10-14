using System.Windows;
using System.Diagnostics;

namespace SchedulingClients.DemoClientApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Configure(DemoClient demoClient)
        {
            DataContext = demoClient;
            jobBuilderClientControl.Configure(demoClient.RoadmapClient);
            spammerControl.Configure(demoClient.RoadmapClient);
        }

        private void HandleShutdown()
        {
            DemoClient demoClient = DataContext as DemoClient;
            demoClient.Dispose();

            servicingClientControl.Dispose();

            Application.Current.Shutdown(0);
        }

        private void logsFolderMenuItem_Click(object sender, RoutedEventArgs e)
        {
            DemoClient demoClient = DataContext as DemoClient;
            Process.Start(demoClient.LogFolderPath);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            HandleShutdown();
            e.Cancel = true;
        }
    }
}