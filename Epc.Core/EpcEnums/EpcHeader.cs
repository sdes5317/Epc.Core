using System;
using System.ComponentModel;

namespace Epc.Core.EpcEnums
{
    /// <summary>
    /// Table 14-1 EPC Binary Header Values
    /// todo implement all
    /// </summary>
    public enum EpcHeader : byte
    {
        [Description("GDTI-96")]
        GDTI96 = 0b_0010_1100,//44
        [Description("GSRN-96")]
        GSRN96 = 0b_0010_1101,//45
        [Description("GSRNP")]
        GSRNP = 0b_0010_1110,
        [Description("USDoD-96")]
        USDoD96 = 0b_0010_1111,
        [Description("SGTIN-96")]
        SGTIN96 = 0b_0011_0000,
        [Description("SSCC-96")]
        SSCC96 = 0b_0011_0001,
        [Description("SGLN-96")]
        SGLN96 = 0b_0011_0010,
        [Description("GRAI-96")]
        GRAI96 = 0b_0011_0011,
    }
}
