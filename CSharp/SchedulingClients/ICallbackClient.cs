using System;
using System.ComponentModel;

namespace SchedulingClients
{
    public interface ICallbackClient : IClient, INotifyPropertyChanged
    {
        event Action<DateTime> Connected;

        event Action<DateTime> Disconnected;

        bool IsConnected { get; }

        Guid Key { get; }
    }
}