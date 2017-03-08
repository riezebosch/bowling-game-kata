using System;

namespace Tests
{
    public class StrikeBonus : IBonusFrame
    {
        public StrikeBonus(int pins1, int pins2)
        {
            if (pins1 < 0 || pins1 > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(pins1));
            }

            if (pins2 < 0 || pins2 > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(pins1));
            }

            FirstRoll = pins1;
            NextRoll = pins2;
        }

        public int Points => 0;

        public int FirstRoll { get; }

        public int NextRoll { get; }

        public IFrame Next { get; set; }
    }
}
