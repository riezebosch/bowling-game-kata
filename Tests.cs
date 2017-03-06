using System;
using Xunit;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void OpenFrame_Score_Sum() 
        {
            var first = 3;
            var second = 2;

            var score = first + second;

            Assert.Equal(5, score);
        }

        [Fact]
        public void SingleStrike_Score_10()
        {
            var score = 10;
            Assert.Equal(10, score);
        }
    }
}
