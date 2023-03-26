using System;
using System.Linq;
using System.Collections.Generic;
using TicTacToeUpgraded;
using TicTacToeUpgraded.Logic;
using TicTacToeUpgraded.Players;

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
                if (Checks.WhoWin().Item1)
                {
                    board.Show();
                    Checks.PWinMsg();
                    Console.ReadKey();
                    break;
                }
                board.Show();
                Ai.Think();
                if (Checks.WhoWin().Item2)
                {
                    board.Show();
                    Checks.AWinMsg();
                    Console.ReadKey();
                    break;
                }
                Ai.SetAiMoveStatus(false);
            } while (Checks.GameProgress);
            if (!Checks.BoardIsFull())
            {
                Console.WriteLine("\nНичья!");
                Console.ReadKey();
            }
        }
    }
}