// This is to manually test the Engines without needing to use the API
using System.Runtime.CompilerServices;
using TikTakToe.Engines;
using TikTakToe.Engines.Engines.random;

internal class Program
{

    private static void Main(string[] args)
    {
        //int[][] board = StringToMatrix(input);
        //PrintMatrix(board);

        IEngine engine = new TikTakToe.Engines.Engines.random.random(); // create a IEngine with the class you would like to test
        while(true)
        {
            Console.WriteLine("1 for move test, 2 for board test and 3 for benchtesting, the rest of the numbers can be used for costom test");
            switch(Int32.Parse(Console.ReadLine()))
            {
                case 1:
                    int[][] boardMove = new int[3][];
                    boardMove[0] = new int[3];
                    boardMove[1] = new int[3];
                    boardMove[2] = new int[3];
                    while(IsBoardNotFilled(boardMove))
                    {
                        Console.WriteLine("Give your square:");
                        int move = Int32.Parse(Console.ReadLine());
                        int moveboardMove = move - 1;
                        int row = moveboardMove / 3;
                        int col = moveboardMove % 3;
                        boardMove[row][col] = 1;
                        move = engine.MakeMove(move);
                        moveboardMove = move - 1;
                        row = moveboardMove / 3;
                        col = moveboardMove % 3;
                        boardMove[row][col] = 2;
                        PrintMatrix(boardMove);
                    }
                    break;
                case 2:
                    int[][] boardPos = new int[3][];
                    boardPos[0] = new int[3];
                    boardPos[1] = new int[3];
                    boardPos[2] = new int[3];
                    int pos = 0;
                    while(IsBoardNotFilled(boardPos))
                    {
                        Console.WriteLine("type the int position or -1 for self play move");
                        int select = Int32.Parse(Console.ReadLine());
                        if(select != -1) pos = select;
                        int move = engine.SetPos(pos);
                        pos += (int)Math.Pow(10, move - 1);
                        int[][] printboard = IntToMatrix(pos);
                        PrintMatrix(printboard);
                    }
                    break;
                case 3:
                    Console.WriteLine(engine.Bench());
                    break;
            }
        }
    }
    private static bool IsBoardNotFilled(int[][] board)
    {
        for (int i = 0; i < board.Length; i++)
        {
            for(int j = 0; j < board[i].Length; j++)
            {
                if(board[i][j] == 0) return true;
            }
        }
        return false;
    }
    private static int[][] IntToMatrix(int input)
    {
        int[][] matrix = new int[3][];
        for(int i = 0; i < 3; i++)
        {
            matrix[i] = new int[3];

            for(int j = 0; j < 3; j++)
            {
                int digit = input % 10;
                matrix[i][2 - j] = digit; // Reverse the order to match the desired representation
                input /= 10;
            }
        }

        return matrix;
    }

    private static void PrintMatrix(int[][] matrix)
    {
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                if(matrix[i][j] == 1)
                {
                    Console.Write("X ");
                }
                else if(matrix[i][j] == 2)
                {
                    Console.Write("O ");
                }
                else
                {
                    Console.Write("  "); // Empty space
                }
            }
            Console.WriteLine();
        }
    }
}