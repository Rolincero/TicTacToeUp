using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TicTacToeUpgraded.Const;
using TicTacToeUpgraded.Logic;

namespace TicTacToeUpgraded.Players
{
    internal class Ai
    {
        public static char[] horisontal = new char[Board.board.GetLength(0)];
        public static char[] vertical = new char[Board.board.GetLength(1)];
        public static char[] diagonalRight = new char[Board.board.GetLength(0)];
        public static char[] diagonalLeft = new char[Board.board.GetLength(0)];
        public static int[] analyze = new int[4];
        private static Random random = new Random();
        private static bool AiMoveStatus = false;

        public static bool SetAiMoveStatus(bool input) => AiMoveStatus = input;

        public static void Think()
        {
            Analyze.ResetAnalysis();
            Analyze.Distruct();
            Analyze.Do();
            Analyze.Decision();
            if (!AiMoveStatus)
            {
                RndMove();
            }
        }

        public static void Move(int x, int y)
        {
            if (Checks.BoardIsFull())
            {
                if (Checks.CheckPos(x, y))
                {
                    try
                    {
                        Board.board[x, y] = Signs.Ai;
                        SetAiMoveStatus(true);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.StackTrace);
                    }
                }
                else
                {
                    Think();
                }
            }
            else Checks.BoardIsFull();
        }

        private static void RndMove()
        {
            int x = random.Next(0, Board.board.GetLength(0));
            Thread.Sleep(10);
            int y = random.Next(0, Board.board.GetLength(1));
            Move(x, y);
        }
    }
}
