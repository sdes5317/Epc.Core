using Epc.Core.EpcDecoder;

namespace Epc.Core.UnitTest
{
    public class Stgin96Test
    {
        private Sgtin96 _sgtin96 = new Sgtin96();

        [Fact]
        public void Stgin96DecodeTest()
        {
            var bitString = EpcUtility.BytesToBitsString("3074257BF7194E4000001A85");

            Assert.Equal("urn:epc:tag:sgtin-96:3.0614141.812345.6789", _sgtin96.Decode(bitString).ToEpcTagUri());

            Assert.Equal("urn:epc:id:sgtin:0614141.812345.6789", _sgtin96.Decode(bitString).ToEpcPureIdentityUri());

            Assert.Equal("(01)80614141123458(21)6789", _sgtin96.Decode(bitString).ToGS1ElementString());
        }

        [Fact]
        public void Sgtin96EncodeTest()
        {
            var epcTagUri = "urn:epc:tag:sgtin-96:3.0614141.812345.6789";

            Assert.Equal("(01)80614141123458(21)6789", _sgtin96.Encode(epcTagUri).ToGS1ElementString());

            Assert.Equal(epcTagUri, _sgtin96.Encode(epcTagUri).ToEpcTagUri());

            Assert.Equal("urn:epc:id:sgtin:0614141.812345.6789", _sgtin96.Encode(epcTagUri).ToEpcPureIdentityUri());
        }
    }
}