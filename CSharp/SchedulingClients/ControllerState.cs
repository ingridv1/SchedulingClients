using System;
using System.Linq;
using System.Net;

namespace SchedulingClients
{
    public struct ControllerState
    {
        private readonly double x;

        private readonly double y;

        private readonly double heading;

        private readonly IPAddress ipAddress;

        public ControllerState(byte[] bytes)
        {
            
            if (bytes.Length != 22)
            {
                throw new ArgumentOutOfRangeException("bytes");
            }

            ipAddress = new IPAddress(bytes.Take(4).ToArray());

            int xmm = BitConverter.ToInt32(bytes, 4);   
            int ymm = BitConverter.ToInt32(bytes, 8);

            x = (xmm == int.MinValue) ? double.NaN : ((double)xmm) / 100.0;
            y = (ymm == int.MinValue) ? double.NaN : ((double)ymm) / 100.0;

            int headingDeg = BitConverter.ToInt16(bytes, 12);

            if (headingDeg == short.MinValue)
            {
                heading = double.NaN;
            }
            else
            {
                double scaledback = ((double)headingDeg) / 100.0;
                heading = scaledback.DegToRad();
            }    

        }

        public double X { get { return x; } }

        public double Y { get { return y; } }

        public double Heading { get { return heading; } }

        public IPAddress IPAddress { get { return ipAddress; } }
    }
}
