using FluentAssertions;
using Xunit;

namespace Dgt.BaseConverter
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(12, 3, 4, 0)]
        [InlineData(12, 4, 3, 0)]
        [InlineData(12, 5, 2, 2)]
        [InlineData(17, 10, 1, 7)]
        [InlineData(17, 20, 0, 17)]
        public void Divide_Should_ReturnTupleOfQuotientAndRemainder
            (int dividend, int divisor, int expectedQuotient, int expectedRemainder) =>
            Calculator.Divide(dividend, divisor).Should().Be((expectedQuotient, expectedRemainder));
    }
}