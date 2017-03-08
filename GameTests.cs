using System;
using Xunit;

namespace Tests
{
    public class GameTests
    {
        [Fact]
        public void PerfectGameScore()
        {
            var game = new Game();
            game
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddStrikeBonus(10, 10);

            Assert.Equal(300, game.Score());
        }

        [Fact]
        public void GameBonusSpare()
        {
            var game = new Game()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddSpare(3)
                .AddSpareBonus(10);

            Assert.Equal(273, game.Score());
        }

        [Fact]
        public void PointsSingleFrameEqualsScore()
        {
            var game = new Game();
            game.AddStrike();

            Assert.Equal(10, game.Score());
        }

        [Fact]
        public void SubsequentFrameIncreasesScore()
        {
            var game = new Game();
            game
                .AddStrike()
                .AddStrike();

            Assert.Equal(30, game.Score());
        }

        [Fact]
        public void AddSpare()
        {
            var game = new Game();
            game.AddSpare(5);

            Assert.Equal(10, game.Score());
        }

        [Fact]
        public void AddOpenFrame()
        {
            var game = new Game();
            game.AddOpenFrame(5, 1);

            Assert.Equal(6, game.Score());
        }

        [Fact]
        public void AddStrikeBonusOnlyValidAfterStrike()
        {
            Assert.Throws<InvalidOperationException>(() => new Game().AddStrikeBonus(4, 3));
        }

        [Fact]
        public void AddSpareBonusOnlyValidAfterStrike()
        {
            Assert.Throws<InvalidOperationException>(() => new Game().AddSpareBonus(4));
        }

        [Fact]
        public void AddSpareBonusOnlyValidAfterLastFrame()
        {
            var game = new Game()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddSpare(3);

            Assert.Throws<InvalidOperationException>(() => game.AddSpareBonus(4));
        }

        [Fact]
        public void AddStrikeBonusOnlyValidAfterTenthFrame()
        {
            var game = new Game()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddStrike();

            Assert.Throws<InvalidOperationException>(() => game.AddStrikeBonus(4, 10));
        }

        [Fact]
        public void MaxFrames10()
        {
            var game = new Game()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddStrike()
                .AddStrike();

            Assert.Throws<InvalidOperationException>(() => game.AddStrike());
        }
    }
}
