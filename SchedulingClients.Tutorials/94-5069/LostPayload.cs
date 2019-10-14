using NUnit.Framework;
using System.Linq;
using Moq;
using SchedulingClients.AgentAttentionServiceReference;
using System.Threading;
using SchedulingClients.JobStateServiceReference;
using GACore.Architecture;

namespace SchedulingClients.Tutorials._94_5069
{
    [TestFixture]
    [Category("94-5069")]
    public partial class Examples945069
    {
        /// <summary>
        /// This describes how to resolves the lost payload scenario
        /// 
        ///     The agent attention service and job progress data coupled provide enough information
        ///     to determine agent 9 is in trouble.
        ///     
        ///     Checking if 9 has a payload present reveals it has lost the payload.
        ///     
        ///     The job can now be aborted. 
        /// </summary>
        [Test]
        public void LostPayload()
        {
            Mock<IAgentAttentionClient> moqAgentAttention = new Mock<IAgentAttentionClient>();
            IAgentAttentionClient agentAttention = moqAgentAttention.Object;

            Mock<IJobStateClient> moqJobState = new Mock<IJobStateClient>();
            IJobStateClient jobStateClient = moqJobState.Object;

            Mock<IAgentStatecastClient> moqAgentState = new Mock<IAgentStatecastClient>();
            IAgentStatecastClient agentStateCastClient = moqAgentState.Object;

            Mock<IJobsStateClient> moqJobsState = new Mock<IJobsStateClient>();
            IJobsStateClient jobsStateClient = moqJobsState.Object;

            //////////////////
            // Actual Calls //
            //////////////////

            AgentAttentionData[] receivedAttentionData = null;
            ManualResetEvent attentionEventHandled = new ManualResetEvent(false);

            JobProgressData receivedJobProgressData = null;
            ManualResetEvent progressEventHandled = new ManualResetEvent(false);

            agentAttention.AgentAttentionChange += delegate (AgentAttentionData[] obj)
            {
                receivedAttentionData = obj;
                attentionEventHandled.Set();
            };
            
            jobStateClient.JobProgressUpdated += delegate (JobProgressData jobProgressData)
            {
                receivedJobProgressData = jobProgressData;
                progressEventHandled.Set();
            };

            TriggerAgentAttention(moqAgentAttention);
            TriggerJobProgress(moqJobState);

            attentionEventHandled.WaitOne(5000);
            progressEventHandled.WaitOne(5000);
            Assert.IsNotNull(receivedAttentionData);
            Assert.IsNotNull(receivedJobProgressData);

            // So now we have received 2x events:
            //  Agent 9 requires attention
            //  Job progress is under fault

            // Do some validation on state -> perform behvaiour
            if (receivedJobProgressData.JobStatus == JobStatus.Failing)
            {
                if (receivedAttentionData.Any(e => e.AgentId == receivedJobProgressData.AssignedAgentId
                    && e.AttentionType == AttentionType.Comms))
                {
                    int payloadValue;
                    agentStateCastClient.TryGetIntegerStatecastValue(9, "payloadPresent", out payloadValue);

                    if (payloadValue == 3)
                    {
                        bool success;
                        jobsStateClient.TryAbortJob(receivedJobProgressData.JobId, out success);
                    }
                }
            }
        }

        private void TriggerJobProgress(Mock<IJobStateClient> moqJobState)
        {
            moqJobState.Raise(e => e.JobProgressUpdated += null, new JobProgressData()
            {
                JobId = 6,
                JobStatus = JobStatus.InProgress,
                AssignedAgentId = 9
            });
        }

        private void TriggerAgentAttention(Mock<IAgentAttentionClient> moqAgentAttention)
        {
            AgentAttentionData[] dataSet = new AgentAttentionData[]
            {
                new AgentAttentionData()
                {
                    AgentId = 9,
                    AttentionType = AttentionType.Comms                   
                }
            };

            moqAgentAttention.Raise(e => e.AgentAttentionChange += null, dataSet);
        }

    }
}
