using System;

namespace Tests
{
    public class OpenFrame : IFrame
    {
        public int FirstRoll { get; }
        public int NextRoll { get; }

        public OpenFrame(int a, int b)
        {
            if (a < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(a));
            }

            if (b < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(b));
            }

            if (a + b == 10)    
            {
                throw new ArgumentOutOfRangeException("use a Spare");
            }

            if (a + b > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(b));
            }

            FirstRoll = a;
            NextRoll = b;
        }
        
        public int Points => FirstRoll + NextRoll;

        public IFrame Next { get; set; }
    }
}
