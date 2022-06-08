using Epc.Core.EpcData;
using Epc.Core.EpcEnums;
using Epc.Core.PartitionTable;
using System;

namespace Epc.Core.EpcConverter
{
    public class Sgtin96Converter : IEpcConverter
    {
        public EpcHeader ProtocalHeader => EpcHeader.SGTIN96;

        public Sgtin96 Decode(string HexString)
        {
            //4365 E.2 Decoding an SGTIN-96 to a Serialised Global Trade Item Number (SGTIN)
            var index = 0;

            var epc = new Sgtin96();
            epc.Header = EpcUtility.GetEpcHeader((byte)EpcUtility.BitStringToInt(HexString, index, 8));
            index += 8;
            epc.Filter = EpcUtility.BitStringToInt(HexString, index, 3);
            index += 3;
            epc.Partition = EpcUtility.BitStringToInt(HexString, index, 3);
            index += 3;

            var table = SgtinPartitionTable.GetByPartitionValue(epc.Partition);

            //4376 ■ Note 2: The Partition field of the EPC Binary Encoding contains a code that indicates the
            //4377 number of bits in the GS1 Company Prefix field and the Indicator/Item Reference field. The
            //4378 partition code also determines the number of decimal digits to be used for those fields in the
            //4379 EPC Tag URI (the decimal representation for those two fields is padded on the left with zero
            //4380 characters as necessary). See Section 14.2. (for the SGTIN EPC only).
            epc.GS1CompanyPrefix = EpcUtility.BitStringToIntString(HexString, index, table.GS1CompanyPrefixBits, table.GS1CompanyPrefixDigits);
            index += table.GS1CompanyPrefixBits;
            epc.IndicatorItemRef = EpcUtility.BitStringToIntString(HexString, index, table.ItemReferenceBits, table.ItemReferenceDigits);
            index += table.ItemReferenceBits;
            epc.SerialNumber = EpcUtility.BitStringToInt(HexString, index, 38);

            return epc;

        }

        public Sgtin96 Encode(string epcTagUri)
        {
            if (!epcTagUri.StartsWith("urn:epc:tag:sgtin-96:"))
            {
                throw new ArgumentException("EpcTagUri format error!,It' not sgtin-96");
            }

            epcTagUri = epcTagUri.Replace("urn:epc:tag:sgtin-96:", "");
            var parts = epcTagUri.Split('.');

            var epc = new Sgtin96();
            epc.Header = EpcHeader.SGTIN96;
            epc.Filter = Convert.ToInt32(parts[0]);
            var table = SgtinPartitionTable.GetByGS1CompanyPrefixDigits(parts[1].Length);
            epc.Partition = table.PartitionValue;
            epc.GS1CompanyPrefix = parts[1];
            epc.IndicatorItemRef = parts[2];
            epc.SerialNumber = Convert.ToInt64(parts[3]);

            return epc;
        }
    }
}
