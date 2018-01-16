using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingClients
{
    public class ByteArrayUDPClient : UDPClient<ByteArrayCast>
    {
        public ByteArrayUDPClient(int port, IPAddress ipAddress = default(IPAddress))
            : base(port, ipAddress)
        {
        }

        ~ByteArrayUDPClient()
        {
            Dispose(false);
        }

        private void Dispose(bool isDisposing)
        {
            base.Dispose();
        }
    }
}
