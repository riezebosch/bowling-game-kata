using System;
using Xunit;

namespace Tests
{
    public class StrikeBonusTests
    {
        [Theory]
        [InlineData(-1, 0)]
        [InlineData(11, 0)]
        [InlineData(0, -1)]
        [InlineData(0, 11)]
        public void StrikeBonusBoundaries(int pins1, int pins2)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new StrikeBonus(pins1, pins2));
        }

        [Fact]
        public void FirstRoll10Pins()
        {
            Assert.Equal(10, new StrikeBonus(10, 0).FirstRoll);
        }

        [Fact]
        public void SecondRoll10Pins()
        {
            Assert.Equal(10, new StrikeBonus(0, 10).NextRoll);
        }
    }
}
