using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingClients
{
    [Serializable]
    public class ByteArrayCast : AbstractCast
    {
        private readonly byte[][] byteArray;

        private List<byte[]> byteList = new List<byte[]>();

        public ByteArrayCast(byte tick, byte[][] byteArray)
            : base(tick)
        {
            this.byteArray = byteArray;
        }

        public byte[][] ByteArray { get { return byteArray; } }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            ByteArrayCast other = obj as ByteArrayCast;
            if ((System.Object)other == null)
            {
                return false;
            }

            return (Tick == other.Tick) && byteArray.SequenceEqual(byteArray);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
