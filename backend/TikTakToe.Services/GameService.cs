using Microsoft.EntityFrameworkCore;
using TikTakToe.Core.Enums;
using TikTakToe.Engines;
using TikTakToe.Engines.Models.Boards;
using TikTakToe.Engines.Models.Participants;
using TikTakToe.Repositories.EntityFramework;
using TikTakToe.Repositories.Models;

namespace TikTakToe.Services
{
    public class GameService : IGameService
    {
        private readonly TikTakToeContext _tikTakToeDbContext;

        public IEnumerable<IEngine> Participants { get; set; }
        public Board Board { get; set; }

        public GameService(TikTakToeContext tikTakToeContext)
        {
            _tikTakToeDbContext = tikTakToeContext;
            Participants = new List<IEngine>() { new Player(), new Player() };
            Board = new Board();
        }

        public GameItem NewGame(List<Core.Enums.Engines>? engineIds = null, int? lengthX = null, int? lengthY = null)
        {
            if(engineIds == null || !engineIds.Any())
            {
                engineIds = new List<Core.Enums.Engines>()
                {
                    Core.Enums.Engines.Player,
                    Core.Enums.Engines.Player,
                };
            }

            lengthX ??= 3;
            lengthY ??= 3;

            var newGame = new GameItem()
            {
                GridSizeX = lengthX.Value,
                GridSizeY = lengthY.Value,
                Move = 0,
                Engines = engineIds,
                BoardSquares = new Squares[lengthX.Value * lengthY.Value].ToList(),
                Moves = new List<MoveItem>(),
            };

            _tikTakToeDbContext.Games.Add(newGame);

            return newGame;
        }

        public GameItem? GetGame(Guid gameId)
        {
            var game = _tikTakToeDbContext.Games
                .Where(g => g.Id == gameId)
                .Include(g => g.Moves)
                .FirstOrDefault();

            return game;
        }

        public bool CheckMove(int position)
        {
            // Check if int position is valid and if board position is empty
            if(position < Board.BoardSquares.Count() &&
                Board.BoardSquares[position] == Squares.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool MakeMove(int position, Squares square)
        {
            if(CheckMove(position))
            {
                Board.BoardSquares[position] = square;
                Board.Move++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool MakeAiMove(int participant, Squares square)
        {
            var engine = Participants.ElementAt(participant);

            var board = CreateIntBoard(participant);

            var position = engine.SetPos(board);

            return MakeMove(position, square);
        }

        public List<List<Squares>> GetBoard()
        {
            var returnBoard = new List<List<Squares>>();
            for(int x = 0; x < Board.LengthX; x++)
            {
                var row = new List<Squares>();
                for(int y = 0; y < Board.LengthY; y++)
                {
                    row.Add(Board.BoardSquares[x * Board.LengthX + y]);
                }
                returnBoard.Add(row);
            }
            return returnBoard;
        }

        public string PrintBoard()
        {
            string stringBoard = "";
            for(int y = 0; y < Board.LengthY; y++)
            {
                for(int x = 0; x < Board.LengthX; x++)
                {
                    stringBoard += Board.BoardSquares[x + (y * Board.LengthX)] + "\t";
                }
                if(y != Board.LengthY - 1)
                    stringBoard += "\n";
            }
            return stringBoard;
        }

        public override string ToString()
        {
            return PrintBoard() + "\n" + Board.Move + "\n" + Board.LengthX + "\n" + Board.LengthY;
        }

        #region Private Methods
        private IEngine GetEngineFromId(Core.Enums.Engines engineId)
        {
            return engineId switch
            {
                Core.Enums.Engines.Player => new Player(),
                Core.Enums.Engines.PerfectOptemism => new Player(),
                _ => new Player(),
            };
        }

        private int CreateIntBoard(int participant)
        {
            var board = participant * 100000000;

            for(int i = 0, n = 1; i < Board.BoardSquares.Length; i++, n *= 10)
            {
                board += (int)Board.BoardSquares[i] * n;
            }

            return board;
        }
        #endregion
    }
}
