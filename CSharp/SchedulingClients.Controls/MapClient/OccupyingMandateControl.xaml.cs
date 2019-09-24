using System.Windows.Controls;

namespace SchedulingClients.Controls.MapClient
{
    public partial class OccupyingMandateControl : UserControl
    {
        public OccupyingMandateControl()
        {
            InitializeComponent();
        }

		private void UserControl_DataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
		{
			if (e.NewValue is IMapClient)
			{
				OccupyingMandateWrapper wrapper = FindResource("occupyingMandateWrapper") as OccupyingMandateWrapper;
				wrapper.Configure(e.NewValue as IMapClient);
			}
		}
	}
}
