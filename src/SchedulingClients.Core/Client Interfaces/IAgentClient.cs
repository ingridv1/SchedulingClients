﻿using BaseClients.Architecture;
using GAAPICommon.Architecture;
using GACore.Architecture;
using SchedulingClients.Core.AgentServiceReference;

namespace SchedulingClients.Core
{
    public interface IAgentClient : IClient
	{
		IServiceCallResult<AgentDto[]> GetAllAgentData();

        IServiceCallResult<AgentDto[]> GetAllAgentsInLifetimeState(AgentLifetimeState agentLifetimeState);

        IServiceCallResult SetAgentLifetimeState(int agentId, AgentLifetimeState desiredState);
    }
}