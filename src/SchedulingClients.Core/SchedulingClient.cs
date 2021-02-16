using BaseClients.Core;
using SchedulingClients.Core.SchedulingServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingClients.Core
{
    public class SchedulingClient : AbstractCallbackClient<ISchedulingService>, ISchedulingClient
    {
        private SchedulingServiceCallback callback = new SchedulingServiceCallback();

        private bool isDisposed = false;

        public SchedulingClient(Uri netTcpUri, TimeSpan heartbeat = default)
            : base(netTcpUri, heartbeat)
        {
        }

        public event Action<SchedulerStateDto> Updated
        {
            add { callback.Updated += value; }
            remove { callback.Updated -= value; }
        }

        protected override void Dispose(bool isDisposing)
        {
            Logger.Debug("Dispose({0})", isDisposing);

            if (isDisposed)
                return;

            isDisposed = true;

            base.Dispose(isDisposing);
        }

        protected override void HandleSubscriptionHeartbeat(ISchedulingService channel, Guid key)
        {
            channel.SubscriptionHeartbeat(key);
        }

        protected override void SetInstanceContext()
        {
            context = new InstanceContext(callback);
        }
    }
}
