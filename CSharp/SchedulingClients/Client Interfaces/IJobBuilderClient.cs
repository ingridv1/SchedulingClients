using BaseClients;
using SchedulingClients.JobBuilderServiceReference;
using System;
using System.Net;

namespace SchedulingClients
{
    public interface IJobBuilderClient : IClient
    {
        ServiceOperationResult TryCommit(int jobId, out bool success, int agentId = -1);

        ServiceOperationResult TryCreateJob(out JobData jobData);

        ServiceOperationResult TryCreateOrderedListTask(int parentTaskId, out int listTaskId);

        ServiceOperationResult TryCreateUnorderedListTask(int parentTaskId, out int listTaskId);

        ServiceOperationResult TryCreateAtomicMoveListTask(int parentTaskId, out int listTaskId);

        ServiceOperationResult TryCreateServicingTask(int parentListTaskId, int nodeId, ServiceType serviceType, out int serviceTaskId, TimeSpan expectedDuration = default(TimeSpan));

		ServiceOperationResult TryCreateChargeTask(int parentListTaskId, int nodeId, out int chargeTaskId);

        ServiceOperationResult TryCreateSleepingTask(int parentListTaskId, int nodeId, out int sleepingTaskId, TimeSpan expectedDuration = default(TimeSpan));

        ServiceOperationResult TryCreateAtomicMoveTask(int parentAtomicMoveListTaskId, int moveId, out int atomicMoveTaskId);

        ServiceOperationResult TryCreateGoToNodeTask(int parentListTaskId, int nodeId, out int goToNodeTaskId);

        ServiceOperationResult TryCreateAwaitingTask(int parentListTaskId, int nodeId, out int awaitTaskId);

        ServiceOperationResult TryIssueDirective(int taskId, string parameterAlias, byte value);

        ServiceOperationResult TryIssueDirective(int taskId, string parameterAlias, short value);

        ServiceOperationResult TryIssueDirective(int taskId, string parameterAlias, ushort value);

        ServiceOperationResult TryIssueDirective(int taskId, string parameterAlias, float value);

        ServiceOperationResult TryIssueDirective(int taskId, string parameterAlias, IPAddress value);

        ServiceOperationResult TryBeginEditingJob(int jobId);

        ServiceOperationResult TryFinishEditingJob(int jobId);

        ServiceOperationResult TryBeginEditingTask(int taskId);

        ServiceOperationResult TryFinishEditingTask(int taskId);
    }
}
