// This is to manually test the Engines without needing to use the API
using System.Collections;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using TikTakToe.Engines;
using TikTakToe.Engines.Engines.perfectOpertunism;
using TikTakToe.Engines.Engines.random;

internal class Program
{

    private static void Main(string[] args)
    {
        //int[][] board = StringToMatrix(input);
        //PrintMatrix(board);

        IEngine engine = new TikTakToe.Engines.Engines.perfectOpertunism.PerfectOpertunism(); // create a IEngine with the class you would like to test
        while(true)
        {
            Console.WriteLine("1 for move test, 2 for board test and 3 for benchtesting, 5 to print the tree (if supported), the rest of the numbers can be used for custom test");
            switch(Int32.Parse(Console.ReadLine()))
            {
                case 1:
                    int[][] boardMove = new int[3][];
                    boardMove[0] = new int[3];
                    boardMove[1] = new int[3];
                    boardMove[2] = new int[3];
                    while(IsBoardNotFilled(boardMove))
                    {
                        int moveboardMove = 0;
                        int row = 0;
                        int col = 0;
                        Console.WriteLine("Give your square:");
                        int move = Int32.Parse(Console.ReadLine());
                        if(move != -1)
                        {
                            moveboardMove = move - 1;
                            row = moveboardMove / 3;
                            col = moveboardMove % 3;
                            boardMove[row][col] = 1;
                        }
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
                        pos += 1000000000;
                        int[][] printboard = IntToMatrix(pos);
                        PrintMatrix(printboard);
                        Console.WriteLine("The position is: " + pos);
                    }
                    break;
                case 3:
                    Console.WriteLine(engine.Bench());
                    break;
                case 4:
                    PerfectOpertunism temp = new PerfectOpertunism();
                    temp.printHashTable();
                    break;
                case 5:
                    PerfectOpertunism temp2 = new PerfectOpertunism();
                    DataTable treeData = temp2.GetTreeTable();
                    PrintTree(treeData);

                    break;
            }
        }
    }
    private static void PrintTree(DataTable treeData)
    {
        ////for (int i = 1; i < 10; i++)
        //{
        //    printTreeNode(treeData, i);
        //}
        printTreeNode(treeData, 1);

    }
    private static void printTreeNode(DataTable treeData, int basekey, StreamWriter sw = null)
    {
        try
        {
            DataRow[] rows = treeData.Select($"key = {basekey}");
            if (sw == null) printRowDataTable(rows[0], (int)Math.Floor(Math.Log10(basekey) + 1));
            else printRowDataTableToFile(rows[0], (int)Math.Floor(Math.Log10(basekey) + 1), sw);
            for(int i = 1; i < 10; i++)
            {
                printTreeNode(treeData, basekey * 10 + i, sw);
            }
        }
        catch
        {
            return;
        }
    }
    private static void printRowDataTable(DataRow row, int tabs)
    {
        // first get the key and print it
        PrintWithIndent($"Key: {row["key"]}", tabs);
        // then we get the board value and use the IntToMatrix and PrintMatrix to print the board
        int board = (int)row["board"];
        int[][] boardmatrix = IntToMatrix(board);
        PrintMatrix(boardmatrix, tabs);
        PrintWithIndent(board.ToString(), tabs);
        // then we print the scoreLists for both X and O and the picked score for X and O
        List<int> listScoreX = (List<int>)row["listScoreX"];
        List<int> listScoreO = (List<int>)row["listScoreO"];
        PrintWithIndent("ScoresX: ", tabs);
        Console.Write(new string('\t', tabs));
        foreach(int score in listScoreX)
        {
            Console.Write(score + " ");
        }
        Console.WriteLine();
        PrintWithIndent("Best scoreX: " + row["scoreX"], tabs);
        PrintWithIndent("ScoresO: ", tabs);
        Console.Write(new string('\t', tabs));
        foreach(int score in listScoreO)
        {
            Console.Write(score + " ");
        }
        Console.WriteLine();
        PrintWithIndent("Best scoreO: " + row["scoreO"], tabs);
    }

    private static void printRowDataTableToFile(DataRow row, int tabs, StreamWriter sw)
    {
        // first get the key and print it
        sw.WriteLine(ToStringWithIndent($"Key: {row["key"]}", tabs));
        // then we get the board value and use the IntToMatrix and PrintMatrix to print the board
        int board = (int)row["board"];
        int[][] boardmatrix = IntToMatrix(board);
        sw.WriteLine(MatrixToString(boardmatrix, tabs));
        sw.WriteLine(ToStringWithIndent(board.ToString(), tabs));
        // then we print the scoreLists for both X and O and the picked score for X and O
        List<int> listScoreX = (List<int>)row["listScoreX"];
        List<int> listScoreO = (List<int>)row["listScoreO"];
        sw.WriteLine(ToStringWithIndent("ScoresX: ", tabs));
        sw.Write(ToStringWithIndent("ScoresX: ", tabs));
        foreach(int score in listScoreX)
        {
            sw.Write(score + " ");
        }
        sw.WriteLine();
        sw.WriteLine(ToStringWithIndent("Best scoreX: " + row["scoreX"], tabs));
        sw.WriteLine(ToStringWithIndent("ScoresO: ", tabs));
        sw.Write(ToStringWithIndent("ScoresO: ", tabs));
        foreach(int score in listScoreO)
        {
            sw.Write(score + " ");
        }
        sw.WriteLine();
        sw.WriteLine(ToStringWithIndent("Best scoreO: " + row["scoreO"], tabs));
    }

    private static void PrintWithIndent(string message, int tabs)
    {
        Console.WriteLine(new string('\t', tabs) + message);
    }
    private static string ToStringWithIndent(string message, int tabs)
    {
        return new string('\t', tabs) + message;
    }
    private static bool IsBoardNotFilled(int[][] board)
    {
        for(int i = 0; i < board.Length; i++)
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
                matrix[i][j] = digit;
                input /= 10;
            }
        }

        return matrix;
    }

    private static string MatrixToString(int[][] matrix, int tabs = 0)
    {
        StringBuilder sb = new StringBuilder();
        for(int i = 0; i < 3; i++)
        {
            sb.Append(new string('\t', tabs));
            for(int j = 0; j < 3; j++)
            {
                if(matrix[i][j] == 1)
                {
                    sb.Append("X ");
                }
                else if(matrix[i][j] == 2)
                {
                    sb.Append("O ");
                }
                else
                {
                    sb.Append("  "); // Empty space
                }
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }
    private static void PrintMatrix(int[][] matrix, int tabs = 0)
    {
        for(int i = 0; i < 3; i++)
        {
            Console.Write(new string('\t', tabs));
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