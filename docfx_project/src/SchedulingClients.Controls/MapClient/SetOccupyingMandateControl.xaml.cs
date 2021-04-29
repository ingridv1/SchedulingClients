using System;
using System.Collections.Generic;
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
using System.Linq;
using SchedulingClients.Client_Interfaces;
using BaseClients;
using SchedulingClients.MapServiceReference;
using MoreLinq;

namespace SchedulingClients.Controls.MapClient
{
    /// <summary>
    /// Interaction logic for SetOccupyingMandateControl.xaml
    /// </summary>
    public partial class SetOccupyingMandateControl : UserControl
    {
        public SetOccupyingMandateControl()
        {
            InitializeComponent();
        }

        private void SetButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IMapClient client = DataContext as IMapClient;

                TimeSpan timeout = timeSpanUpDown.Value ?? TimeSpan.Zero;

                ServiceOperationResult result = client.TrySetOccupyingMandate(MoreEnumerable.ToHashSet(MapItemIds), timeout);

                if (!result.IsSuccessfull) result.ShowMessageBox();
            }
            catch (Exception ex)
            {
            }
        }

        public static readonly DependencyProperty MapItemIdsProperty =
            DependencyProperty.Register
            (
                "MapItemIds",
                typeof(HashSet<int>),
                typeof(SetOccupyingMandateControl)
                ,new PropertyMetadata(new HashSet<int>())
            );

        public HashSet<int> MapItemIds
        {
            get { return (HashSet<int>)GetValue(MapItemIdsProperty); }
            set { SetValue(MapItemIdsProperty, value); }
        }

        private void PopulateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HashSet<int> mapItemIds = new HashSet<int>();
                IMapClient mapClient = DataContext as IMapClient;

                mapClient.TryGetAllNodeData(out IEnumerable<NodeData> nodeData);
                mapClient.TryGetAllMoveData(out IEnumerable<MoveData> moveData);

                getAllNodeDataControl.GetSelectedNodeData().ForEach(n => mapItemIds.Add(n.MapItemId));
                getAllMoveDataControl.GetSelectedMoveData().ForEach(m => mapItemIds.Add(m.Id));

                MapItemIds = mapItemIds;
            }
            catch (Exception ex)
            {
            }
        }
    }
}
