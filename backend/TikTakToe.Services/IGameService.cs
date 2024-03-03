using TikTakToe.Core.Enums;
using TikTakToe.Repositories.Models;

namespace TikTakToe.Services
{
    public interface IGameService
    {
        GameItem NewGame(List<Core.Enums.Engines>? engineIds = null, int? lengthX = null, int? lengthY = null);
        GameItem? GetGame(Guid gameId);
        bool CheckMove(int position);
        bool MakeMove(int position, Squares move);
        bool MakeAiMove(int participant, Squares square);
        List<List<Squares>> GetBoard();
        string PrintBoard();
        string ToString();
    }
}
