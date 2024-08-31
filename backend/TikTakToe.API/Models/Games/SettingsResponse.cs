namespace TikTakToe.API.Models.Games
{
    public struct SettingsResponse
    {
        public List<string> Engines { get; set; }
        public List<string> DisabledEngines { get; set; }
    }
}
