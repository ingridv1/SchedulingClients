using SchedulingClients.MapServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using NLog;
using BaseClients;
using BaseClients.Core;
using MoreLinq;
using GAAPICommon.Architecture;
using GAAPICommon.Core.Dtos;
using GAAPICommon.Core;

namespace SchedulingClients
{
    internal class MapClient : AbstractCallbackClient<IMapService>, IMapClient
    {
        private bool isDisposed = false;

        private MapServiceCallback callback = new MapServiceCallback();

        public static TimeSpan MinimumHeartbeat => TimeSpan.FromMilliseconds(10000);

        /// <summary>
        /// Creates a new MapClient
        /// </summary>
        /// <param name="netTcpUri">net.tcp address of the map service</param>
        public MapClient(Uri netTcpUri, TimeSpan heartbeat = default)
                    : base(netTcpUri)
        {
            Heartbeat = heartbeat < MinimumHeartbeat 
                ? MinimumHeartbeat 
                : heartbeat;

            callback.OccupyingMandateProgressChange += Callback_OccupyingMandateProgressChange;
        }

        private OccupyingMandateProgressDto occupyingMandateProgressDto = null;

        /// <summary>
        /// The current state of progress of the occupying mandate
        /// </summary>
        public OccupyingMandateProgressDto OccupyingMandateProgressDto
        {
            get { return occupyingMandateProgressDto; }

            private set
            {
                if (occupyingMandateProgressDto != value)
                {
                    occupyingMandateProgressDto = value;
                    OnProgressUpdated(occupyingMandateProgressDto);
                }
            }
        }
        
        public event Action<OccupyingMandateProgressDto> OccupyingMandateProgressUpdated;


        private void OnProgressUpdated(OccupyingMandateProgressDto occupyingMandateProgressDto)
        {
            Action<OccupyingMandateProgressDto> handlers = OccupyingMandateProgressUpdated;

            handlers?
               .GetInvocationList()
               .Cast<Action<OccupyingMandateProgressDto>>()
               .ForEach(e => e.BeginInvoke(occupyingMandateProgressDto, null, null));
        }

        private void Callback_OccupyingMandateProgressChange(OccupyingMandateProgressDto newProgressData)
        {
            OccupyingMandateProgressDto = newProgressData;
        }

        protected override void SetInstanceContext()
        {
            context = new InstanceContext(callback);
        }

        /// <summary>
        /// Gets all move data
        /// </summary>
        /// <param name="moveData">All moves in the roadmap</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult<MoveDto[]> GetAllMoveData()
        {
            Logger.Trace("GetAllMoveData()");

            try
            {
                using (ChannelFactory<IMapService> channelFactory = CreateChannelFactory())
                {
                    IMapService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto<MoveDto[]> result = channel.GetAllMoveData();
                    channelFactory.Close();

                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ServiceCallResultFactory<MoveDto[]>.FromClientException(ex);
            }
        }

        /// <summary>
        /// Gets all node data
        /// </summary>
        /// <param name="nodeData">All nodes in the roadmap</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult<NodeDto[]> GetAllNodeData()
        {
            Logger.Trace("GetAllNodeData()");

            try
            {
                using (ChannelFactory<IMapService> channelFactory = CreateChannelFactory())
                {
                    IMapService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto<NodeDto[]> result = channel.GetAllNodeData();
                    channelFactory.Close();

                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ServiceCallResultFactory<NodeDto[]>.FromClientException(ex);
            }
        }

        /// <summary>
        /// Hearbeat time
        /// </summary>
        public TimeSpan Heartbeat { get; private set; }

        protected override void HeartbeatThread()
        {
            Logger.Trace("HeartbeatThread()");

            ChannelFactory<IMapService> channelFactory = CreateChannelFactory();
            IMapService channel = channelFactory.CreateChannel();

            bool? exceptionCaught;

            while (!Terminate)
            {
                exceptionCaught = null;

                try
                {
                    Logger.Trace("SubscriptionHeartbeat({0})", Key);
                    channel.SubscriptionHeartbeat(Key);
                    IsConnected = true;
                    exceptionCaught = false;
                }
                catch (EndpointNotFoundException)
                {
                    Logger.Warn("HeartbeatThread - EndpointNotFoundException. Is the server running?");
                    exceptionCaught = true;
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                    exceptionCaught = true;
                }

                if (exceptionCaught == true)
                {
                    channelFactory.Abort();
                    IsConnected = false;

                    channelFactory = CreateChannelFactory(); // Create a new channel as this one is dead
                    channel = channelFactory.CreateChannel();
                }

                heartbeatReset.WaitOne(Heartbeat);
            }

            Logger.Trace("HeartbeatThread exit");
        }

        /// <summary>
        /// Gets all parameter data
        /// </summary>
        /// <param name="parameterData">All parameters in the map</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult<ParameterDto[]> GetAllParameterData()
        {
            Logger.Trace("GetAllParameterData()");

            try
            {
                using (ChannelFactory<IMapService> channelFactory = CreateChannelFactory())
                {
                    IMapService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto<ParameterDto[]> result = channel.GetAllParameterData();
                    channelFactory.Close();

                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ServiceCallResultFactory<ParameterDto[]>.FromClientException(ex);
            }
        }

        /// <summary>
        /// Gets the trajectory of a specific move
        /// </summary>
        /// <param name="moveId">Id of the move</param>
        /// <param name="waypointData">Waypoints for this move</param>
        /// <returns>ServiceOperationResult</returns>
        public IServiceCallResult<WaypointDto[]> GetTrajectory(int moveId)
        {
            Logger.Trace("GetTrajectory({0})",moveId);

            try
            {
                using (ChannelFactory<IMapService> channelFactory = CreateChannelFactory())
                {
                    IMapService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto<WaypointDto[]> result = channel.GetTrajectory(moveId);
                    channelFactory.Close();

                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ServiceCallResultFactory<WaypointDto[]>.FromClientException(ex);
            }
        }

        public IServiceCallResult<OccupyingMandateProgressDto> GetOccupyingMandateProgressData()
        {
            Logger.Trace("GetOccupyingMandateProgressData()");

            try
            {
                using (ChannelFactory<IMapService> channelFactory = CreateChannelFactory())
                {
                    IMapService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto<OccupyingMandateProgressDto> result = channel.GetOccupyingMandateProgressData();
                    channelFactory.Close();

                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ServiceCallResultFactory<OccupyingMandateProgressDto>.FromClientException(ex);
            }
        }

        /// <summary>
        /// Attempts to remotely occupy an area of the map
        /// </summary>
        /// <param name="mapItemIds">Map Items to occupy off</param>
        /// <param name="timeout">Length of time to wait before abandoning the occupation attempt</param>
        /// <returns></returns>
        public IServiceCallResult SetOccupyingMandate(HashSet<int> mapItemIds, TimeSpan timeout)
        {
            Logger.Trace("SetOccupyingMandate()");

            try
            {
                using (ChannelFactory<IMapService> channelFactory = CreateChannelFactory())
                {
                    IMapService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto result = channel.SetOccupyingMandate(mapItemIds.ToArray(), timeout);
                    channelFactory.Close();

                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ServiceCallResultFactory.FromClientException(ex);
            }
        }

        /// <summary>
        /// Clears a previously occupied area of the map
        /// </summary>
        public IServiceCallResult ClearOccupyingMandate()
        {
            Logger.Info("ClearOccupyingMandate()");

            try
            {
                using (ChannelFactory<IMapService> channelFactory = CreateChannelFactory())
                {
                    IMapService channel = channelFactory.CreateChannel();
                    ServiceCallResultDto result = channel.ClearOccupyingMandate();
                    channelFactory.Close();

                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return ServiceCallResultFactory.FromClientException(ex);
            }
        }

        protected override void Dispose(bool isDisposing)
        {
            Logger.Debug("Dispose({0})", isDisposing);

            if (isDisposed) 
                return;

            callback.OccupyingMandateProgressChange -= Callback_OccupyingMandateProgressChange;

			isDisposed = true;

			base.Dispose(isDisposing);
		}
    }
}