using SchedulingClients.JobBuilderServiceReference;
using System;
using System.Windows;
using System.Windows.Controls;
using NLog;

namespace SchedulingClients.UserControls
{
    public partial class JobBuilderClientControl : UserControl
    {
        private Logger logger = LogManager.CreateNullLogger();

        public JobBuilderClientControl()
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

        private void createJobButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                JobBuilderClient client = DataContext as JobBuilderClient;
                JobData jobData = client.CreateJob();

                logger.Info("[JobBuilderClientControl] {0}", jobData.ToJobDataString());
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        private void multiPickJobTest_Click(object sender, RoutedEventArgs e)
        {
            JobBuilderClient client = DataContext as JobBuilderClient;
            client.MultiPickJobTest();
        }
    }
}