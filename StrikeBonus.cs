namespace Tests
{
    public class StrikeBonus : IFrame
    {
        public StrikeBonus(int a, int b)
        {
            FirstRoll = a;
            NextRoll = b;
        }

        public int Points => 0;

        public int FirstRoll { get; }

        public int NextRoll { get; }

        public IFrame Next => null;
    }
}
