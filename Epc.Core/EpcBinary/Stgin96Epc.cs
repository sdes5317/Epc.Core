using Epc.Core.EpcEnums;
using Epc.Core.Extension;

namespace Epc.Core.EpcBinary
{
    public class Sgtin96Epc : IEpcBinary
    {
        public EpcHeader Header { get; set; }
        public int Filter { get; set; }
        public int Partition { get; set; }
        public string GS1CompanyPrefix { get; set; }
        public string IndicatorItemRef { get; set; }
        public long SerialNumber { get; set; }

        public string ToEpcTagUri()
        {
            return $"urn:epc:tag:sgtin-96:{Filter}.{GS1CompanyPrefix}.{IndicatorItemRef}.{SerialNumber}";
        }
        public string ToEpcPureIdentityUri()
        {
            return $"urn:epc:id:sgtin:{GS1CompanyPrefix}.{IndicatorItemRef}.{SerialNumber}";
        }
        public string ToGS1ElementString()
        {
            var gtin13String = $"{IndicatorItemRef[0]}{GS1CompanyPrefix}{IndicatorItemRef.Substring(1, IndicatorItemRef.Length - 1)}";
            return $"(01){gtin13String}{EpcUtility.GS1CheckSum(gtin13String)}(21){SerialNumber}";
        }
    }
}
