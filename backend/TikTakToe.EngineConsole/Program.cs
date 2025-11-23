using System;
using TikTakToe.Core.Enums;

namespace TikTakToe.EngineConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Engine loader test\n");

            Console.WriteLine("Available engines from enum:");
            foreach (var v in Enum.GetValues(typeof(TikTakToe.Core.Enums.Engines)))
            {
                Console.WriteLine($" - {(TikTakToe.Core.Enums.Engines)v} ({(int)v})");
            }

            Console.WriteLine("\nEnter engine number (default 1 = Random):");
            string? input = Console.ReadLine();
            int choice = 1;
            if (!string.IsNullOrWhiteSpace(input) && int.TryParse(input, out var parsed)) choice = parsed;
            TikTakToe.Core.Enums.Engines selected = TikTakToe.Core.Enums.Engines.Random;
            if (Enum.IsDefined(typeof(TikTakToe.Core.Enums.Engines), choice))
            {
                selected = (TikTakToe.Core.Enums.Engines)choice;
            }

            var engine = CreateEngine(selected);
            Console.WriteLine($"Created engine: {engine.Engine}\n");

            // Play a full match: engine (X=1) vs random (O=2)
            int[,] board = new int[3, 3];
            int currentPlayer = 1;
            var randomOpp = new TikTakToe.Engines.Engines.random.random();

            while (true)
            {
                Console.WriteLine();
                PrintBoard(board);

                if (currentPlayer == 1)
                {
                    (int[,] newBoard, int score) = engine.MakeMove(board, currentPlayer);
                    board = newBoard;
                    Console.WriteLine($"Engine (X) moved (score={score})");
                }
                else
                {
                    (int[,] newBoard, int score) = randomOpp.MakeMove(board, currentPlayer);
                    board = newBoard;
                    Console.WriteLine($"Random (O) moved");
                }

                int eval = EvaluateBoardLocal(board);
                if (eval != 0)
                {
                    PrintBoard(board);
                    Console.WriteLine(eval > 0 ? "X (engine) wins" : "O (random) wins");
                    break;
                }
                if (IsBoardFullLocal(board))
                {
                    PrintBoard(board);
                    Console.WriteLine("Draw");
                    break;
                }

                currentPlayer = currentPlayer == 1 ? 2 : 1;
                Console.WriteLine("Press Enter for next move, Q to quit");
                string? k = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(k) && k.Equals("Q", StringComparison.OrdinalIgnoreCase)) break;
            }
        }

        static TikTakToe.Engines.IEngine CreateEngine(TikTakToe.Core.Enums.Engines e)
        {
            return e switch
            {
                TikTakToe.Core.Enums.Engines.Random => new TikTakToe.Engines.Engines.random.random(),
                TikTakToe.Core.Enums.Engines.MaxOdds => new TikTakToe.Engines.Engines.maxOdds.maxOdds(),
                _ => new TikTakToe.Engines.Engines.random.random(),
            };
        }

        static void PrintBoard(int[,] b)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    char ch = b[i, j] == 0 ? '.' : (b[i, j] == 1 ? 'X' : 'O');
                    Console.Write(ch);
                }
                Console.WriteLine();
            }
        }

        static int EvaluateBoardLocal(int[,] board)
        {
            if (board[1, 1] == 1)
            {
                if (board[0, 0] == 1 && board[2, 2] == 1) return 1000;
                if (board[0, 2] == 1 && board[2, 0] == 1) return 1000;
                if (board[1, 0] == 1 && board[1, 2] == 1) return 1000;
                if (board[0, 1] == 1 && board[2, 1] == 1) return 1000;
            }
            if (board[1, 1] == 2)
            {
                if (board[0, 0] == 2 && board[2, 2] == 2) return -1000;
                if (board[0, 2] == 2 && board[2, 0] == 2) return -1000;
                if (board[1, 0] == 2 && board[1, 2] == 2) return -1000;
                if (board[0, 1] == 2 && board[2, 1] == 2) return -1000;
            }
            if (board[0, 0] == 1 && board[0, 1] == 1 && board[0, 2] == 1) return 1000;
            if (board[0, 0] == 2 && board[0, 1] == 2 && board[0, 2] == 2) return -1000;
            if (board[2, 0] == 1 && board[2, 1] == 1 && board[2, 2] == 1) return 1000;
            if (board[2, 0] == 2 && board[2, 1] == 2 && board[2, 2] == 2) return -1000;
            if (board[0, 0] == 1 && board[1, 0] == 1 && board[2, 0] == 1) return 1000;
            if (board[0, 0] == 2 && board[1, 0] == 2 && board[2, 0] == 2) return -1000;
            if (board[0, 2] == 1 && board[1, 2] == 1 && board[2, 2] == 1) return 1000;
            if (board[0, 2] == 2 && board[1, 2] == 2 && board[2, 2] == 2) return -1000;
            return 0;
        }

        static bool IsBoardFullLocal(int[,] board)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (board[i, j] == 0) return false;
            return true;
        }
    }
}
