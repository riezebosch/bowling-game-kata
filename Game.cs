using System;

namespace Tests
{
    public class Game
    {
        private IFrame first;
        private IFrame last;
        private int count;

        public int Score()
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
      
        public Game AddStrike()
        {
            return Add(new Strike());
        }

        public Game AddStrikeBonus(int pins1, int pins2)
        {
            if (!(last is Strike))
            {
                throw new InvalidOperationException("Strike Bonus is only valid after a Strike");
            }

            if (count < 10)
            {
                throw new InvalidOperationException("Strike Bonus is only valid after the last Strike");
            }

            return Add(new StrikeBonus(pins1, pins2));
        }

        public Game AddSpare(int pins)
        {
            return Add(new Spare(pins));
        }

        public Game AddSpareBonus(int pins)
        {
            if (!(last is Spare))
            {
                throw new InvalidOperationException("Spare Bonus is only valid after a Spare");
            }

            if (count < 10)
            {
                throw new InvalidOperationException("Spare Bonus is only valid after the last Spare");
            }

            return Add(new SpareBonus(pins));
        }

        public Game AddOpenFrame(int pins1, int pins2)
        {
            return Add(new OpenFrame(pins1, pins2));
        }

        private Game Add(IFrame frame)
        {
            if (!(frame is IBonusFrame) && count == 10)
            {
                throw new InvalidOperationException("max frames");
            }

            if (first == null)
            {
                first = last = frame;
            }
            else
            {
                last = last.Next = frame;
            }

            count++;
            return this;
        }
    }
}
