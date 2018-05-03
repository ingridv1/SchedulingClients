using SchedulingClients.MapServiceReference;
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

namespace SchedulingClients.UserControls
{
    /// <summary>
    /// Interaction logic for MapClientBlockingMandatesControl.xaml
    /// </summary>
    public partial class MapClientBlockingMandatesControl : UserControl
    {
        public MapClientBlockingMandatesControl()
        {
            InitializeComponent();
        }

        private void registerBlockingMandateButton_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<int> mapItemIds = nodeDataDataGrid.SelectedItems.Cast<NodeData>().Select(n => n.MapItemId).Union(moveDataDataGrid.SelectedItems.Cast<MoveData>().Select(m => m.Id));
            int mandateId = mandateIdUpDown.Value ?? -1;

            MapClient client = DataContext as MapClient;

            bool success = false;

            client.TryRegisterBlockingMandate(mapItemIds, mandateId, 20000, out success);

            if (success)
            {
                MessageBox.Show("Blocking mandate registration successful");
            }
            else
            {
                MessageBox.Show("Blocking mandate registration failed");
            }
        }

        private void clearBlockingMandateButton_Click(object sender, RoutedEventArgs e)
        {
            int mandateId = mandateIdUpDown.Value ?? -1;

            MapClient client = DataContext as MapClient;

            client.TryClearBlockingMandate(mandateId);
        }

        private void getMapDataButton_Click(object sender, RoutedEventArgs e)
        {
            MapClient client = DataContext as MapClient;

            IEnumerable<NodeData> nodeDatas;
            client.TryGetAllNodeData(out nodeDatas);

            nodeDataDataGrid.ItemsSource = nodeDatas;

            IEnumerable<MoveData> moveDatas;
            client.TryGetAllMoveData(out moveDatas);

            moveDataDataGrid.ItemsSource = moveDatas;
        }
    }
}
