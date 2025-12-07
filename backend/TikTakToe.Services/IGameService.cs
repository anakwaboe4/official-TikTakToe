using TikTakToe.Core.Enums;

namespace TikTakToe.Services;

internal interface IGameService
{
    bool CheckMove(int position);
    void MakeMove(int position, Squares square);
    void MakeAiMove(int participant, Squares square);
    string PrintBoard();
}
