using System;
using Xunit;

namespace Tests
{
    public class SpareTests
    {
        [Fact]
        public void SingleSparePoints10()
        {
            var frame = new Spare(2);
            Assert.Equal(10, frame.Points);
        }

        [Fact]
        public void SpareWithOpenFrame10PlusFirstRoll()
        {
            var frame = new Spare(2)
            {
                Next = new OpenFrame(1,1)
            };

            Assert.Equal(11, frame.Points);
        }

        [Fact]
        public void SpareWithBonus()
        {
            var frame = new Spare(2) { Next = new SpareBonus(5) };
            Assert.Equal(15, frame.Points);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(-1)]
        public void SpareBoundaries(int pins)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Spare(pins));
        }
    }
}
