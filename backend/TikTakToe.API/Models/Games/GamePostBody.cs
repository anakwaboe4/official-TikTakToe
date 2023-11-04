namespace TikTakToe.API.Models.Games
{
    public struct GamePostBody
    {
        public List<Core.Enums.Engines> ParticipantsIds { get; set; }
        public int LengthX { get; set; }
        public int LengthY { get; set; }
    }
}
