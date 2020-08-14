using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using SchedulingClients.MapServiceReference;
using MoreLinq;
using BaseClients;

namespace SchedulingClients
{
	/*
	public class OccupyingMandateWrapper
	{
		private IMapClient mapClient = null;

		private readonly object lockObject = new object();

		private readonly ObservableCollection<MoveDto> moveDataSet = new ObservableCollection<MoveDto>();

		private readonly ObservableCollection<NodeDto> nodeDataSet = new ObservableCollection<NodeDto>();

		private readonly ReadOnlyObservableCollection<MoveDto> readonlyMoveDataSet;

		private readonly ReadOnlyObservableCollection<NodeDto> readonlyNodeDataSet;

		public OccupyingMandateWrapper()
		{
			readonlyMoveDataSet = new ReadOnlyObservableCollection<MoveDto>(moveDataSet);
			readonlyNodeDataSet = new ReadOnlyObservableCollection<NodeDto>(nodeDataSet);
		}

		public void Configure(IMapClient mapClient)
		{
			lock (lockObject)
			{
				this.mapClient = mapClient;
			}

			RefreshDataSets(out ServiceOperationResult result);
		}

		public ReadOnlyObservableCollection<NodeDto> NodeDataSet => readonlyNodeDataSet;

		public ReadOnlyObservableCollection<MoveDto> MoveDataSet => readonlyMoveDataSet;

		public bool RefreshDataSets(out ServiceOperationResult result)
		{
			if (mapClient == null) throw new InvalidOperationException("map client is not configured");

			lock (lockObject)
			{
				lock (nodeDataSet)
				{
					nodeDataSet.Clear();
					result = mapClient.TryGetAllNodeData(out IEnumerable<NodeData> nodeDatas);

					nodeDatas.ForEach(e => nodeDataSet.Add(e));

					if (!result.IsSuccessfull) return false;
				}

				lock (moveDataSet)
				{
					moveDataSet.Clear();
					result = mapClient.TryGetAllMoveData(out IEnumerable<MoveData> moveDatas);

					moveDatas.ForEach(e => moveDataSet.Add(e));

					if (!result.IsSuccessfull) return false;
				}

				result = default(ServiceOperationResult);

				return true;
			}
		}
	}*/
}
