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
        public static bool GameProgress = true;
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

        public static void WhoWin()
        {
            PlayerWin();
            AiWin();
        }

        private static void PlayerWin()
        {
            
        }

        private static void AiWin()
        {

        }
    }
}
