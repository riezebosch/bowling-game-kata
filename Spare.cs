using System;

namespace Tests
{
    public class Spare : IFrame
    {
        public int FirstRoll { get; }

        public int NextRoll => 10 - FirstRoll;

        public IFrame Next { get; set; }
        public Spare(int pins)
        { 
            if (pins < 0 || pins >= 10)
            {
                throw new ArgumentOutOfRangeException(nameof(pins));
            }
            FirstRoll = pins;
        }

        public int Points => 10 + (Next?.FirstRoll ?? 0);
    }
}
