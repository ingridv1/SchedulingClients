using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BaseClients;

namespace SchedulingClients.Controls
{
    public static class ExtensionMethods
    {
        public static void ShowMessageBox(this ServiceOperationResult result)
        {
            if (result.IsSuccessfull) MessageBox.Show("Service operation is successfull", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                MessageBox.Show(result.ServiceString, "Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
