using Epc.Core.EpcEnums;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Epc.Core.Extension
{
    internal static class BinaryExtension
    {
        public static string ToEpcHeader(this EpcHeader header)
        {
            return EpcUtility.GetEpcHeaderDescription(header.ToString());
        }
    }
}
