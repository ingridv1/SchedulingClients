using SchedulingClients.ServicingServiceReference;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace SchedulingClients.UserControls
{
    public partial class ServicingClientControl : UserControl, IDisposable
    {
        private ObservableCollection<ServiceStateData> recentData = new ObservableCollection<ServiceStateData>();

        public ServicingClientControl()
        {
            InitializeComponent();
            recentServiceStateDataGrid.DataContext = recentData;

            AutoServicer autoServicer = TryFindResource("autoServicer") as AutoServicer;
            if (autoServicer != null)
            {
                autoServicer.Serviced += AutoServicer_Serviced;
            }
        }

        public void Dispose()
        {
            AutoServicer autoServicer = TryFindResource("autoServicer") as AutoServicer;
            if (autoServicer != null)
            {
                autoServicer.Serviced -= AutoServicer_Serviced;
                autoServicer.Dispose();
            }
        }

        private void AutoServicer_Serviced(int taskId)
        {
            HandleService(taskId);
        }

        private void Client_ServiceRequest(ServiceStateData serviceStateData)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                recentData.Add(serviceStateData);

                AutoServicer autoServicer = TryFindResource("autoServicer") as AutoServicer;
                if (autoServicer != null)
                {
                    autoServicer.AddService(serviceStateData.TaskId);
                }
            }));
        }

        private void completeButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            int taskId = (int)serviceIdUpDown.Value;
            HandleService(taskId);
        }

        private void HandleService(int taskId)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                bool success;
                ServicingClient client = DataContext as ServicingClient;
                client.TrySetServiceComplete(taskId, out success);

                if (success)
                {
                    ServiceStateData data = recentData.FirstOrDefault(elem => elem.TaskId == taskId);
                    recentData.Remove(data);
                }
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