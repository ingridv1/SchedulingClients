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

				OccupyingMandateWrapper wrapper = FindResource("occupyingMandateWrapper") as OccupyingMandateWrapper;

				Rect rect = boundingBoxControl.ToRect();

				int[] nodeIds = wrapper.NodeDataSet.Within(rect).Select(e2 => e2.MapItemId).ToArray();
				int[] moveIds = wrapper.MoveDataSet.Within(wrapper.NodeDataSet, rect).Select(m => m.Id).ToArray();

				int[] ids = new int[nodeIds.Length + moveIds.Length];
				nodeIds.CopyTo(ids, 0);
				moveIds.CopyTo(ids, nodeIds.Length);

				ServiceOperationResult result = client.TrySetOccupyingMandate(MoreEnumerable.ToHashSet(ids), timeout);

                if (!result.IsSuccessfull) result.ShowMessageBox();
            }
            catch (Exception ex)
            {
            }
        }
			   		 
		private void UserControl_DataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
		{
			if (e.NewValue is IMapClient)
			{
				OccupyingMandateWrapper wrapper = FindResource("occupyingMandateWrapper") as OccupyingMandateWrapper;
				wrapper.Configure(e.NewValue as IMapClient);
			}
		}

		private void BoundingBoxControl_BoundingBoxUpdated(object sender, RectRoutedEventArgs e)
		{
#warning TODO Update the node and move data controls here
		}
	}
}
