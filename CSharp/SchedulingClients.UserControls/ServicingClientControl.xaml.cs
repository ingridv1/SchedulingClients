using SchedulingClients.ServicingServiceReference;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace SchedulingClients.UserControls
{
    /// <summary>
    /// Interaction logic for ServicingClientControl.xaml
    /// </summary>
    public partial class ServicingClientControl : UserControl
    {
        private ObservableCollection<ServiceStateData> recentData = new ObservableCollection<ServiceStateData>();

        public ServicingClientControl()
        {
            InitializeComponent();
            recentServiceStateDataGrid.DataContext = recentData;
        }

        private void Client_ServiceRequest(ServiceStateData serviceStateData)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                recentData.Add(serviceStateData);
            }));
        }

        private void UserControl_DataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is ServicingClient)
            {
                ServicingClient client = e.NewValue as ServicingClient;
                client.ServiceRequest += Client_ServiceRequest;
            }
        }
    }
}