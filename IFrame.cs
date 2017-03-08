namespace Tests
{
    public interface IFrame
    {
        int Points { get; }
        int FirstRoll { get; }
        int NextRoll { get; }

        IFrame Next { get; }
    }
}
