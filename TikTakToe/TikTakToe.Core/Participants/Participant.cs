namespace TikTakToe.Core.Participants
{
    public abstract class Participant
    {
        public bool IsAI { get; set; }

        public abstract int CalculateNextMove();

        public abstract int CalculateBestMove();
    }
}
