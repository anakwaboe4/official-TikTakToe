﻿using TikTakToe.Engines;

namespace TikTakToe.Core.Participants
{
    public class Player : IEngine
    {
        public Enums.Engines Engine => Enums.Engines.Player;

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