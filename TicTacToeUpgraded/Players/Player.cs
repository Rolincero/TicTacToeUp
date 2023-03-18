using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using TicTacToeUpgraded.Const;
using TicTacToeUpgraded.Logic;

namespace TicTacToeUpgraded.Players
{
    public class Player
    {
        public static int pos_x;
        public static int pos_y;

        private void SetSign(int x, int y)
        {
            try
            {
                Board.board[x, y] = Signs.Player;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Такое значение вне игрового поля!");
                Console.WriteLine(ex.StackTrace);
                Move();
            }
        }

        public void Move()
        {
            Console.Write("\nВведите X и Y координату через пробел: ");
            try
            {
                string inp = Console.ReadLine();
                string[] res = inp.Split(' ');
                pos_x = int.Parse(res[0]) - 1;
                pos_y = int.Parse(res[1]) - 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (Checks.CheckPos(pos_x, pos_y))
            {
                SetSign(pos_x, pos_y);
            }
            else
            {
                Move();
            }
        }
    }
}
