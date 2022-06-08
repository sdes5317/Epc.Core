using Epc.Core.EpcConverter;

namespace Epc.Core.UnitTest
{
    public class Stgin96Test
    {
        private Sgtin96Converter _sgtin96 = new Sgtin96Converter();

        [Fact]
        public void Sgtin96DecodeTest()
        {
            var bitString = EpcUtility.BytesToBitsString("3074257BF7194E4000001A85");

            var sgtin96Epc = _sgtin96.Decode(bitString);

            Assert.Equal("urn:epc:tag:sgtin-96:3.0614141.812345.6789", sgtin96Epc.ToEpcTagUri());

            Assert.Equal("urn:epc:id:sgtin:0614141.812345.6789", sgtin96Epc.ToEpcPureIdentityUri());

            Assert.Equal("(01)80614141123458(21)6789", sgtin96Epc.ToGS1ElementString());
        }

        [Fact]
        public void Sgtin96EncodeTest()
        {
            var epcTagUri = "urn:epc:tag:sgtin-96:3.0614141.812345.6789";

            var sgtin96Epc = _sgtin96.Encode(epcTagUri);

            Assert.Equal("(01)80614141123458(21)6789", sgtin96Epc.ToGS1ElementString());

            Assert.Equal(epcTagUri, sgtin96Epc.ToEpcTagUri());

            Assert.Equal("urn:epc:id:sgtin:0614141.812345.6789", sgtin96Epc.ToEpcPureIdentityUri());

            Assert.Equal("3074257BF7194E4000001A85", sgtin96Epc.ToHexString());
        }
    }
}