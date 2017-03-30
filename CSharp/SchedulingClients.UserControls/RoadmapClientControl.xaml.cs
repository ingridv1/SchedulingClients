using SchedulingClients.RoadmapServiceReference;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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