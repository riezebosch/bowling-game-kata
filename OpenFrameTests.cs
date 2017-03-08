using System;
using Xunit;

namespace Tests
{
    public class OpenFrameTests
    {
        [Fact]
        public void OpenFrameTotalExceeds10Pins()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new OpenFrame(9, 2));
        }

        [Fact]
        public void OpenFrameNegativeNumber()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new OpenFrame(-1, 0));
        }

        [Fact]
        public void OpenFrameSecondThrowNegativeNumber()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new OpenFrame(3, -1));
        }

        [Fact]
        public void OpenFrameFirstThrowMoreThan10()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new OpenFrame(11, 0));
        }

        [Fact]
        public void OpenFrameSecondThrowMoreThan10()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new OpenFrame(0, 11));
        }

        [Fact]
        public void OpenFrameTotal10Throws()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new OpenFrame(7, 3));
        }
    }
}
