using Epc.Core.EpcBinary;
using Epc.Core.EpcEnums;
using System.IO;

namespace Epc.Core.EpcConverter
{
    public interface IEpcConverter
    {
        EpcHeader ProtocalHeader { get; }
    }
}