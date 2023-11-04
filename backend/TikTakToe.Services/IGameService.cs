using TikTakToe.Core.Enums;

namespace TikTakToe.Services
{
    public interface IGameService
    {
        void NewGame();
        void NewGame(List<Core.Enums.Engines> engineIds, int lengthX, int lengthY);
        bool CheckMove(int position);
        bool MakeMove(int position, Squares move);
        bool MakeAiMove(int participant, Squares square);
        int CalculateScore();
        List<List<Squares>> GetBoard();
        string PrintBoard();
        string ToString();
    }
}
