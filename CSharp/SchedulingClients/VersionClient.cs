using GAClients;
using SchedulingClients.VersionServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingClients
{
    public class VersionClient : AbstractClient<IVersionService>
    {
        private bool isDisposed = false;

        public VersionClient(Uri netTcpUri)
            : base(netTcpUri)
        {
        }

        public ServiceOperationResult TryGetSchedulerVersion(out SemVerData schedulerVersionData)
        {
            Logger.Info("TryGetSchedulerVersion()");

            try
            {
                var result = GetSchedulerVersion();
                schedulerVersionData = result.Item1;
                return ServiceOperationResultFactory.FromVersionServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                schedulerVersionData = null;
                return HandleClientException(ex);
            }
        }

        public ServiceOperationResult TryGetPluginVersions(out IEnumerable<PluginData> pluginVersionDatas)
        {
            Logger.Info("TryGetPluginVersions()");

            try
            {
                var result = GetPluginVersions();
                pluginVersionDatas = result.Item1.ToList();
                return ServiceOperationResultFactory.FromVersionServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                pluginVersionDatas = null;
                return HandleClientException(ex);
            }
        }

        private Tuple<SemVerData, ServiceCallData> GetSchedulerVersion()
        {
            Logger.Debug("GetSchedulerVersion()");

            if (isDisposed)
            {
                throw new ObjectDisposedException("VersionClient");
            }

            Tuple<SemVerData, ServiceCallData> result;

            using (ChannelFactory<IVersionService> channelFactory = CreateChannelFactory())
            {
                IVersionService channel = channelFactory.CreateChannel();
                result = channel.GetSchedulerVersion();
                channelFactory.Close();
                Logger.Trace("channelFactory closed");
            }

            return result;
        }

        private Tuple<PluginData[], ServiceCallData> GetPluginVersions()
        {
            Logger.Debug("GetPluginVersions()");

            if (isDisposed)
            {
                throw new ObjectDisposedException("VersionClient");
            }

            Tuple<PluginData[], ServiceCallData> result;

            using (ChannelFactory<IVersionService> channelFactory = CreateChannelFactory())
            {
                IVersionService channel = channelFactory.CreateChannel();
                result = channel.GetPluginVersions();
                channelFactory.Close();
                Logger.Trace("channelFactory closed");
            }

            return result;
        }
    }
}
