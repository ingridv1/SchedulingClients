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
            try
            {
                RoadmapClient client = DataContext as RoadmapClient;
                IEnumerable<MoveData> nodeDatas = client.GetAllMoveData();

                moveDataDataGrid.ItemsSource = nodeDatas;
            }
            catch (Exception ex)
            {
            }
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

        private void getTrajectoryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int moveId = (int)trajectoryIdUpDown.Value;
                RoadmapClient client = DataContext as RoadmapClient;
                IEnumerable<WaypointData> waypoints = client.GetTrajectory(moveId);

                TrajectoryDialog dialog = new TrajectoryDialog();
                dialog.DataContext = waypoints;
                dialog.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }

        private void keyCardRefreshButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RoadmapClient client = DataContext as RoadmapClient;
                byte[] keycard = client.GetMappingKeyCardSignature();

                MappingKeyDialog dialog = new MappingKeyDialog();
                dialog.DataContext = keycard.ToHexString();
                dialog.ShowDialog();
            }
            catch (Exception ex)
            {
            }
        }
    }
}