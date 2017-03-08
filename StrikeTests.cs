using Xunit;

namespace Tests
{
    public class StrikeTests
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
        public void PerfectGame30Points()
        {
            var frame = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike () } } } } } } } } } } };
            Assert.Equal(30, frame.Points);
        }

        [Fact]
        public void StrikeWithSpareWithOpenFrame20()
        {
            var frame = new Strike { Next = new Spare(5) { Next = new OpenFrame(1,1)}};
            Assert.Equal(20, frame.Points);
        }

        [Fact]
        public void StrikeWithBonus()
        {
            var frame = new Strike { Next = new StrikeBonus(10, 5) };
            Assert.Equal(25, frame.Points);
        }
    }
}
