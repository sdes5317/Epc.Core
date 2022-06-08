using Epc.Core.EpcEnums;

namespace Epc.Core.EpcBinary
{
    public interface IEpc
    {
        EpcHeader Header { get; set; }
    }
}