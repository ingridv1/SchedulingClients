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
using System.Windows.Shapes;
using SchedulingClients.RoadmapServiceReference;
using NLog;

namespace SchedulingClients.UserControls
{
    public partial class RoadmapClientControl : UserControl
    {
        public RoadmapClientControl()
        {
            InitializeComponent();
        }

        private void getAllNodeDataButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RoadmapClient client = DataContext as RoadmapClient;
                IEnumerable<NodeData> nodeDatas = client.GetAllNodeData();

                nodeDataDataGrid.ItemsSource = nodeDatas;
            }
            catch (Exception ex)
            {
            }
        }
    }
}