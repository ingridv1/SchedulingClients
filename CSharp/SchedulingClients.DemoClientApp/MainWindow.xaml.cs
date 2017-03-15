using System;
using System.Windows;
using System.Net;
using SchedulingClients;
using GATools.Logging;
using NLog;

namespace SchedulingClients.DemoClientApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DemoClient demoClient = (DemoClient)FindResource("demoClient");

            GALogManager.BaseDir = @"C:\temp";
            GALogManager.SetTrace();
            Logger logger = GALogManager.GetLogger("SchedulingClients.UserControls");

            jobBuilderClientControl.Logger = logger;
            mapClientControl.Logger = logger;
            servicingClientControl.Logger = logger;

            ConfigureClient();
        }

        private void ConfigureClient()
        {
            DemoClient demoClient = FindResource("demoClient") as DemoClient;

            EndpointSettings endpointSettings = new EndpointSettings(IPAddress.Loopback);
            demoClient.Configure(endpointSettings);

            if (demoClient != null)
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    jobBuilderClientControl.DataContext = demoClient.JobBuilderClient;
                    mapClientControl.DataContext = demoClient.MapClient;
                    servicingClientControl.DataContext = demoClient.ServicingClient;
                }));
            }
        }

        private void HandleShutdown()
        {
            DemoClient demoClient = FindResource("demoClient") as DemoClient;
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