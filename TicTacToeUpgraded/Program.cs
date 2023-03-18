using System;
using System.Linq;
using System.Collections.Generic;
using TicTacToeUpgraded;
using TicTacToeUpgraded.Logic;

namespace Game
{
    class Program
    {
        static void Main() 
        {
            Board board = new Board();
            Player player = new Player();

            board.Init();

            do
            {
                board.Show();
                player.Move();
                board.Show();
            } while (Checks.BoardIsFull());


            
        }
    }
}