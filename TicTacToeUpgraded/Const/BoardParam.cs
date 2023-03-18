using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeUpgraded.Const
{
    public class BoardParam
    {
        private static int sizeX = 3;
        private static int sizeY = 3;

        public void ChangeSize(int input) => sizeX = sizeY = input;
        public static int GetSizeX() => sizeX;
        public static int GetSizeY() => sizeY;
    }
}
