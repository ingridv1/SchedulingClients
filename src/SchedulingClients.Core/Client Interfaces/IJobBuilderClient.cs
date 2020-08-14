using BaseClients;
using BaseClients.Architecture;
using GAAPICommon.Architecture;
using GACore.Architecture;
using SchedulingClients.Core.JobBuilderServiceReference;
using System;
using System.Net;

namespace SchedulingClients.Core
{
    public interface IJobBuilderClient : IClient
    {
        IServiceCallResult CommitJob(int jobId, int agentId = -1);

        IServiceCallResult<JobDto> CreateJob();

        IServiceCallResult<int> CreateOrderedListTask(int parentTaskId);

        IServiceCallResult<int> CreateUnorderedListTask(int parentTaskId);

        IServiceCallResult<int> CreateAtomicMoveListTask(int parentTaskId);

        IServiceCallResult<int> CreateServicingTask(int parentListTaskId, int nodeId, ServiceType serviceType, TimeSpan expectedDuration = default);

        IServiceCallResult<int> CreateChargeTask(int parentListTaskId, int nodeId);

        IServiceCallResult<int> CreateSleepingTask(int parentListTaskId, int nodeId, TimeSpan expectedDuration = default);

        IServiceCallResult<int> CreateAtomicMoveTask(int parentAtomicMoveListTaskId, int moveId);

        IServiceCallResult<int> CreateGoToNodeTask(int parentListTaskId, int nodeId);

        IServiceCallResult<int> CreateAwaitingTask(int parentListTaskId, int nodeId);

        IServiceCallResult IssueEnumDirective(int taskId, string parameterAlias, byte value);

        IServiceCallResult IssueShortDirective(int taskId, string parameterAlias, short value);

        IServiceCallResult IssueUShortDirective(int taskId, string parameterAlias, ushort value);

        IServiceCallResult IssueFloatDirective(int taskId, string parameterAlias, float value);

        IServiceCallResult IssueIPAddressDirective(int taskId, string parameterAlias, IPAddress value);

        IServiceCallResult<bool> BeginEditingJob(int jobId);

        IServiceCallResult FinishEditingJob(int jobId);

        IServiceCallResult<bool> BeginEditingTask(int taskId);

        IServiceCallResult FinishEditingTask(int taskId);
    }
}
