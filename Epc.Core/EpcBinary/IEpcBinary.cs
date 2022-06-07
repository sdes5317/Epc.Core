using Epc.Core.EpcEnums;

namespace Epc.Core.EpcBinary
{
    public interface IEpcBinary
    {
        EpcHeader Header { get; set; }
    }
}