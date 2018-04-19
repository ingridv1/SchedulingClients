using SchedulingClients.MapServiceReference;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SchedulingClients.UserControls
{
    public partial class MapClientControl : UserControl
    {
        public MapClientControl()
        {
            InitializeComponent();
        }

        private void getAllMoveDataButton_Click(object sender, RoutedEventArgs e)
        {
            MapClient client = DataContext as MapClient;
            IEnumerable<MoveData> nodeDatas;
            client.TryGetAllMoveData(out nodeDatas);

            moveDataDataGrid.ItemsSource = nodeDatas;
        }

        private void getAllNodeDataButton_Click(object sender, RoutedEventArgs e)
        {
            MapClient client = DataContext as MapClient;
            IEnumerable<NodeData> nodeDatas;
            client.TryGetAllNodeData(out nodeDatas);

            nodeDataDataGrid.ItemsSource = nodeDatas;
        }

        private void getTrajectoryButton_Click(object sender, RoutedEventArgs e)
        {
            int moveId = (int)trajectoryIdUpDown.Value;
            MapClient client = DataContext as MapClient;
            IEnumerable<WaypointData> waypoints;
            client.TryGetTrajectory(moveId, out waypoints);

            TrajectoryDialog dialog = new TrajectoryDialog();
            dialog.DataContext = waypoints;
            dialog.ShowDialog();
        }

        private void getAllParameterDataButton_Click(object sender, RoutedEventArgs e)
        {
            MapClient client = DataContext as MapClient;
            IEnumerable<ParameterData> parameterDatas;
            client.TryGetAllParameterData(out parameterDatas);

            parameterDataDataGrid.ItemsSource = parameterDatas;
        }
    }
}