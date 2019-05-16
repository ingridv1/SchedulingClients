using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BaseClients;
using SchedulingClients.MapServiceReference;

namespace SchedulingClients.Controls.MapClient
{
    /// <summary>
    /// Interaction logic for GetAllNodeDataControl.xaml
    /// </summary>
    public partial class GetAllNodeDataControl : UserControl
    {
        public GetAllNodeDataControl()
        {
            InitializeComponent();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IMapClient client = DataContext as IMapClient;

                IEnumerable<NodeData> nodeData;
                ServiceOperationResult result = client.TryGetAllNodeData(out nodeData);

                dataGrid.ItemsSource = nodeData;
            }
            catch(Exception ex)
            {

            }
        }

        public IEnumerable<NodeData> GetSelectedNodeData()
        {
            try
            {
                return dataGrid.SelectedItems.Cast<NodeData>();
            }
            catch(Exception ex)
            {
                return Enumerable.Empty<NodeData>();
            }
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            refreshButton.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }
    }
}
