using SchedulingClients.FleetManagerServiceReference;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SchedulingClients.UserControls
{
    internal class KingpinStateMailbox : INotifyPropertyChanged
    {
        private KingpinState kingpinState;

        public event PropertyChangedEventHandler PropertyChanged;

        public KingpinStateMailbox(KingpinState kingpinState)
        {
            this.kingpinState = kingpinState;
        }

        public void Update(KingpinState kingpinState)
        {
            this.kingpinState = kingpinState;
            OnNotifyPropertyChanged("KingpinState");
        }

        public KingpinState KingpinState
        {
            get { return kingpinState; }
        }

        public override bool Equals(object obj)
        {
            KingpinStateMailbox other = obj as KingpinStateMailbox;

            if (other == null)
            {
                return false;
            }

            return this.kingpinState.IPAddress.Equals(other.kingpinState.IPAddress);
        }

        public override int GetHashCode()
        {
            return kingpinState.IPAddress.GetHashCode();
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
