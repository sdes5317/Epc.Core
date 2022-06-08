using Epc.Core.EpcEnums;

namespace Epc.Core.EpcConverter
{
    public interface IEpcConverter
    {
        EpcHeader ProtocalHeader { get; }
    }
}