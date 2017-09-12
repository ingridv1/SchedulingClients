﻿using SchedulingClients.JobBuilderServiceReference;
using SchedulingClients.MapServiceReference;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SchedulingClients.UserControls
{
    public partial class JobBuilderClientControl : UserControl
    {
        private MapClient roadmapClient = null;

        public JobBuilderClientControl()
        {
            InitializeComponent();
        }

        public void Configure(MapClient client)
        {
            roadmapClient = client;
        }

        private void createJobButton_Click(object sender, RoutedEventArgs e)
        {
            JobBuilderClient client = DataContext as JobBuilderClient;
            JobData jobData;
            client.TryCreateJob(out jobData);
        }

        private void multiPickJobTest_Click(object sender, RoutedEventArgs e)
        {
            JobBuilderClient client = DataContext as JobBuilderClient;

            if (roadmapClient != null)
            {
                IEnumerable<NodeData> nodeData;
                if (roadmapClient.TryGetAllNodeData(out nodeData) == true)
                {
                    client.MultiPickJobTest(nodeData);
                }
            }
        }
    }
}