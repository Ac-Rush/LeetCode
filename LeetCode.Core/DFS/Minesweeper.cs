using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS
{
    class Minesweeper
    {
        public char[,] UpdateBoard(char[,] board, int[] click)
        {
            int m = board.GetLength(0), n = board.GetLength(1);
            int row = click[0], col = click[1];

            if (board[row,col] == 'M')
            { // Mine
                board[row,col] = 'X';
            }
            else
            { // Empty
              // Get number of mines first.
                int count = 0;
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        if (i == 0 && j == 0) continue;
                        int r = row + i, c = col + j;
                        if (r < 0 || r >= m || c < 0 || c < 0 || c >= n) continue;
                        if (board[r,c] == 'M' || board[r,c] == 'X') count++;
                    }
                }

                if (count > 0)
                { // If it is not a 'B', stop further DFS.
                    board[row,col] = (char)(count + '0');
                }
                else
                { // Continue DFS to adjacent cells.
                    board[row,col] = 'B';
                    for (int i = -1; i < 2; i++)
                    {
                        for (int j = -1; j < 2; j++)
                        {
                            if (i == 0 && j == 0) continue;
                            int r = row + i, c = col + j;
                            if (r < 0 || r >= m || c < 0 || c < 0 || c >= n) continue;
                            if (board[r,c] == 'E') UpdateBoard(board, new int[] { r, c });
                        }
                    }
                }
            }

            return board;
        }

       
    }
}
