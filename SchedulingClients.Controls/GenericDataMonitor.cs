using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using GACore;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace SchedulingClients.Controls
{
	public abstract class GenericDataMonitor<T> : INotifyPropertyChanged
	{
		protected ObservableCollection<T> mailboxes = new ObservableCollection<T>();

		protected readonly object lockObject = new object();

		private ReadOnlyObservableCollection<T> readonlyMailboxes;

		public GenericDataMonitor()
		{
			readonlyMailboxes = new ReadOnlyObservableCollection<T>(mailboxes);

			BindingOperations.EnableCollectionSynchronization(Mailboxes, lockObject);
		}

		public ReadOnlyObservableCollection<T> Mailboxes => readonlyMailboxes;

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnNotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
