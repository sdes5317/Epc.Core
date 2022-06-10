using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epc.Core.PartitionTable
{
    /// <summary>
    /// protocal bits length and padding length(Digits)
    /// </summary>
    internal class SgtinPartitionTable
    {
        public int PartitionValue { get; set; }
        public int GS1CompanyPrefixBits { get; set; }
        public int GS1CompanyPrefixDigits { get; set; }
        public int ItemReferenceBits { get; set; }
        public int ItemReferenceDigits { get; set; }
        public int Serial { get; set; } = 38;

        public static SgtinPartitionTable GetByPartitionValue(int partitionValue)
        {
            return _tablePartitionValue
                .TryGetValue(partitionValue, out var table) ? table : throw new ArgumentException($"Wrong format! PartitionValue:{partitionValue}");
        }
        public static SgtinPartitionTable GetByGS1CompanyPrefixDigits(int GS1CompanyPrefixDigits)
        {
            return _tableGS1CompanyPrefixDigits
                .TryGetValue(GS1CompanyPrefixDigits, out var table) ? table : throw new ArgumentException($"Wrong format! GS1CompanyPrefixDigits:{GS1CompanyPrefixDigits}");
        }

        private static Dictionary<int, SgtinPartitionTable> _tablePartitionValue = GetTables().ToDictionary(t => t.PartitionValue);
        private static Dictionary<int, SgtinPartitionTable> _tableGS1CompanyPrefixDigits = GetTables().ToDictionary(t => t.GS1CompanyPrefixDigits);

        private static IEnumerable<SgtinPartitionTable> GetTables()
        {
            yield return new SgtinPartitionTable()
            {
                PartitionValue = 0,
                GS1CompanyPrefixBits = 40,
                GS1CompanyPrefixDigits = 12,
                ItemReferenceBits = 4,
                ItemReferenceDigits = 1,
                Serial = 4
            };
            yield return new SgtinPartitionTable()
            {
                PartitionValue = 1,
                GS1CompanyPrefixBits = 37,
                GS1CompanyPrefixDigits = 11,
                ItemReferenceBits = 7,
                ItemReferenceDigits = 2,
                Serial = 7
            };
            yield return new SgtinPartitionTable()
            {
                PartitionValue = 2,
                GS1CompanyPrefixBits = 34,
                GS1CompanyPrefixDigits = 10,
                ItemReferenceBits = 10,
                ItemReferenceDigits = 3,
                Serial = 10
            };
            yield return new SgtinPartitionTable()
            {
                PartitionValue = 3,
                GS1CompanyPrefixBits = 30,
                GS1CompanyPrefixDigits = 9,
                ItemReferenceBits = 14,
                ItemReferenceDigits = 4,
                Serial = 14
            };
            yield return new SgtinPartitionTable()
            {
                PartitionValue = 4,
                GS1CompanyPrefixBits = 27,
                GS1CompanyPrefixDigits = 8,
                ItemReferenceBits = 17,
                ItemReferenceDigits = 5,
                Serial = 17
            };
            yield return new SgtinPartitionTable()
            {
                PartitionValue = 5,
                GS1CompanyPrefixBits = 24,
                GS1CompanyPrefixDigits = 7,
                ItemReferenceBits = 20,
                ItemReferenceDigits = 6,
                Serial = 20
            };
            yield return new SgtinPartitionTable()
            {
                PartitionValue = 6,
                GS1CompanyPrefixBits = 20,
                GS1CompanyPrefixDigits = 6,
                ItemReferenceBits = 24,
                ItemReferenceDigits = 7,
                Serial = 24
            };
        }
    }
}
