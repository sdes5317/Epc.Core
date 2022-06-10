using Epc.Core.EpcEnums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Epc.Core
{
    public class EpcUtility
    {
        private static Dictionary<string, string> headers = InitialHeaderDictionary();


        private static Dictionary<string, string> InitialHeaderDictionary()
        {
            return typeof(EpcHeader)
                .GetFields()
                .Where(f => f.GetCustomAttributes(false).Length > 0)
                .ToDictionary(f => f.Name, f => ((DescriptionAttribute)f.GetCustomAttributes(typeof(DescriptionAttribute), false).Single()).Description);
        }

        public static string GetEpcHeaderDescription(string headerName)
        {
            headers = InitialHeaderDictionary();
            return headers[headerName];
        }

        public static EpcHeader GetEpcHeader(byte byt)
        {
            var name = Enum.GetName(typeof(EpcHeader), byt);
            if (name is null) throw new ArgumentException($"Wrong format! epc header:{byt}");
            return (EpcHeader)Enum.Parse(typeof(EpcHeader), name);
        }

        public static string HexToBitString(string hexString)
        {
            var bytes = new byte[hexString.Length / 2];
            for (int i = 0; i < hexString.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            }

            return BytesToBitsString(bytes);
        }

        public static string BytesToBitsString(byte[] bytes)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(Convert.ToString(bytes[i], 2).PadLeft(8, '0'));
            }

            return builder.ToString();
        }

        public static int BitStringToInt(string bitString, int startIndex, int length)
        {
            return Convert.ToInt32(bitString.Substring(startIndex, length), 2);
        }
        public static string BitStringToIntString(string bitString, int startIndex, int length, int padding)
        {
            return BitStringToInt(bitString, startIndex, length).ToString().PadLeft(padding, '0');
        }
        public static long BitStringToLong(string bitString, int startIndex, int length)
        {
            return Convert.ToInt64(bitString.Substring(startIndex, length), 2);
        }

        public static string GS1CheckSum(string gs1NoSum)
        {
            gs1NoSum = gs1NoSum.PadLeft(13, '0');
            var sum = 0;
            for (int i = 0; i < 13; i++)
            {
                sum += i % 2 == 0 ?
                (gs1NoSum[i] - '0') * 3 ://odd
                (gs1NoSum[i] - '0') * 1; //even

            }

            var crc = 10 - (sum % 10);
            //mod 10 twice, for case: 10 % 10 = 0
            crc = crc % 10;

            return crc.ToString();
        }

        internal static string LongToBitString(long value, int padding)
        {
            return Convert.ToString(value, 2).PadLeft(padding, '0');
        }
        internal static string IntToBitString(int value, int padding)
        {
            return Convert.ToString(value, 2).PadLeft(padding, '0');
        }
        internal static string IntStringToBitString(string value, int padding)
        {
            return IntToBitString(int.Parse(value), padding);
        }
    }
}
