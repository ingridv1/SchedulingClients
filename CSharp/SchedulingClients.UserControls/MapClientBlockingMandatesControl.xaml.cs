using BaseClients;
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
            HashSet<int> mapItemIds = new HashSet<int>();
            
            foreach(int id in nodeDataDataGrid.SelectedItems.Cast<NodeData>().Select(n => n.MapItemId).Union(moveDataDataGrid.SelectedItems.Cast<MoveData>().Select(m => m.Id)))
            {
                mapItemIds.Add(id);
            }

            int mandateId = mandateIdUpDown.Value ?? -1;

            IMapClient client = DataContext as IMapClient;

            ServiceOperationResult serviceOperationResult = client.TrySetOccupyingMandate(mapItemIds, TimeSpan.FromMilliseconds(20000));

            if (serviceOperationResult.IsSuccessfull)
            {
                MessageBox.Show("Occupying mandate registration successful");
            }
            else
            {
                MessageBox.Show("Occupying mandate registration failed");
            }
        }

        private void clearBlockingMandateButton_Click(object sender, RoutedEventArgs e)
        {
            int mandateId = mandateIdUpDown.Value ?? -1;

            IMapClient client = DataContext as IMapClient;

            client.TryClearOccupyingMandate();
        }

        private void getMapDataButton_Click(object sender, RoutedEventArgs e)
        {
            IMapClient client = DataContext as IMapClient;

            IEnumerable<NodeData> nodeDatas;
            client.TryGetAllNodeData(out nodeDatas);

            nodeDataDataGrid.ItemsSource = nodeDatas;

            IEnumerable<MoveData> moveDatas;
            client.TryGetAllMoveData(out moveDatas);

            moveDataDataGrid.ItemsSource = moveDatas;
        }
    }
}
