using FluentAssertions;
using Xunit;

namespace Dgt.BaseConverter
{
    public class ConvertTests
    {
        public static TheoryData<string, int> HexToDecimalTestData => new()
        {
            { "0", 0 },
            { "9", 9 },
            { "A", 10 },
            { "F", 15 },
            { "10", 16 },
            { "FF", 255 },
            { "ABCDEF", 11259375 }
        };

        [Theory]
        [MemberData(nameof(HexToDecimalTestData))]
        public void HexToDecimal_Should_Convert_HexNumberToDecimalNumber(string hexNumber, int decimalNumber) =>
            Convert.HexToDecimal(hexNumber).Should().Be(decimalNumber);

        [Theory]
        [MemberData(nameof(HexToDecimalTestData))]
        public void DecimalToHex_Should_ConvertDecimalNumberToHexNumber(string hexNumber, int decimalNumber) =>
            Convert.DecimalToHex(decimalNumber).Should().Be(hexNumber);
    }
}