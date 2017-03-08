using System;

namespace Tests
{
    public class OpenFrame : IFrame
    {
        public int FirstRoll { get; }
        public int NextRoll { get; }

        public OpenFrame(int pins1, int pins2)
        {
            if (pins1 < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pins1));
            }

            if (pins2 < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pins2));
            }

            if (pins1 + pins2 == 10)    
            {
                throw new ArgumentOutOfRangeException("that's a Spare");
            }

            if (pins1 + pins2 > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(pins2));
            }

            FirstRoll = pins1;
            NextRoll = pins2;
        }
        
        public int Points => FirstRoll + NextRoll;

        public IFrame Next { get; set; }
    }
}
