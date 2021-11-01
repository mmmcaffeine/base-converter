using FluentAssertions;
using Xunit;

namespace Dgt.BaseConverter
{
    public class ConvertTests
    {
        [Fact]
        public void ToBinary_Should_ConvertDecimalToBooleanArray()
        {
            Convert.ToBinary(0).Should().BeEquivalentTo(new[] { false });
        }
    }
}