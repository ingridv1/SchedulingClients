using System.Windows;
using System.Windows.Controls;

namespace SchedulingClients.UserControls
{
    public class LabelContentControl : ContentControl
    {
        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(string),
            typeof(LabelContentControl), new PropertyMetadata(HeaderChanged));

        public LabelContentControl()
        {
        }

        public string Header { get; set; }

        private static void HeaderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((LabelContentControl)d).Header = e.NewValue as string;
        }
    }
}