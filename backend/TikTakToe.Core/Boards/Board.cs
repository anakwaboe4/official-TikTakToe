using TikTakToe.Core.Enums;

namespace TikTakToe.Core.Boards
{
    public class Board
    {
        public Squares[] BoardSquares { get; set; }
        public int Score { get; set; } = 0;
        public int Move { get; set; } = 0;
        public int LengthX { get; set; }
        public int LengthY { get; set; }

        public Board()
        {
            LengthX = 3;
            LengthY = 3;
            BoardSquares = new Squares[LengthX * LengthY];
        }

        public Board(int lengthX, int lengthY)
        {
            LengthX = lengthX;
            LengthY = lengthY;
            BoardSquares = new Squares[LengthX * LengthY];
        }

        public bool CheckMove(int position)
        {
            if(BoardSquares[position] == Squares.Empty)
            {
                return true;
            }
            else
                return false;
        }

        public bool MakeMove(int position, Squares move)
        {
            if(BoardSquares[position] == Squares.Empty)
            {
                BoardSquares[position] = move;
                Move++;
                return true;
            }
            else
                return false;
        }

        public int CalculateScore()
        {
            Score = 0;

            return Score;
        }

        public List<List<Squares>> GetBoard()
        {
            var returnBoard = new List<List<Squares>>();
            for(int x = 0; x < LengthX; x++)
            {
                var row = new List<Squares>();
                for(int y = 0; y < LengthY; y++)
                {
                    row.Add(BoardSquares[x + y]);
                }
                returnBoard.Add(row);
            }
            return returnBoard;
        }

        //public Squares[,] GetBoard()
        //{
        //    var returnBoard = new Squares[LengthX, LengthY];
        //    for(int x = 0; x < LengthX; x++)
        //    {
        //        for(int y = 0; y < LengthY; y++)
        //        {
        //            returnBoard[x, y] = BoardSquares[x + y];
        //        }
        //    }
        //    return returnBoard;
        //}

        public string PrintBoard()
        {
            string stringBoard = "";
            for(int y = 0; y < LengthY; y++)
            {
                for(int x = 0; x < LengthX; x++)
                {
                    stringBoard += BoardSquares[x + (y * LengthX)] + "\t";
                }
                if(y != LengthY - 1)
                    stringBoard += "\n";
            }
            return stringBoard;
        }

        public override string ToString()
        {
            return PrintBoard() + "\n" + Score + "\n" + Move + "\n" + LengthX + "\n" + LengthY;
        }
    }
}
