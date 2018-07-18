using GAClients;
using SchedulingClients.VersionServiceReference;
using System.Collections.Generic;

namespace SchedulingClients
{
	public interface IVersionClient : IClient
	{
    ServiceOperationResult TryGetSchedulerVersion(out SemVerData schedulerVersionData);

		ServiceOperationResult TryGetPluginVersions(out IEnumerable<PluginData> pluginVersionData);
	}
}
