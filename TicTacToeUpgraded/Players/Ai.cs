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
        private static char[] horisontal = new char[Board.board.GetLength(0)];
        private static char[] vertical = new char[Board.board.GetLength(1)];
        private static char[] diagonalRight = new char[Board.board.GetLength(0)];
        private static char[] diagonalLeft = new char[Board.board.GetLength(0)];
        private static int[] analyze = new int[4];
        private static Random random = new Random();
        private static bool AiMoveStatus = false;

        public static bool SetAiMoveStatus(bool input) => AiMoveStatus = input;

        public void Think()
        {
            ResetAnalysis();
            Distruct();
            Analyze();
            Decision();
            if (!AiMoveStatus)
            {
                RndMove();
            }
        }

        private void Move(int x, int y)
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

        private void RndMove()
        {
            int x = random.Next(0, Board.board.GetLength(0));
            Thread.Sleep(10);
            int y = random.Next(0, Board.board.GetLength(1));
            if (Checks.CheckPos(x, y))
            {
                Move(x, y);
            }
            else Think();
        }

        private void Distruct()
        {
            for (int i = 0; i < horisontal.Length; i++)
            {
                horisontal[i] = Board.board[Player.pos_x, i];
            }
            for (int i = 0; i < vertical.Length; i++)
            {
                vertical[i] = Board.board[i, Player.pos_y];
            }
            if (Player.pos_x == Player.pos_y)
            {
                for (int i = 0; i < diagonalRight.Length; i++)
                {
                    diagonalRight[i] = Board.board[i, i];
                }
                for (int i = 0, j = Board.board.GetLength(0) - 1; i < diagonalLeft.Length; i++, j--)
                {
                    diagonalLeft[i] = Board.board[i, j];
                }
            }
        }

        private void Analyze()
        {
            foreach (char item in horisontal)
            {
                if (item == Signs.Player)
                {
                    analyze[0] += 1;
                }
            }
            foreach (char item in vertical)
            {
                if (item == Signs.Player)
                {
                    analyze[1] += 1;
                }
            }
            foreach (var item in diagonalRight)
            {
                if (item == Signs.Player)
                {
                    analyze[2] += 1;
                }
            }
            foreach (var item in diagonalLeft)
            {
                if (item == Signs.Player)
                {
                    analyze[3] += 1;
                }
            }
        }

        private void Decision()
        {
                if (analyze[2] == 2)
                {
                    //Move(Player.pos_x, FindFreePos(diagonalRight));
                    SetAiMoveStatus(true);
                }
                else if (analyze[3] == 2)
                {

                    SetAiMoveStatus(true);
                }
                else if (analyze[0] == 2)
                {
                    Move(Player.pos_x, FindFreePos(horisontal));
                    SetAiMoveStatus(true);
                }
                else if (analyze[1] == 2)
                {
                    Move(FindFreePos(vertical), Player.pos_y);
                    SetAiMoveStatus(true);
                }

        }

        private int FindFreePos(char[] input) => Array.IndexOf(input, Signs.Empty);
        private void ResetAnalysis()
        {
            for (int i = 0; i < analyze.Length; i++)
            {
                analyze[i] = 0;
            }
        }
    }
}
