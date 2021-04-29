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

namespace SchedulingClients.Controls.MapClient
{
    public partial class ClearOccupyingMandateControl : UserControl
    {
        public ClearOccupyingMandateControl()
        {
            InitializeComponent();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IMapClient mapClient = DataContext as IMapClient;
                ServiceOperationResult result = mapClient.TryClearOccupyingMandate();

                if (result.IsSuccessfull) MessageBox.Show("Occupying mandate succesfully cleared", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                {
                    string content = string.Format("Failed to clear occupying mandate");

                    MessageBox.Show(content, "Failure", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
