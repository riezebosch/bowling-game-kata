namespace Tests
{
    public class SpareBonus : IFrame
    {
        public SpareBonus(int v)
        {
            FirstRoll = v;
        }

        public int Points => 0;

        public int FirstRoll { get; }

        public int NextRoll => 0;

        public IFrame Next => null;
    }
}
