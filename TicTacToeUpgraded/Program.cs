﻿using System;
using System.Linq;
using System.Collections.Generic;
using TicTacToeUpgraded;

namespace Game
{
    class Program
    {
        static void Main() 
        {
            Board board = new Board();

            board.Init();
            board.Show();
            
        }
    }
}