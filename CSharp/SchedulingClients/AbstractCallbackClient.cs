﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Threading;
using NLog;

namespace SchedulingClients
{
    public abstract class AbstractCallbackClient<T> : ICallbackClient
    {
        protected InstanceContext context;

        protected AutoResetEvent heartbeatReset = new AutoResetEvent(false);

        private readonly Guid key = Guid.NewGuid();

        private NetTcpBinding Binding = new NetTcpBinding(SecurityMode.None)
        {
            PortSharingEnabled = true
        };

        private EndpointAddress endpointAddress;

        private Thread hearbeatThread;

        private bool isConnected = false;

        private bool isDisposed = false;

        private Exception lastCaughtException = null;

        private Logger logger = LogManager.CreateNullLogger();

        private bool terminate = false;

        public AbstractCallbackClient(Uri netTcpUri)
        {
            this.endpointAddress = new EndpointAddress(netTcpUri);

            SetInstanceContext();

            hearbeatThread = new Thread(new ThreadStart(HeartbeatThread));
            hearbeatThread.Start();
        }

        ~AbstractCallbackClient()
        {
            Dispose(false);
        }

        public event Action<DateTime> Connected;

        public event Action<DateTime> Disconnected;

        public event PropertyChangedEventHandler PropertyChanged;

        public EndpointAddress EndpointAddress { get { return endpointAddress; } }

        public bool IsConnected
        {
            get { return isConnected; }

            protected set
            {
                if (isConnected != value)
                {
                    isConnected = value;
                    OnNotifyPropertyChanged();

                    if (value)
                    {
                        OnConnected(DateTime.Now);
                    }
                    else
                    {
                        OnDisconnected(DateTime.Now);
                    }
                }
            }
        }

        public Guid Key { get { return key; } }

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

        protected bool Terminate { get { return terminate; } }

        public void Dispose()
        {
            Dispose(true);
        }

        protected DuplexChannelFactory<T> CreateChannelFactory()
        {
            return new DuplexChannelFactory<T>(context, Binding, EndpointAddress);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposed)
            {
                return;
            }

            terminate = true;
            heartbeatReset.Set();
            hearbeatThread.Join();

            isDisposed = true;
        }

        protected abstract void HeartbeatThread();

        protected abstract void SetInstanceContext();

        private void OnConnected(DateTime dateTime)
        {
            Action<DateTime> handlers = Connected;
            if (handlers != null)
            {
                foreach (Action<DateTime> handler in handlers.GetInvocationList())
                {
                    handler.BeginInvoke(dateTime, null, null);
                }
            }
        }

        private void OnDisconnected(DateTime dateTime)
        {
            Action<DateTime> handlers = Disconnected;
            if (handlers != null)
            {
                foreach (Action<DateTime> handler in handlers.GetInvocationList())
                {
                    handler.BeginInvoke(dateTime, null, null);
                }
            }
        }

        private void OnNotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}