using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeUpgraded.Const;

namespace TicTacToeUpgraded
{
    public class Board
    {
        public static char[,] board = new char[BoardParam.GetSizeX(), BoardParam.GetSizeY()];
        public void Init()
        {
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        board[i, j] = Signs.Empty;
                    }
                }
        }
        public void Show()
        {
            Console.Clear();
            int i = 0;
            foreach (var item in board)
            {
                if (i % board.GetLength(0) == 0 && i != 0)
                {
                    Console.WriteLine();
                }
                ++i;
                Console.Write(item);
            }
        }
    }
}
