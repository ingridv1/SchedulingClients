using System;
using System.ServiceModel;
using SchedulingClients.AgentServiceReference;
using System.Collections.Generic;

namespace SchedulingClients
{
    public class AgentClient : AbstractClient<IAgentService>
    {
        private bool isDisposed = false;

        public AgentClient(Uri netTcpUri)
            : base(netTcpUri)
        {
        }

        public IEnumerable<AgentData> GetAllAgentData()
        {
            Logger.Info("TryGetAllAgentData()");

            if (isDisposed)
            {
                throw new ObjectDisposedException("AgentClient");
            }

            ChannelFactory<IAgentService> channelFactory = CreateChannelFactory();
            IAgentService channel = channelFactory.CreateChannel();

            return channel.GetAllAgentData();
        }

        public bool TryGetAllAgentData(out IEnumerable<AgentData> agentDatas)
        {
            Logger.Info("TryGetAllAgentData");

            try
            {
                agentDatas = GetAllAgentData();
                return true;
            }
            catch (Exception ex)
            {
                agentDatas = new AgentData[] { };
                LastCaughtException = ex;
                return false;
            }
        }

        protected override void Dispose(bool isDisposing)
        {
            Logger.Debug("Dispose({0})", isDisposing);

            if (isDisposed)
            {
                return;
            }

            isDisposed = true;

            base.Dispose(isDisposing);
        }
    }
}