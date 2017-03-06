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

            Assert.Equal(5, frame.Score);
        }

        class OpenFrame : IFrame
        {
            readonly int _a, _b;
            public OpenFrame(int a, int b)
            {
                _a = a;
                _b = b;
            }
            
            public int Score => _a + _b;
        }

        [Fact]
        public void SingleStrike_Score_10()
        {
            var frame = new Strike();
            Assert.Equal(10, frame.Score);
        }

        [Fact]
        public void StrikeNextOpenFrame_Score_Sum()
        {
            var frame = new Strike
            {
                Next = new OpenFrame(1, 1)
            };

            Assert.Equal(12, frame.Score);
        }

        [Fact]
        public void StrikeNextStrike_Score_Sum()
        {
            var frame = new Strike
            {
                Next = new Strike()
            };

            Assert.Equal(20, frame.Score);
        }

        [Fact]
        public void TripleStrikeScore()
        {
            var frame = new Strike()
            {
                Next = new Strike 
                {
                    Next = new Strike()
                }
            };
            
            Assert.Equal(30, frame.Score);
        }



        private class Strike : IFrame
        {
            public IFrame Next { get; set; }

            public int Score
            {
                get
                {
                    int score = 10;
                    if (Next != null)
                    {
                        score += Next.Score;
                    }

                    return score;    
                }
            }
        }

        private interface IFrame
        {
            int Score { get; }
        }
    }
}
