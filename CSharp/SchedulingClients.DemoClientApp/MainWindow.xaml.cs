using System.Windows;

namespace SchedulingClients.DemoClientApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HandleShutdown()
        {
            DemoClient demoClient = DataContext as DemoClient;
            demoClient.Dispose();

            Application.Current.Shutdown(0);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            HandleShutdown();
            e.Cancel = true;
        }
    }
}