using System;
using System.Collections.Generic;
using SchedulingClients.FleetManagerServiceReference;
using System.ServiceModel;
using System.Net;
using UDPCasts;
using GAClients;

namespace SchedulingClients
{
    public class FleetManagerClient : AbstractClient<IFleetManagerService>, IDisposable
    {
        private bool isDisposed = false;

        private readonly int udpPort;

        public int UDPPort { get { return udpPort; } }

        private UDPClient<FleetPoseIPCast> udpClient;

        private Queue<byte[]> buffer = new Queue<byte[]>();

        /// <summary>
        /// Creates a new FleetManagerClient
        /// </summary>
        /// <param name="netTcpUri">net.tcp address of the job builder service</param>
        public FleetManagerClient(Uri netTcpUri, int udpPort)
            : base(netTcpUri)
        {
            this.udpPort = udpPort;
            udpClient = new UDPClient<FleetPoseIPCast>(udpPort, EndpointAddress.ToIPAddress());
            udpClient.Received += ByteArrayUDPClient_Received;
        }

        ~FleetManagerClient()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private FleetPoseIPCast lastCastReceived = null;

        public FleetPoseIPCast LastCastReceived
        {
            get { return lastCastReceived; }
            set
            {
                if (lastCastReceived == null || value.Tick.IsCurrentByteTickLarger(lastCastReceived.Tick))
                {
                    lastCastReceived = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

        private void ByteArrayUDPClient_Received(FleetPoseIPCast fleetPoseIPCast)
        {
            LastCastReceived = fleetPoseIPCast;
        }

        /// <summary>
        /// Requests fleet manager freeze
        /// </summary>
        /// <param name="success">True if frozen</param>
        /// <returns>ServiceOperationResult</returns>
        public ServiceOperationResult TryRequestFreeze(out bool success)
        {
            Logger.Info("TryRequestFreeze()");

            try
            {
                var result = RequestFreeze();
                success = result.Item1;
                return ServiceOperationResultFactory.FromFleetManagertServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                success = false;
                return HandleClientException(ex);
            }
        }

        public ServiceOperationResult TrySubscribeFleetStateCastHeartbeat(out bool success)
        {
            Logger.Info("TrySubscribeFleetStateCastHeartbeat()");

            try
            {
                var result = SubscribeFleetStateCastHeartbeat();
                success = result.Item1;
                return ServiceOperationResultFactory.FromFleetManagertServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                success = false;
                return HandleClientException(ex);
            }
        }

        /// <summary>
        /// Requests fleet manager unfreeze
        /// </summary>
        /// <param name="success">True if unfrozen</param>
        /// <returns>ServiceOperationResult</returns>
        public ServiceOperationResult TryRequestUnfreeze(out bool success)
        {
            Logger.Info("TryRequestUnfreeze()");

            try
            {
                var result = RequestUnfreeze();
                success = result.Item1;
                return ServiceOperationResultFactory.FromFleetManagertServiceCallData(result.Item2);
            }
            catch (Exception ex)
            {
                success = false;
                return HandleClientException(ex);
            }
        }

        private void Dispose(bool isDisposing)
        {
            Logger.Debug("Dispose({0})", isDisposing);

            if (isDisposed)
            {
                return;
            }

            if (isDisposing)
            {
                udpClient.Dispose();
            }

            isDisposed = true;
        }

        private Tuple<bool, ServiceCallData> RequestFreeze()
        {
            Logger.Debug("RequestFreeze()");

            if (isDisposed)
            {
                throw new ObjectDisposedException("FleetManagerClient");
            }

            Tuple<bool, ServiceCallData> result;

            using (ChannelFactory<IFleetManagerService> channelFactory = CreateChannelFactory())
            {
                IFleetManagerService channel = channelFactory.CreateChannel();
                result = channel.RequestFreeze();
                channelFactory.Close();
            }

            return result;
        }

        private Tuple<bool, ServiceCallData> RequestUnfreeze()
        {
            Logger.Debug("RequestUnfreeze()");

            if (isDisposed)
            {
                throw new ObjectDisposedException("FleetManagerClient");
            }

            Tuple<bool, ServiceCallData> result;

            using (ChannelFactory<IFleetManagerService> channelFactory = CreateChannelFactory())
            {
                IFleetManagerService channel = channelFactory.CreateChannel();
                result = channel.RequestUnfreeze();
                channelFactory.Close();
            }

            return result;
        }

        private Tuple<bool, ServiceCallData> SubscribeFleetStateCastHeartbeat()
        { 
            Logger.Debug("SubscribeFleetStateCastHeartbeat()");

            if (isDisposed)
            {
                throw new ObjectDisposedException("FleetManagerClient");
            }

            Tuple<bool, ServiceCallData> result;

            using (ChannelFactory<IFleetManagerService> channelFactory = CreateChannelFactory())
            {
                IFleetManagerService channel = channelFactory.CreateChannel();
                IPAddress ipAddress = EndpointAddress.ToIPAddress();
                result = channel.SubscribeFleetStateCastHeartbeat(ipAddress);
            }

            return result;
        }
    }
}