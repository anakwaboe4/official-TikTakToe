
namespace TikTakToe.Engines.Models.Participants;

public class Player : IEngine
{
    public Core.Enums.Engines Engine => Core.Enums.Engines.Player;

    int[,] IEngine.MakeMove(int[,] board, int nextPlayer, int depth)
    {
        throw new NotImplementedException();
    }

    double IEngine.Bench(int depth)
    {
        throw new NotImplementedException();
    }
}
