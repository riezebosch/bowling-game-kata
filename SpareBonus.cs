namespace Tests
{
    public class SpareBonus : IBonusFrame
    {
        public SpareBonus(int pins)
        {
            FirstRoll = pins;
        }

        public int Points => 0;

        public int FirstRoll { get; }

        public int NextRoll => 0;

        public IFrame Next { get; set; }
    }
}
