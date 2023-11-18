using System.Collections;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using TikTakToe.Core.Boards;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TikTakToe.Engines.Engines.perfectOpertunism
{
    public class PerfectOpertunism : IEngine
    {
        public Core.Enums.Engines Engine => Core.Enums.Engines.PerfectOptemism;

        private int board;
        public static Hashtable boardScores = new Hashtable();
        private Stopwatch sw = new Stopwatch();

        public PerfectOpertunism()
        {
            CalculateAllMoves();
        }

        #region Public classes
        public int MakeMove(int move)
        {
            board = Domove(board, move);
            int highestScore = 0;
            int bestMove = 0;
            for(int i = 1; i <= 9; i++)
            {
                int newBoard = Domove(board, i);
                if(newBoard != 0)
                {
                    int score = GetScore(newBoard);

                    if(score > highestScore)
                    {
                        highestScore = score;
                        bestMove = i;
                    }
                }
            }
            return bestMove;
        }

        public int SetPos(int pos)
        {
            board = pos;
            int highestScore = 0;
            int bestMove = 0;
            for(int i = 1; i <= 9; i++)
            {
                int newBoard = Domove(board, i);
                int score = GetScore(newBoard);

                if(score > highestScore)
                {
                    highestScore = score;
                    bestMove = i;
                }
            }
            return bestMove;
        }

        public double Bench()
        {
            sw.Restart();
            sw.Start();
            CalculateAllMoves();
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
        #endregion

        #region Private classes
        private void CalculateAllMoves()
        {
            List<int> scoresX = new List<int>();
            //Parallel.For(1, 10, i =>
            //{
            //    int newboard = Domove(board, i);
            //    if(newboard != 0)
            //    {
            //        (int scoreXtemp, int scoreOtemp) = CalculateBeta(newboard);
            //        scoresX.Add(scoreXtemp);
            //    }
            //});
            for( int i = 1; i < 10; i ++)
            {
                int newboard = Domove(board, i);
                if(newboard != 0)
                {
                    (int scoreXtemp, int scoreOtemp) = CalculateBeta(newboard);
                    scoresX.Add(scoreXtemp);
                }
            }
            int scoreX = scoresX.Max();
            AddBoardScore(board, scoreX);

        }

        private (int, int) CaluclateAlfa(int board)
        {
            if (board == 21)
            {
                Console.WriteLine("idk");
            }
            if (board == 1000000021)
            {
                Console.WriteLine("didn't know it before");
            }
            int score = Checkscore(board);
            if(score < 1000 && score > -1000)
            {
                List<int> scoresX = new List<int>();
                List<int> scoresO = new List<int>();
                for(int i = 1; i < 10; i++)
                {
                    int newboard = Domove(board, i);
                    if(newboard != 0)
                    {
                        (int scoreXtemp, int scoreOtemp) = CalculateBeta(newboard);
                        scoresX.Add(scoreXtemp);
                        scoresO.Add(scoreOtemp);
                    }
                }
                if(scoresO.Count == 0 || scoresX.Count == 0) return (0, 0);
                int scoreX = scoresX.Max();
                int scoreO = scoresO.Sum() / scoresO.Count;
                AddBoardScore(board, scoreX);
                return (scoreX, scoreO);
            }
            return (score, score);
        }

        private (int, int) CalculateBeta(int board)
        {
            if(board == 21)
            {
                Console.WriteLine("idk");
            }
            if(board == 1000000021)
            {
                Console.WriteLine("didn't know it before");
            }
            int score = Checkscore(board);
            if(score < 1000 && score > -1000)
            {
                List<int> scoresX = new List<int>();
                List<int> scoresO = new List<int>();
                for(int i = 1; i < 10; i++)
                {
                    int newboard = Domove(board, i);
                    if(newboard != 0)
                    {
                        (int scoreXtemp, int scoreOtemp) = CaluclateAlfa(newboard);
                        scoresX.Add(scoreXtemp);
                        scoresO.Add(scoreOtemp);
                    }
                }
                if (scoresO.Count == 0 || scoresX.Count == 0) return(0,0);
                int scoreX = scoresX.Sum() / scoresX.Count();
                int scoreO = scoresO.Min();
                AddBoardScore(board, -scoreO);
                return (scoreX, scoreO);
            }
            return (score, score);
        }

        private static void AddBoardScore(int board, int score)
        {
            try
            {
                if(board > 1000000000) board -= 1000000000;
                if(!boardScores.ContainsKey(board))
                {
                    boardScores.Add(board, score);
                }
            }
            catch { };
        }

        private static int GetScore(int board)
        {
            if(board > 1000000000) board -= 1000000000;
            if(boardScores.ContainsKey(board))
            {
                return (int)boardScores[board];
            }
            else
            {
                throw new ArgumentOutOfRangeException("No legal board value");
            }
        }

        private int Domove(int board, int move)
        {
            int player = (int)(board / 1000000000) + 1;
            int positionValue = (int)Math.Pow(10, move - 1);
            int digit = (board / positionValue) % 10;

            if(digit == 0)
            {
                board += player * positionValue;
            }
            else
            {
                return 0;
            }
            if(player == 1) board += 1000000000;
            else board -= 1000000000;
            return board;
        }
        private int Checkscore(int board)
        {
            int[] boardState = new int[9];

            for(int i = 0; i < 9; i++)
            {
                boardState[i] = (board % 10);
                board /= 10;
            }

            if(boardState[4] == 1) //quick middlecheck for effectient updating 
            {
                if(boardState[8] == 1 && boardState[0] == 1) { return 1000; }
                else if(boardState[2] == 1 && boardState[6] == 1) { return 1000; }
                else if(boardState[3] == 1 && boardState[5] == 1) { return 1000; }
                else if(boardState[1] == 1 && boardState[7] == 1) { return 1000; }

            }
            else if(boardState[4] == 2)
            {
                if(boardState[8] == 2 && boardState[0] == 2) { return -1000; }
                else if(boardState[2] == 2 && boardState[6] == 2) { return -1000; }
                else if(boardState[3] == 2 && boardState[5] == 2) { return -1000; }
                else if(boardState[1] == 2 && boardState[7] == 2) { return -1000; }

            }
            if(boardState[0] == 1 && boardState[1] == 1 && boardState[2] == 1) { return 1000; }
            if(boardState[6] == 1 && boardState[7] == 1 && boardState[8] == 1) { return 1000; }
            if(boardState[0] == 2 && boardState[1] == 2 && boardState[2] == 2) { return -1000; }
            if(boardState[6] == 2 && boardState[7] == 2 && boardState[8] == 2) { return -1000; }
            //check logic again
            if(boardState[0] == 1 && boardState[3] == 1 && boardState[6] == 1) { return 1000; }
            if(boardState[2] == 1 && boardState[5] == 1 && boardState[8] == 1) { return 1000; }
            if(boardState[0] == 2 && boardState[3] == 2 && boardState[6] == 2) { return -1000; }
            if(boardState[2] == 2 && boardState[5] == 2 && boardState[8] == 2) { return -1000; }
            else return 0;
        }
        #endregion
        public void printHashTable()
        {
            foreach(DictionaryEntry entry in boardScores)
            {
                Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
            }
        }
    }
}
