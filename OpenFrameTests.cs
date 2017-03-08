using System;
using Xunit;

namespace Tests
{
    public class OpenFrameTests
    {
        [Theory]
        [InlineData(9, 2)]
        [InlineData(-1, 0)]
        [InlineData(3, -1)]
        [InlineData(11, 0)]
        [InlineData(0, 11)]
        public void OpenFrameBoundaries(int pins1, int pins2)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new OpenFrame(pins1, pins2));
        }
      
        [Fact]
        public void OpenFrameTotal10Throws()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new OpenFrame(7, 3));
            Assert.Contains("Spare", ex.Message);
        }
    }
}
