namespace TikTakToe.Engines
{
    public interface IEngine
    {
        public Core.Enums.Engines Engine {  get; }
        public int MakeMove(int move);
        public int SetPos(int position);
        public double Bench(int depth);
    }

    public class Engine
    {
        /*public static IEngine GetEngine(Core.Enums.Engines engine)
        {
            return engine switch
            {
                Core.Enums.Engines.Player => new Player(),
                Core.Enums.Engines.PerfectOptemism => new PerfectOptemism(),
                _ => null,
            };
        }*/
    }
}
