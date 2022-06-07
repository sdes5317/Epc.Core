using Epc.Core.EpcBinary;
using Epc.Core.EpcEnums;
using System.IO;

namespace Epc.Core.EpcDecoder
{
    public interface IEpc
    {
        EpcHeader ProtocalHeader { get; }
    }
}