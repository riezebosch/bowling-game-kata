using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class GameTests
    {
        [Fact]
        public void PerfectGameScore()
        {
            var frame = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new StrikeBonus(10, 10) } } } } } } } } } };
            var game = new Game();
            game.Add(frame);

            int score = game.CalculateScore();
            Assert.Equal(300, score);
        }

        [Fact]
        public void GameEndsWithBonusFrame()
        {
            var frame = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Spare(3) { Next = new SpareBonus(10) } } } } } } } } } };
            var game = new Game();
            game.Add(frame);

            Assert.Equal(273, game.CalculateScore());
        }

    }
}
