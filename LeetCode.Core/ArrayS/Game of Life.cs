using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Array
{

    /*
     * 
     * 
     *下面这样更好   board[i][j] >>= 1;  // Get the 2nd state.
    - 00  dead (next) <- dead (current)
    - 01  dead (next) <- live (current)  
    - 10  live (next) <- dead (current)  
    - 11  live (next) <- live (current) 
    */
    /// <summary>
    /// my solution
    /// </summary>
    class Game_of_Life
    {
        public void GameOfLife(int[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    var count = GetLiveNeighbors(board, i, j);
                    if (board[i][j] == 1)
                    {
                        if (count >= 2 && count <= 3)
                        {
                            board[i][j] = 3;  // Make the 2nd bit 1: 01 ---> 11
                        }
                    }
                    else
                    {
                        if (count == 3)
                        {
                            board[i][j] = 2; // Make the 2nd bit 1: 00 ---> 10
                        }
                    }
                }
            }
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    board[i][j] >>= 1;  // Get the 2nd state.
                }
            }
        }


        private int GetLiveNeighbors(int[][] board, int x, int y)
        {
            var count = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if(i == 0 && j == 0) continue;
                    var xx = i + x;
                    var yy = j + y;
                    if (xx >= 0 && xx < board.Length && yy >= 0 && yy < board[xx].Length)
                    {
                            if ((board[xx][yy] & 1) == 1)
                            {
                                count ++;
                            }
                    }
                }
            }
            return count;
        }
    }

    /// <summary>
    /// easy 我的解决方案，并不难
    /// </summary>
    class Game_of_Life_My
    {
        public void GameOfLife(int[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    var count = GetOtherNeighbors(board, i, j);
                    if (board[i][j] == 1)
                    {
                        if (count < 2 || count > 3)
                        {
                            board[i][j] = -1;
                        }
                    }
                    else
                    {
                        if (count == 3)
                        {
                            board[i][j] = 2;
                        }
                    }
                }
            }
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == -1)
                    {
                        board[i][j] = 0;
                    }
                    if (board[i][j] == 2)
                    {
                        board[i][j] = 1;
                    }
                }
            }
        }


        private int GetOtherNeighbors(int[][] board, int x, int y)
        {
            // 0  : die
            // 1 : live
            // 2 : die to live;
            // -1 : live to die
            var count = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;
                    var xx = i + x;
                    var yy = j + y;
                    if (xx >= 0 && xx < board.Length && yy >= 0 && yy < board[xx].Length)
                    {
                        if (Math.Abs(board[xx][yy]) == 1)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }
    }
}
