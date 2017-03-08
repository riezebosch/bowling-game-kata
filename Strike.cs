namespace Tests
{
    public class Strike : IFrame
    {
        public IFrame Next { get; set; }

        public int Points => 10 + NextRoll + (Next?.NextRoll ?? 0);

        public int FirstRoll => 10;

        public int NextRoll => Next?.FirstRoll ?? 0;
    }
}
