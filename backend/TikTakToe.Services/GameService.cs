using TikTakToe.Core.Boards;
using TikTakToe.Core.Enums;
using TikTakToe.Core.Participants;
using TikTakToe.Engines;

namespace TikTakToe.Services
{
    public class GameService : IGameService
    {
        public List<IEngine> Participants { get; set; }
        public Board Board { get; set; }

        public GameService()
        {
            Participants = new List<IEngine>() { new Player(), new Player() };
            Board = new Board();
        }

        public void NewGame()
        {
            Participants = new List<IEngine>() { new Player(), new Player() };
            Board = new Board();
        }

        public void NewGame(List<IEngine> participants, Board board)
        {
            Participants = participants;
            Board = board;
        }

        public bool CheckMove(int position)
        {
            if (position < Board.BoardSquares.Count() &&
                Board.BoardSquares[position] == Squares.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool MakeMove(int position, Squares move)
        {
            if (CheckMove(position))
            {
                Board.BoardSquares[position] = move;
                Board.Move++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool MakeAiMove(int position, Squares move)
        {
            throw new NotImplementedException();
        }

        public int CalculateScore()
        {
            Board.Score = 0;

            return Board.Score;
        }

        public List<List<Squares>> GetBoard()
        {
            var returnBoard = new List<List<Squares>>();
            for (int x = 0; x < Board.LengthX; x++)
            {
                var row = new List<Squares>();
                for (int y = 0; y < Board.LengthY; y++)
                {
                    row.Add(Board.BoardSquares[x + y]);
                }
                returnBoard.Add(row);
            }
            return returnBoard;
        }

        public string PrintBoard()
        {
            string stringBoard = "";
            for (int y = 0; y < Board.LengthY; y++)
            {
                for (int x = 0; x < Board.LengthX; x++)
                {
                    stringBoard += Board.BoardSquares[x + (y * Board.LengthX)] + "\t";
                }
                if (y != Board.LengthY - 1)
                    stringBoard += "\n";
            }
            return stringBoard;
        }

        public override string ToString()
        {
            return PrintBoard() + "\n" + Board.Score + "\n" + Board.Move + "\n" + Board.LengthX + "\n" + Board.LengthY;
        }
    }
}
