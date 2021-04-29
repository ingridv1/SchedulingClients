using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace SchedulingClients.UserControls
{
    public class AutoServicer : INotifyPropertyChanged, IDisposable
    {
        private Thread autoServiceThread;

        private bool isDisposed = false;

        private bool isEnabled = false;

        private Dictionary<int, DateTime> services = new Dictionary<int, DateTime>();

        private bool terminate = false;

        public AutoServicer()
        {
            autoServiceThread = new Thread(new ThreadStart(AutoServiceThread));
            autoServiceThread.Start();
        }

        ~AutoServicer()
        {
            Dispose(false);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public event Action<int> Serviced;

        public bool IsEnabled
        {
            get { return isEnabled; }

            set
            {
                if (isEnabled != value)
                {
                    isEnabled = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

        public void AddService(int taskId, TimeSpan duration = default(TimeSpan))
        {
            if (duration == default(TimeSpan))
            {
                duration = TimeSpan.FromSeconds(5);
            }

            DateTime serviceTime = DateTime.Now.Add(duration);

            lock (services)
            {
                if (services.ContainsKey(taskId))
                {
                    services[taskId] = serviceTime;
                }
                else
                {
                    services.Add(taskId, serviceTime);
                }
            }
        }

        public void AutoServiceThread()
        {
            while (!terminate)
            {
                lock (services)
                {
                    foreach (int taskId in services.Where(e => e.Value < DateTime.Now).Select(elem => elem.Key).ToList())
                    {
                        services.Remove(taskId);
                        if (IsEnabled)
                        {
                            OnServiced(taskId);
                        }
                    }
                }

                Thread.Sleep(1000);
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected void Dispose(bool isDisposing)
        {
            if (isDisposed)
            {
                return;
            }

            terminate = true;
            autoServiceThread.Join();

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

        private void OnServiced(int taskId)
        {
            Action<int> handlers = Serviced;
            if (handlers != null)
            {
                foreach (Action<int> handler in handlers.GetInvocationList())
                {
                    handler.BeginInvoke(taskId, null, null);
                }
            }
        }
    }
}