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

        private void getAllMoveDataButton_Click(object sender, RoutedEventArgs e)
        {
            RoadmapClient client = DataContext as RoadmapClient;
            IEnumerable<MoveData> nodeDatas;
            client.TryGetAllMoveData(out nodeDatas);

            moveDataDataGrid.ItemsSource = nodeDatas;
        }

        private void getAllNodeDataButton_Click(object sender, RoutedEventArgs e)
        {
            RoadmapClient client = DataContext as RoadmapClient;
            IEnumerable<NodeData> nodeDatas;
            client.TryGetAllNodeData(out nodeDatas);

            nodeDataDataGrid.ItemsSource = nodeDatas;
        }

        private void getTrajectoryButton_Click(object sender, RoutedEventArgs e)
        {
            int moveId = (int)trajectoryIdUpDown.Value;
            RoadmapClient client = DataContext as RoadmapClient;
            IEnumerable<WaypointData> waypoints;
            client.TryGetTrajectory(moveId, out waypoints);

            TrajectoryDialog dialog = new TrajectoryDialog();
            dialog.DataContext = waypoints;
            dialog.ShowDialog();
        }

        private void keyCardRefreshButton_Click(object sender, RoutedEventArgs e)
        {
            RoadmapClient client = DataContext as RoadmapClient;
            byte[] keycard;
            client.TryGetMappingKeyCardSignature(out keycard);

            MappingKeyDialog dialog = new MappingKeyDialog();
            dialog.DataContext = keycard.ToHexString();
            dialog.ShowDialog();
        }
    }
}