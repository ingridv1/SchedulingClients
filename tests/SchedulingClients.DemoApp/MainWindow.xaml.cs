using System.Windows;

namespace SchedulingClients.DemoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            BootStrapper.Activate();

            InitializeComponent();
        }
    }
}