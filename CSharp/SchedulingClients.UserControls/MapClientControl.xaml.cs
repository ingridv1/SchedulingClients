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
using SchedulingClients.RoadmapServiceReference;
using NLog;

namespace SchedulingClients.UserControls
{
    public partial class MapClientControl : UserControl
    {
        private Logger logger = LogManager.CreateNullLogger();

        public MapClientControl()
        {
            InitializeComponent();
        }

        public Logger Logger
        {
            get { return logger; }

            set
            {
                if (logger != value)
                {
                    logger = value;
                }
            }
        }

        private void getAllNodeDataButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RoadmapClient client = DataContext as RoadmapClient;
                IEnumerable<NodeData> nodeDatas = client.GetAllNodeData();

                foreach (NodeData nodeData in nodeDatas.ToList())
                {
                    logger.Info("[MapClientControl] {0}", nodeData.ToNodeDataString());
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
    }
}