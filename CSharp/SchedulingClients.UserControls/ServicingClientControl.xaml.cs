using System.Windows.Controls;
using NLog;
using System.Threading;
using SchedulingClients;
using System.Collections.ObjectModel;
using SchedulingClients.ServicingServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SchedulingClients.RoadmapServiceReference;

using NLog;

namespace SchedulingClients.UserControls
{
    /// <summary>
    /// Interaction logic for ServicingClientControl.xaml
    /// </summary>
    public partial class ServicingClientControl : UserControl
    {
        private Logger logger = LogManager.CreateNullLogger();

        private ObservableCollection<ServiceStateData> recentData = new ObservableCollection<ServiceStateData>();

        public ServicingClientControl()
        {
            InitializeComponent();
            recentServiceStateDataGrid.DataContext = recentData;
        }

        public Logger Logger
        {
            get { return logger; }

            set
            {
                if (logger != value)
                {
                    logger = value;
                }
            }
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