using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeUpgraded.Const;
using TicTacToeUpgraded.Players;

namespace TicTacToeUpgraded.Logic
{
    public class Checks
    {
        public static bool BoardIsFull()
        {
            foreach (var item in Board.board)
            {
                if (item == '.')
                {
                    return true;
                }
            }
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

        public static void PlayerWin()
        {
            if (Ai.analyze[0] == 3 || Ai.analyze[1] == 3 || Ai.analyze[2] == 3 || Ai.analyze[3] == 3)
            {
                Console.WriteLine("Player WIN!");
            }
        }
    }
}
