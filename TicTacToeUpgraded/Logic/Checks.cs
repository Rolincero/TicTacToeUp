using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TicTacToeUpgraded.Const;
using TicTacToeUpgraded.Players;

namespace TicTacToeUpgraded.Logic
{
    public class Checks
    {
        public static bool GameProgress = true;
        private static char[,] checker = new char[8, 3];
        private static string Strchecker = " ";
        private static char[] PWinRule = { 'X', 'X', 'X' };
        private static char[] AWinRule = { 'O', 'O', 'O' };

        public static bool BoardIsFull()
        {
            foreach (var item in Board.board)
            {
                if (item == '.')
                {
                    GameProgress = true;
                    return true;
                }
            }
            GameProgress = false;
            return false;
        }

        public static bool CheckPos(int x, int y)
        {
            try
            {
                if (Board.board[x, y] == Signs.Player || Board.board[x, y] == Signs.Ai)
                {
                    return false;
                }
                else if (Board.board[x, y] == Signs.Empty)
                {
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;
            }
        }

        public static (bool, bool) WhoWin()
        {
            DisAssBoard();
            return (PlayerWin(), AiWin());
        }

        private static bool PlayerWin()
        {
            if (Regex.IsMatch(Strchecker, "XXX"))
            {
                return true;
            }
            else 
            { 
                return false;
            }
        }

        private static bool AiWin()
        {
            if (Regex.IsMatch(Strchecker,"OOO"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void DisAssBoard()
        {
            StringReset();
            ForHorizontal();
            ForVertical();
            ForDiagonal();
            ArrayToString();
        }

        private static void ForHorizontal()
        {
            for (int i = 0; i < Board.board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.board.GetLength(1) ; j++)
                {
                    checker[i, j] = Board.board[i, j];
                }
            }
        }

        private static void ForVertical()
        {
            for (int i = 0, k = 3; i < Board.board.GetLength(0); i++, k++)
            {
                for (int j = 0; j < Board.board.GetLength(1); j++)
                {
                    checker[k, j] = Board.board[j, i];
                }
            }
        }

        private static void ForDiagonal()
        {
            for (int i = 0, j = 0; i < Board.board.GetLength(0); i++, j++)
            {
                checker[6, j] = Board.board[i, j];
            }
            for (int i = 0, j = Board.board.GetLength(0) - 1; i < Board.board.GetLength(0); i++, j--)
            {
                checker[7, j] = Board.board[i, j];
            }
        }

        private static void ArrayToString()
        {
            int i = 0;
            foreach (var item in checker)
            {
                i++;
                Strchecker += item;
                if (i % 3 == 0)
                {
                    Strchecker += " ";
                }
            }
            i = 0;
        }

        private static void StringReset() => Strchecker = "";
        public static void PWinMsg() => Console.WriteLine("\nПобедил Игрок!");
        public static void AWinMsg() => Console.WriteLine("\nПобедил Компьютер!");
    }
}
