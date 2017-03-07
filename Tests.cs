using System;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void OpenFrame_Points_Sum()
        {
            var frame = new OpenFrame(3, 2);
            Assert.Equal(5, frame.Points);
        }

        [Fact]
        public void SingleStrike_Points_10()
        {
            var frame = new Strike();
            Assert.Equal(10, frame.Points);
        }

        [Fact]
        public void StrikeNextOpenFrame_Points_10PlusSum()
        {
            var frame = new Strike
            {
                Next = new OpenFrame(1, 1)
            };

            Assert.Equal(12, frame.Points);
        }

        [Fact]
        public void DoubleStrikePoints20()
        {
            var frame = new Strike
            {
                Next = new Strike()
            };

            Assert.Equal(20, frame.Points);
        }

        [Fact]
        public void TripleStrikePoints30()
        {
            var frame = new Strike()
            {
                Next = new Strike 
                {
                    Next = new Strike()
                }
            };
            
            Assert.Equal(30, frame.Points);
        }

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
        public void StrikeWithSpareWithOpenFrame20()
        {
            var frame = new Strike { Next = new Spare(5) { Next = new OpenFrame(1,1)}};
            Assert.Equal(20, frame.Points);
        }

        [Fact]
        public void PerfectGame()
        {
            var frame = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike () } } } } } } } } } } };
            Assert.Equal(30, frame.Points);
        }

         [Fact]
        public void PerfectGameScore()
        {
            IFrame frame = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new BonusStrike { Next = new BonusStrike() } } } } } } } } } } };
            int score = CalculateScore(frame);
            Assert.Equal(300, score);
        }

        private static int CalculateScore(IFrame frame)
        {
            int score = 0;
            while (frame != null)
            {
                score += frame.Points;
                frame = frame.Next;
            }

            return score;
        }

        [Fact]
        public void GameEndsWithBonusFrame()
        {
            
        }

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

    public class BonusStrike : Strike
    {
        public override int Points => 0;
    }

    public abstract class Frame : IFrame
    {
        public int First { get; }
        public int Second { get; }

        public Frame(int a, int b)
        {
            if (a < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(a));
            }

            if (b < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(b));
            }

            if (a + b > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(b));
            }

            First = a;
            Second = b;
        }
        
        public virtual int Points => First + Second;

        public IFrame Next { get; set; }
    }


    public class OpenFrame : Frame
    {
        public OpenFrame(int a, int b) : base (a, b)
        {
            if (a + b == 10)
            {
                throw new ArgumentOutOfRangeException("use a Spare");
            }
        }
    }

    public class Strike : IFrame
    {
        public IFrame Next { get; set; }

        public virtual int Points
        {
            get
            {
                int score = First;
                if (Next != null)
                {
                    if (Next is Strike)
                    {
                        score += Next.First;
                        if (Next.Next != null)
                        {
                            score += Next.Next.First;
                        }
                    }
                    else 
                    {
                        score += Next.First + Next.Second;
                    }
                }

                return score;
            }
        }

        public int First => 10;

        public int Second { get  { throw new NotImplementedException(); } }
    }

    public interface IFrame
    {
        int Points { get; }
        int First { get; }
        int Second { get; }

        IFrame Next { get; }
    }

    public class Spare : Frame
    {
        public Spare(int a) : base(a, 10 - a)
        {
        }

        public override int Points
        {
            get
            {
                var score = 10;
                if (Next != null)
                {
                    score += Next.First;
                }

                return score;
            }
        }
    }
}
