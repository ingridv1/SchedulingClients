using System.Windows;

namespace SchedulingClients.UserControls
{
    /// <summary>
    /// Interaction logic for TrajectoryDialog.xaml
    /// </summary>
    public partial class TrajectoryDialog : Window
    {
        public TrajectoryDialog()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}