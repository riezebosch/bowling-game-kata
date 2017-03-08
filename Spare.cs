namespace Tests
{
    public class Spare : IFrame
    {
        public int FirstRoll { get; }

        public int NextRoll => 10 - FirstRoll;

        public IFrame Next { get; set; }
        public Spare(int a)
        { 
            FirstRoll = a;
        }

        public int Points => 10 + (Next?.FirstRoll ?? 0);
    }
}
