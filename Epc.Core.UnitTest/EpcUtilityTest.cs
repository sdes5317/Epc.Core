namespace Epc.Core.UnitTest
{
    public class EpcUtilityTest
    {
        [Fact]
        public void BytesToBitsStringTest()
        {
            Assert.Equal("0001001000110100", EpcUtility.BytesToBitsString(new byte[] { 0x12, 0x34 }));
            Assert.Equal("00110000001110010110000001100010", EpcUtility.BytesToBitsString(new byte[] { 0x30, 0x39, 0x60, 0x62 }));
        }

        [Fact]
        public void ByteStringToBitsStringTest()
        {
            Assert.Equal("1010101111001101", EpcUtility.BytesToBitsString("ABCD"));
        }

        [Fact]
        public void DecodeIntStringTest()
        {
            Assert.Equal("1", EpcUtility.DecodeIntString("00000000000000000000000000000001", 0, 32, 0));
            Assert.Equal("-2147483648", EpcUtility.DecodeIntString("10000000000000000000000000000000", 0, 32, 0));

            Assert.Equal("360841", EpcUtility.DecodeIntString("01011000000110001001", 0, 20, 6));
            Assert.Equal("0940136", EpcUtility.DecodeIntString("000011100101100001101000", 0, 24, 7));
        }

        [Fact]
        public void DecodeLongStringTest()
        {
            Assert.Equal(1, EpcUtility.DecodeLong("0000000000000000000000000000000000000000000000000000000000000001", 0, 64));
            Assert.Equal(-9223372036854775808, EpcUtility.DecodeLong("1000000000000000000000000000000000000000000000000000000000000000", 0, 64));

            Assert.Equal(9200732059, EpcUtility.DecodeLong("00001000100100011010000000011110011011", 0, 38));
        }

        [Fact]
        public void CheckSumTest()
        {
            Assert.Equal("3", EpcUtility.GS1CheckSum("0360841940136"));
            Assert.Equal("8", EpcUtility.GS1CheckSum("8061414112345"));
            Assert.Equal("0", EpcUtility.GS1CheckSum("4242424244444"));
        }
    }
}