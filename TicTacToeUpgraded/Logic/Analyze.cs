using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeUpgraded.Const;
using TicTacToeUpgraded.Players;

namespace TicTacToeUpgraded.Logic
{
    internal class Analyze
    {
        public static void TryGetCenter()
        {
            if (Checks.CheckPos(1, 1))
            {
                Ai.Move(1, 1);
            }
        }
        public static void Distruct()
        {
            for (int i = 0; i < Ai.horisontal.Length; i++)
            {
                Ai.horisontal[i] = Board.board[Player.pos_x, i];
            }
            for (int i = 0; i < Ai.vertical.Length; i++)
            {
                Ai.vertical[i] = Board.board[i, Player.pos_y];
            }
            for (int i = 0; i < Ai.diagonalRight.Length; i++)
            {
                Ai.diagonalRight[i] = Board.board[i, i];
            }
            for (int i = 0, j = Board.board.GetLength(0) - 1; i < Ai.diagonalLeft.Length; i++, j--)
            {
                Ai.diagonalLeft[i] = Board.board[j, i];
            }
        }

        public static void Do()
        {
            foreach (char item in Ai.horisontal)
            {
                if (item == Signs.Player)
                {
                    Ai.analyze[0] += 1;
                }
            }
            foreach (char item in Ai.vertical)
            {
                if (item == Signs.Player)
                {
                    Ai.analyze[1] += 1;
                }
            }
            foreach (var item in Ai.diagonalRight)
            {
                if (item == Signs.Player)
                {
                    Ai.analyze[2] += 1;
                }
            }
            foreach (var item in Ai.diagonalLeft)
            {
                if (item == Signs.Player)
                {
                    Ai.analyze[3] += 1;
                }
            }
        }

        public static void Decision()
        {
            if (Ai.analyze[2] == 2 && FindFreePos(Ai.diagonalLeft).Item2 && FindFreePos(Ai.diagonalRight).Item2)
            {
                Ai.Move(FindFreePos(Ai.diagonalRight).Item1, FindFreePos(Ai.diagonalLeft).Item1);
                Ai.SetAiMoveStatus(true);
            }
            else if (Ai.analyze[3] == 2 && FindFreePos(Ai.diagonalLeft).Item2 && FindFreePos(Ai.diagonalRight).Item2)
            {
                Ai.Move(FindFreePos(Ai.diagonalLeft).Item1, FindFreePos(Ai.diagonalRight).Item1);
                Ai.SetAiMoveStatus(true);
            }
            else if (Ai.analyze[0] == 2 && Checks.CheckPos(Player.pos_x, FindFreePos(Ai.horisontal).Item1))
            {
                Ai.Move(Player.pos_x, FindFreePos(Ai.horisontal).Item1);
                Ai.SetAiMoveStatus(true);
            }
            else if (Ai.analyze[1] == 2 && Checks.CheckPos(FindFreePos(Ai.vertical).Item1, Player.pos_y))
            {
                Ai.Move(FindFreePos(Ai.vertical).Item1, Player.pos_y);
                Ai.SetAiMoveStatus(true);
            }

        }

        public static (int,bool) FindFreePos(char[] input)
        {
            if (Array.IndexOf(input, Signs.Empty) == -1)
            {
                return (Array.IndexOf(input, Signs.Empty), false);
            }
            else
            {
                return (Array.IndexOf(input, Signs.Empty), true);
            }
        }

        public static void ResetAnalysis()
        {
            for (int i = 0; i < Ai.analyze.Length; i++)
            {
                Ai.analyze[i] = 0;
            }
        }
    }
}
