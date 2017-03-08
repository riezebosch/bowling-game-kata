using System;

namespace Tests
{
    public class Game
    {
        private IFrame first;
        private IFrame last;

        public int CalculateScore()
        {
            int score = 0;
            var frame = first;

            while (frame != null)
            {
                score += frame.Points;
                frame = frame.Next;
            }

            return score;
        }

        public Game Add(IFrame frame)
        {
            if (first == null)
            {
                first = last = frame;
            }
            else
            {
                last = last.Next = frame;
            }

            return this;
        }
    }
}
