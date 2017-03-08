using System;

namespace Tests
{
    public class Spare : IFrame
    {
        public int FirstRoll { get; }

        public int NextRoll => 10 - FirstRoll;

        public IFrame Next { get; set; }
        public Spare(int a)
        { 
            if (a < 0 || a >= 10)
            {
                throw new ArgumentOutOfRangeException(nameof(a));
            }
            FirstRoll = a;
        }

        public int Points => 10 + (Next?.FirstRoll ?? 0);
    }
}
