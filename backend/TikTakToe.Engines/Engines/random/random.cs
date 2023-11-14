using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TikTakToe.Core.Boards;

namespace TikTakToe.Engines.Engines.random
{
    public class random : IEngine
    {
        public Core.Enums.Engines Engine => Core.Enums.Engines.Random;

        private int board;
        private Random randomPicker = new Random();

        public double Bench()
        {
            return randomPicker.NextDouble();
        }

        public int MakeMove(int move)
        {
            board = Domove(board, move);
            List<int> legalMoves = new List<int>();
            for(int i = 1; i <= 9; i++)
            {
                if(Domove(board, i) != 0)
                {
                    legalMoves.Add(i);
                }
            }  
            int index = randomPicker.Next(legalMoves.Count);
            return legalMoves[index];
        }

        public int SetPos(int position)
        {
            board = position;
            List<int> legalMoves = new List<int>();
            for(int i = 1; i <= 9; i++)
            {
                if(Domove(board, i) != 0)
                {
                    legalMoves.Add(i);
                }
            }
            int index = randomPicker.Next(legalMoves.Count);
            return legalMoves[index];
        }

        private int Domove(int board, int move)
        {
            int player = (int)(board / 1000000000) + 1;
            int positionValue = (int)Math.Pow(10, move - 1);
            int digit = (board / positionValue) % 10;

            if(digit == 0)
            {
                board += player * positionValue;
            }
            else
            {
                return 0;
            }
            if(player == 1) board += 1000000;
            else board -= 1000000;
            return board;
        }
    }
}
