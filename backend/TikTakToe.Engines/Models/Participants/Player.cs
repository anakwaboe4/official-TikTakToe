namespace TikTakToe.Engines.Models.Participants
{
    public class Player : IEngine
    {
        public Core.Enums.Engines Engine => Core.Enums.Engines.Player;

        public int MakeMove(int move)
        {
            throw new NotImplementedException();
        }
        public int SetPos(int position)
        {
            throw new NotImplementedException();
        }
        public double Bench(int depth)
        {
            throw new NotImplementedException();
        }
    }
}
