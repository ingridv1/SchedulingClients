﻿using System;
using System.Collections.Generic;
using SchedulingClients.AgentBatteryStatusServiceReference;
using System.ServiceModel;
using BaseClients;

namespace SchedulingClients
{
    internal class AgentBatteryStatusClient : AbstractClient<IAgentBatteryStatusService>, IAgentBatteryStatusClient
    {
        private bool isDisposed = false;

        /// <summary>
        /// Creates a new agent battery status client
        /// </summary>
        /// <param name="netTcpUri">net .tcp address of the agent client service</param>
        public AgentBatteryStatusClient(Uri netTcpUri)
            : base(netTcpUri)
        {
        }

        private Tuple<AgentBatteryStatusData[], ServiceCallData> GetAllAgentBatteryStatusData()
        {
            Logger.Debug("GetAllAgentBatteryStatusData()");

            if (isDisposed)
            {
                throw new ObjectDisposedException("AgentBatteryStatusClient");
            }

            Tuple<AgentBatteryStatusData[], ServiceCallData> result;

            using (ChannelFactory<IAgentBatteryStatusService> channelFactory = CreateChannelFactory())
            {
                IAgentBatteryStatusService channel = channelFactory.CreateChannel();
                result = channel.GetAllAgentBatteryStatusData();
                channelFactory.Close();
                Logger.Trace("channelFactory closed");
            }

            return result;
        }

        /// <summary>
        /// Gets all available battery status data on registered agents
        /// </summary>
        /// <param name="agentBatteryStatusDatas"></param>
        /// <returns>ServiceOperationResult</returns>
        public ServiceOperationResult TryGetAllAgentData(out IEnumerable<AgentBatteryStatusData> agentBatteryStatusDatas)
        {
            Logger.Info("TryGetAllAgentBatteryStatusData()");

            try
            {
                var result = GetAllAgentBatteryStatusData();
                agentBatteryStatusDatas = result.Item1;
                return ServiceOperationResultFactory.FromAgentBatteryServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                agentBatteryStatusDatas = new AgentBatteryStatusData[] { };
                return HandleClientException(ex);
            }
        }
    }
}
