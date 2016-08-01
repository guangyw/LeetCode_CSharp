using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class GameOfLife
    {
        public static void NextBoard(int[,] board)
        {

            for (var i = 0; i < board.GetLength(0); i++)
            {
                for (var j = 0; j < board.GetLength(1); j++)
                {
                    var numOfNeighbors = NumOfLiveNeighbors(i, j, board);
                    if (numOfNeighbors == 3)
                    {
                        board[i, j] |= 2;
                    }

                    if (numOfNeighbors == 2 && (board[i, j] & 1) != 0)
                    {
                        board[i, j] |= 2;
                    }
                }
            }

            for (var i = 0; i < board.GetLength(0); i++)
            {
                for (var j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] >>= 1;
                }
            }

        }

        public static int NumOfLiveNeighbors(int x, int y, int[,] board)
        {
            var count = 0;
            for (var i = x - 1; i <= x + 1; i++)
            {
                for (var j = y - 1; j <= y + 1; j++)
                {
                    if (i < 0 || j < 0 || i >= board.GetLength(0) || j >= board.GetLength(1))
                    {
                        continue;
                    }
                    count += board[i, j] & 1;
                }
            }

            count -= board[x, y] & 1;

            return count;

        }
    }
}
