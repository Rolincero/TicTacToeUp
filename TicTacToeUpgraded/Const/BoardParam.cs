using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeUpgraded.Const
{
    public class BoardParam
    {
        public static char[,] board = new char[_sizeX, _sizeY];
        private const int _sizeX = 3;
        private const int _sizeY = 3;
    }
}
