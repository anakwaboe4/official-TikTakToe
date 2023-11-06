using TikTakToe.Core.Enums;
namespace TikTakToe.Engines
{
    public interface IEngine
    {
        public Core.Enums.Engines Engine {  get; }
        public int MakeMove(int move);
        public int SetPos(int position);
        public double Bench();
    }
}
