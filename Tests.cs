using System;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void OpenFrame_Score_Sum()
        {
            var frame = new OpenFrame(3, 2);

            Assert.Equal(5, frame.Score());
        }

        class OpenFrame
        {
            readonly int _a, _b;
            public OpenFrame(int a, int b)
            {
                _a = a;
                _b = b;
            }
            
            public int Score()
            {
                return _a + _b;
            }
        }

        [Fact]
        public void SingleStrike_Score_10()
        {
            var frame = new Strike();
            Assert.Equal(10, frame.Score());
        }

        private class Strike
        {
            public int Score()
            {
                return 10;
            }
        }
    }
}
