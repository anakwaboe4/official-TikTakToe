using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTakToe.Engines.Engines.maxOdds
{
    internal class maxOdds: IEngine
    {
        public Core.Enums.Engines Engine => Core.Enums.Engines.MaxOdds;
    
          public double Bench(int depth)
          {
              throw new NotImplementedException();
          }
            public int[,] MakeMove(int[,] board, int nextPlayer, int depth = 0)
            {
                throw new NotImplementedException();
            }

            private int EvaluateBoard(int[,] board)
            {
                throw new NotImplementedException();
            }

    }
}
