namespace TikTakToe.Engines;

public interface IEngine
{
    public Core.Enums.Engines Engine { get; }
    // board: 3x3 grid where 0 = empty, 1 = X, 2 = O
    // nextPlayer: 1 = X, 2 = O
    public int[,] MakeMove(int[,] board, int nextPlayer, int depth = 0);
    public double Bench(int depth = 0);
}
