using SchedulingClients.FleetManagerServiceReference;
using System.Windows.Controls;

namespace SchedulingClients.UserControls
{
    public partial class PoseControl : UserControl
    {
        public PoseControl()
        {
            InitializeComponent();
        }

        public PoseData Pose
        {
            get
            {
                return FindResource("pose") as PoseData;
            }
        }
    }
}