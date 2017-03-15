using System;
using System.ComponentModel;
using System.ServiceModel;
using System.Runtime.CompilerServices;
using NLog;

namespace SchedulingClients
{
    public abstract class AbstractClient<T> : IClient
    {
        protected ChannelFactory<T> channelFactory;

        private readonly EndpointAddress endpointAddress;

        private bool isDisposed = false;

        private Exception lastCaughtException = null;

        private Logger logger = LogManager.CreateNullLogger();

        public AbstractClient(Uri netTcpUri)
        {
            this.endpointAddress = new EndpointAddress(netTcpUri);

            NetTcpBinding binding = new NetTcpBinding(SecurityMode.None) { PortSharingEnabled = true };
            this.channelFactory = new ChannelFactory<T>(binding, endpointAddress);
        }

        ~AbstractClient()
        {
            Dispose(false);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public EndpointAddress EndpointAddress { get { return endpointAddress; } }

        /// <summary>
        /// Last caught exception handled by the client
        /// </summary>
        public Exception LastCaughtException
        {
            get { return lastCaughtException; }

            protected set
            {
                if (lastCaughtException != value)
                {
                    lastCaughtException = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

        public Logger Logger
        {
            get { return logger; }
            set { logger = value; }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposed)
            {
                return;
            }

            channelFactory.Close();

            isDisposed = true;
        }

        protected void OnNotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChangedEventHandler handlers = PropertyChanged;
            if (handlers != null)
            {
                foreach (PropertyChangedEventHandler handler in handlers.GetInvocationList())
                {
                    handler.BeginInvoke(this, new PropertyChangedEventArgs(propertyName), null, null);
                }
            }
        }
    }
}