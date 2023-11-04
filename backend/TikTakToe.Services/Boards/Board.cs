using TikTakToe.Core.Enums;

namespace TikTakToe.Core.Boards
{
    public class Board
    {
        public Squares[] BoardSquares { get; set; }
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
    }
}
