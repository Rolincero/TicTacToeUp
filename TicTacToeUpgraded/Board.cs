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
        public void Init()
        {
            for (int i = 0; i < BoardParam.board.GetLength(0); i++)
            {
                for (int j = 0; j < BoardParam.board.GetLength(1); j++)
                {
                    BoardParam.board[i, j] = Signs.Empty;
                }
            }
        }
    }
}
