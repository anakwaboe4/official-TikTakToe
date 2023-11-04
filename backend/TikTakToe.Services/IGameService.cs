using TikTakToe.Core.Boards;
using TikTakToe.Core.Enums;
using TikTakToe.Engines;

namespace TikTakToe.Services
{
    public interface IGameService
    {
        void NewGame();
        void NewGame(List<IEngine> participants, Board board);
        bool CheckMove(int position);
        bool MakeMove(int position, Squares move);
        bool MakeAiMove(int position, Squares move);
        int CalculateScore();
        List<List<Squares>> GetBoard();
        string PrintBoard();
        string ToString();
    }
}
