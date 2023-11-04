namespace TikTakToe.API.Models.Games
{
    public struct GamePostBody
    {
        public List<int> ParticipantsIds { get; set; }
        public int LengthX { get; set; }
        public int LengthY { get; set; }
    }
}
