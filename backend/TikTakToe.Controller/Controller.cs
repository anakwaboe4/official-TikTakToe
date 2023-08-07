using TikTakToe.Core.Boards;
using TikTakToe.Core.Participants;

namespace TikTakToe.Controller
{
    public class Controller
    {
        public List<Participant> Participants { get; set; }
        public Board Board { get; set; }

        public Controller()
        {
            Participants = new List<Participant>() { new Player(), new Player() };
            Board = new Board();
        }

        public Controller(List<Participant> participants, Board board)
        {
            Participants = participants;
            Board = board;
        }
    }
}
