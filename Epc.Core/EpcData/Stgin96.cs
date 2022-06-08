using Epc.Core.EpcEnums;
using Epc.Core.PartitionTable;
using System;
using System.Text;

namespace Epc.Core.EpcData
{
    public class Sgtin96 : IEpcData
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

        public string ToHexString()
        {
            var hexString = new StringBuilder(12 * 2);
            var bitString = ToBitString();
            for (int i = 0; i < bitString.Length; i += 8)
            {
                hexString.Append(Convert.ToByte(bitString.Substring(i, 8), 2).ToString("X2"));
            }

            return hexString.ToString();
        }

        public string ToBitString()
        {
            var bitString = new StringBuilder(96);
            bitString.Append(EpcUtility.IntToBitString((int)Header, 8));
            bitString.Append(EpcUtility.IntToBitString(Filter, 3));
            bitString.Append(EpcUtility.IntToBitString(Partition, 3));

            var table = SgtinPartitionTable.GetByPartitionValue(Partition);
            bitString.Append(EpcUtility.IntStringToBitString(GS1CompanyPrefix, table.GS1CompanyPrefixBits));
            bitString.Append(EpcUtility.IntStringToBitString(IndicatorItemRef, table.ItemReferenceBits));
            bitString.Append(EpcUtility.LongToBitString(SerialNumber, 38));

            return bitString.ToString();
        }
    }
}
