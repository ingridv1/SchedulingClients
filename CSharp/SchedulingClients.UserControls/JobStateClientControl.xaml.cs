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
using SchedulingClients;
using SchedulingClients.JobStateServiceReference;
using System.Windows.Shapes;

namespace SchedulingClients.UserControls
{
    /// <summary>
    /// Interaction logic for JobStateClientControl.xaml
    /// </summary>
    public partial class JobStateClientControl : UserControl
    {
        public JobStateClientControl()
        {
            InitializeComponent();
        }

        private void getJobStateButton_Click(object sender, RoutedEventArgs e)
        {
            JobStateData jobStateData;

            JobStateClient jobStateClient = DataContext as JobStateClient;
            if (jobStateClient.TryGetJobState((int)getJobStateId.Value, out jobStateData) == true)
            {
                jobStateDataControl.DataContext = jobStateData;
            }
        }
    }
}