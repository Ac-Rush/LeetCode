using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS
{
    class Sudoku_Solver
    {
        public void SolveSudoku(char[][] board)
        {
            var dict = new HashSet<string>();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] != '.')
                    {
                        dict.Add($"r{i}{board[i][j]}"); // row;
                        dict.Add($"c{j}{board[i][j]}"); // col;
                        dict.Add($"z{i / 3}{j / 3}{board[i][j]}"); // zone;
                    }
                }
            }

            Dfs(board, dict);
        }

        private bool Dfs(char[][] board, HashSet<string> set)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] == '.')
                    {
                        for (char c = '1'; c <= '9'; c++)
                        {//trial. Try 1 through 9

                            if (!set.Contains($"r{i}{c}") &&
                                !set.Contains($"c{j}{c}") &&
                                !set.Contains($"z{i / 3}{j / 3}{c}"))
                            {
                                board[i][j] = c; //Put c for this cell
                                set.Add($"r{i}{c}"); // row;
                                set.Add($"c{j}{c}"); // col;
                                set.Add($"z{i / 3}{j / 3}{c}"); // zone;
                                if (Dfs(board, set))
                                    return true; //If it's the solution return true
                                else
                                {
                                    set.Remove($"r{i}{c}"); // row;
                                    set.Remove($"c{j}{c}"); // col;
                                    set.Remove($"z{i / 3}{j / 3}{c}"); // zone;
                                    board[i][j] = '.'; //Otherwise go back
                                }

                            }
                        }

                        return false;
                    }
                }
            }
            return true;
        }
    }
}
