using System;

namespace Tests
{
    public class Game
    {
        private IFrame first;

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

        public void Add(IFrame frame)
        {
            this.first = frame;
        }
    }
}
