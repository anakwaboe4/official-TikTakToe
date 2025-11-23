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
        private int[,] currentBoard = new int[3, 3];
        private int currentPlayer = 1;

        public double Bench(int depth)
        {
            if (depth != 0) throw new NotImplementedException("Bench with depth not implemented in random engine.");
            sw.Restart();
            sw.Start();
            _ = SetPos(new int[3, 3], 1);
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        // returns new board and next player
        public int[,] SetPos(int[,] board, int nextPlayer, int depth = 0)
        {
            if (depth != 0) throw new NotImplementedException("SetPos with depth not implemented in random engine.");
            currentBoard = (int[,])board.Clone();
            currentPlayer = nextPlayer;
            return MakeMove();

        }

        public int[,] MakeMove(int depth = 0)
        {
            if (depth != 0) throw new NotImplementedException("MakeMove with depth not implemented in random engine.");
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
            currentPlayer = currentPlayer == 1 ? 2 : 1;
            return (int[,])currentBoard.Clone();
        }
    }
}
