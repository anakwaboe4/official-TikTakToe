// This is to manually test the Engines without needing to use the API
using System.Runtime.CompilerServices;
using TikTakToe.Engines;

internal class Program
{
   
    private static void Main(string[] args)
    {
        string input = "1 121 102 001"; // Example input string
        int[][] board = StringToMatrix(input);

        // Print the resulting Tic-Tac-Toe board
        PrintMatrix(board);
    //    IEngine engine = new TikTakToe.Engines.Engines.random.random(); // create a IEngine with the class you would like to test
    //    while(true)
    //    {
    //        Console.WriteLine("1 for move test, 2 for board test and 3 for benchtesting");
    //        switch(Int32.Parse(Console.ReadLine()))
    //        {
    //            case 1:

    //                break;
    //            case 2:

    //                break;
    //            case 3:
    //                Console.WriteLine(engine.Bench());
    //                break;
    //        }
    //    }
    //}
    private static int[][] StringToMatrix(string input)
    {
        string[] rows = input.Split(' ');

        int[][] matrix = new int[3][];
        for(int i = 0; i < 3; i++)
        {
            matrix[i] = new int[3];
            char[] chars = rows[i + 1].ToCharArray();

            for(int j = 0; j < 3; j++)
            {
                if(chars[j] == '1')
                {
                    matrix[i][j] = 1; // '1' represents 'X'
                }
                else if(chars[j] == '2')
                {
                    matrix[i][j] = 2; // '2' represents 'O'
                }
                else
                {
                    matrix[i][j] = 0; // '0' represents an empty space
                }
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

}