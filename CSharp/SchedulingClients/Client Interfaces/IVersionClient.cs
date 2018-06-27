using GAClients;
using SchedulingClients.VersionServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingClients
{
	public interface IVersionClient
	{
		ServiceOperationResult TryGetSchedulerVersion(out SemVerData schedulerVersionData);

		ServiceOperationResult TryGetPluginVersions(out IEnumerable<PluginData> pluginVersionData);
	}
}
