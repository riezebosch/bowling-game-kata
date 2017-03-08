using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class GameTests
    {
        private readonly ITestOutputHelper output;
        public GameTests(ITestOutputHelper output)
        {
            this.output = output;
        }


         [Fact]
        public void PerfectGameScore()
        {
            var frame = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new StrikeBonus(10, 10) } } } } } } } } } };
            int score = CalculateScore(frame);
            Assert.Equal(300, score);
        }

        private int CalculateScore(IFrame frame)
        {
            int score = 0;
            while (frame != null)
            {
                output.WriteLine($"{frame.GetType()}: {frame.Points} {score}");
                score += frame.Points;
                frame = frame.Next;
            }

            return score;
        }

        [Fact]
        public void GameEndsWithBonusFrame()
        {
            var frame = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Spare(3) { Next = new SpareBonus(10) } } } } } } } } } };
            Assert.Equal(273, CalculateScore(frame));
        }

    }
}
