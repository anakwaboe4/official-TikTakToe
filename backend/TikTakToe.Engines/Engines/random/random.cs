using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TikTakToe.Core.Boards;

namespace TikTakToe.Engines.Engines.random
{
    public class random : IEngine
    {
        public Core.Enums.Engines Engine => Core.Enums.Engines.Random;

        private Stopwatch sw = new Stopwatch();
        private Random randomPicker = new Random();

        public double Bench(int depth)
        {
            if (depth != 0) throw new NotImplementedException("Bench with depth not implemented in random engine.");
            sw.Restart();
            sw.Start();
            _ = MakeMove(new int[3, 3], 1);
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        // returns new board and an integer score (random engine returns 0)
        public (int[,] board, int score) MakeMove(int[,] board, int nextPlayer, int depth = 0)
        {
            if (depth != 0) throw new NotImplementedException("MakeMove with depth not implemented in random engine.");
            int[,] currentBoard = (int[,])board.Clone();
            int currentPlayer = nextPlayer;
            List<(int, int)> availableMoves = new List<(int, int)>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (currentBoard[i, j] == 0)
                    {
                        availableMoves.Add((i, j));
                    }
                }
            }
            if (availableMoves.Count == 0)
            {
                throw new InvalidOperationException("No available moves left.");
            }
            var (row, col) = availableMoves[randomPicker.Next(availableMoves.Count)];
            currentBoard[row, col] = currentPlayer;
            // score is random number between -1000 and 1000
            int score = randomPicker.Next(-1000, 1001);
            return ((int[,])currentBoard.Clone(), score);

        }
    }
}
