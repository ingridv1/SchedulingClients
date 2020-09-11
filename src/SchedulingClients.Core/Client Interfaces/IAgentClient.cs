using BaseClients.Architecture;
using GAAPICommon.Architecture;
using SchedulingClients.Core.AgentServiceReference;

namespace SchedulingClients.Core
{
    /// <summary>
    /// For monitoring and manipulating the state of agents in the system.
    /// </summary>
    public interface IAgentClient : IClient
    {
        /// <summary>
        /// Gets all agents known to the scheduler. 
        /// </summary>
        /// <returns>Array of agent dtos</returns>
        IServiceCallResult<AgentDto[]> GetAllAgents();

        /// <summary>
        /// Gets all agents known to the scheduler in a given lifetime state.
        /// </summary>
        /// <param name="agentLifetimeState">Target lifetime state</param>
        /// <returns>Array of agent dtos</returns>
        IServiceCallResult<AgentDto[]> GetAllAgentsInLifetimeState(AgentLifetimeState agentLifetimeState);

        /// <summary>
        /// Sets the lifetime state of an agent.
        /// </summary>
        /// <param name="agentId">Target agent Id</param>
        /// <param name="desiredState">Target state</param>
        /// <returns>Successful service call result on success</returns>
        IServiceCallResult SetAgentLifetimeState(int agentId, AgentLifetimeState desiredState);
    }
}