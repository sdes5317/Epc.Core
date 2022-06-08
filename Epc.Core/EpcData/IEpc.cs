using Epc.Core.EpcEnums;

namespace Epc.Core.EpcData
{
    public interface IEpcData
    {
        EpcHeader Header { get; set; }
    }
}