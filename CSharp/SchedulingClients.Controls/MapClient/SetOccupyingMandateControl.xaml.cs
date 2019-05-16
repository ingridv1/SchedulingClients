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
using BaseClients;
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

                HashSet<int> hash = new HashSet<int>();

                ServiceOperationResult result = client.TrySetOccupyingMandate(hash, timeout);
            }
            catch (Exception ex)
            {
            }
        }

        private void PopulateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HashSet<int> mapItemIds = new HashSet<int>();

                getAllNodeDataControl.GetSelectedNodeData().ForEach(n => mapItemIds.Add(n.MapItemId));
                getAllMoveDataControl.GetSelectedMoveData().ForEach(m => mapItemIds.Add(m.Id));
            }
            catch (Exception ex)
            {
            }
        }
    }
}
