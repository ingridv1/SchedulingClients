﻿using SchedulingClients.MapServiceReference;
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

namespace SchedulingClients.Controls.MapClient
{
    /// <summary>
    /// Interaction logic for GetOccupyingMandateProgressDataControl.xaml
    /// </summary>
    public partial class GetOccupyingMandateProgressDataControl : UserControl
    {
        public GetOccupyingMandateProgressDataControl()
        {
            InitializeComponent();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IMapClient mapClient = DataContext as IMapClient;
                OccupyingMandateProgressData data;

                if (mapClient.TryGetOccupyingMandateProgressData(out data).IsSuccessfull) occupyingMandateProgressDataControl.DataContext = data;
            }
            catch (Exception ex)
            {
            }
        }
    }
}
