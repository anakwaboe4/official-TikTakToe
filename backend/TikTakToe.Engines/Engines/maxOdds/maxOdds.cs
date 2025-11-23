using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TikTakToe.Engines.Engines.maxOdds
{
    public class maxOdds : IEngine
    {
        public Core.Enums.Engines Engine => Core.Enums.Engines.MaxOdds;

        private Stopwatch sw = new Stopwatch();

        public double Bench(int depth)
        {
            if(depth != 0) throw new NotImplementedException("Bench with depth not implemented in MaxOdds engine.");
            sw.Restart();
            sw.Start();
            _ = MakeMove(new int[3, 3], 1);
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
        public (int[,] board, int score) MakeMove(int[,] board, int nextPlayer, int depth = 0)
        {
            if(depth != 0) throw new NotImplementedException("Depth-limited search not supported; only full-tree search (depth=0) is implemented.");

            // If board is already terminal or full, throw
            int eval = EvaluateBoard(board);
            if(eval != 0 || IsBoardFull(board)) throw new InvalidOperationException("Board is already terminal or full.");

            var (result, bestScore) = Minimax(board, nextPlayer, nextPlayer);

            return (result, bestScore);
        }

        // player: current player to move
        // enginePlayer: the player that this engine is trying to maximize for (the original nextPlayer passed to MakeMove)
        // When current player == enginePlayer we maximize; otherwise we model the opponent as mistake-prone and return the average score.
        private (int[,] result, int score) Minimax(int[,] board, int player, int enginePlayer)
        {
            int eval = EvaluateBoard(board);
            if(eval != 0) return (board, eval);
            if(IsBoardFull(board)) return (board, 0);

            List<int> scores = new List<int>();
            List<int[,]> moves = new List<int[,]>();
            for(int i = 1; i <= 9; i++)
            {
                int rr = (i - 1) / 3;
                int cc = (i - 1) % 3;
                if(board[rr, cc] != 0) continue;
                int[,] child = CloneBoard(board);
                child[rr, cc] = player;
                int next = player == 1 ? 2 : 1;
                var (result, score) = Minimax(child, next, enginePlayer);
                scores.Add(score);
                moves.Add(result);
            }

            if(player == 1)
            {
                if(enginePlayer == 1) // maximize
                {
                    int bestScore = scores.Max();
                    int bestIndex = scores.IndexOf(bestScore);
                    int[,] bestMove = moves[bestIndex];
                    return (bestMove, bestScore);
                }
                else // average
                {
                    int sum = 0;
                    foreach(var s in scores) sum += s;
                    int avg = sum / scores.Count;
                    return (board, avg);
                }
            }
            else // player == 2, minimize
            {
                if(enginePlayer == 2) // minimize
                {
                    int bestScore = scores.Min();
                    int bestIndex = scores.IndexOf(bestScore);
                    int[,] bestMove = moves[bestIndex];
                    return (bestMove, bestScore);
                }
                else // average
                {
                    int sum = 0;
                    foreach(var s in scores) sum += s;
                    int avg = sum / scores.Count;
                    return (board, avg);
                }
            }
        }

        private int[,] CloneBoard(int[,] board)
        {
            int[,] nb = new int[3, 3];
            for(int i = 0; i < 3; i++)
                for(int j = 0; j < 3; j++)
                    nb[i, j] = board[i, j];
            return nb;
        }

        private int EvaluateBoard(int[,] board)
        {
            if(board[1, 1] == 1)
            {
                if(board[0, 0] == 1 && board[2, 2] == 1) return 1000;
                if(board[0, 2] == 1 && board[2, 0] == 1) return 1000;
                if(board[1, 0] == 1 && board[1, 2] == 1) return 1000;
                if(board[0, 1] == 1 && board[2, 1] == 1) return 1000;
            }
            if(board[1, 1] == 2)
            {
                if(board[0, 0] == 2 && board[2, 2] == 2) return -1000;
                if(board[0, 2] == 2 && board[2, 0] == 2) return -1000;
                if(board[1, 0] == 2 && board[1, 2] == 2) return -1000;
                if(board[0, 1] == 2 && board[2, 1] == 2) return -1000;
            }
            // rows
            if(board[0, 0] == 1 && board[0, 1] == 1 && board[0, 2] == 1) return 1000;
            if(board[0, 0] == 2 && board[0, 1] == 2 && board[0, 2] == 2) return -1000;
            if(board[2, 0] == 1 && board[2, 1] == 1 && board[2, 2] == 1) return 1000;
            if(board[2, 0] == 2 && board[2, 1] == 2 && board[2, 2] == 2) return -1000;
            // columns
            if(board[0, 0] == 1 && board[1, 0] == 1 && board[2, 0] == 1) return 1000;
            if(board[0, 0] == 2 && board[1, 0] == 2 && board[2, 0] == 2) return -1000;
            if(board[0, 2] == 1 && board[1, 2] == 1 && board[2, 2] == 1) return 1000;
            if(board[0, 2] == 2 && board[1, 2] == 2 && board[2, 2] == 2) return -1000;
            return 0;
        }

        private bool IsBoardFull(int[,] board)
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if(board[i, j] == 0) return false;
                }
            }
            return true;
        }

    }
}
