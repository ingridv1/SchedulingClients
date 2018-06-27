using Moq;
using NUnit.Framework;
using SchedulingClients.AgentServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAClients;

namespace SchedulingClients.Test
{
	[TestFixture]
	class TAgentClient
	{
		public bool VerifyAgents(IEnumerable<AgentData> agents)
		{
			if (agents.Any())
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		[Test]
		public void CanGetAgentData()
		{
			//arrange
			//Custom Data
			AgentData agentData = new AgentData();
			List<AgentData> agentDatas = new List<AgentData>();
			agentDatas.Add(agentData);
			IEnumerable<AgentData> returnedAgentData = agentDatas as IEnumerable<AgentData>;
			ServiceOperationResult result = new ServiceOperationResult(0, "Success", null, null);
			//Mock
			Mock<IAgentClient> mock = new Mock<IAgentClient>();
			mock.Setup(e => e.TryGetAllAgentData(out returnedAgentData)).Returns(result);

			//act
			IEnumerable<AgentData> myAgentData;
			ServiceOperationResult opResult = mock.Object.TryGetAllAgentData(out myAgentData);
			bool finalResult = VerifyAgents(myAgentData);

			//assert
			Assert.That(opResult.ClientException == null && opResult.ServiceException == null && finalResult);
		}
	}
}
