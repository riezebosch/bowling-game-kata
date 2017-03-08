using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class GameTests
    {
        [Fact]
        public void PerfectGameScore()
        {
            var game = new Game();
            game
                .Add(new Strike())
                .Add(new Strike())
                .Add(new Strike())
                .Add(new Strike())
                .Add(new Strike())
                .Add(new Strike())
                .Add(new Strike())
                .Add(new Strike())
                .Add(new Strike())
                .Add(new Strike())
                .Add(new StrikeBonus(10, 10));

            Assert.Equal(300, game.CalculateScore());
        }

        [Fact]
        public void GameEndsWithBonusFrame()
        {
            var frame = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Strike { Next = new Spare(3) { Next = new SpareBonus(10) } } } } } } } } } };
            var game = new Game();
            game.Add(frame);

            Assert.Equal(273, game.CalculateScore());
        }

        [Fact]
        public void PointsSingleFrameEqualsScore()
        {
            var game = new Game();
            game.Add(new Strike());

            Assert.Equal(10, game.CalculateScore());
        }

        [Fact]
        public void SubsequentFrameIncreasesScore()
        {
            var game = new Game();
            game
                .Add(new Strike())
                .Add(new Strike());

            Assert.Equal(30, game.CalculateScore());
        }
    }
}
