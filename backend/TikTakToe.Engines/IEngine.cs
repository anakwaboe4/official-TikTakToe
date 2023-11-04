namespace TikTakToe.Engines
{
    public interface IEngine
    {
        public int MakeMove(int move);
        public int SetPos(int position);
        public double Bench(int depth);
    }
}
