using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.HashTable
{
    class Valid_Sudoku
    {
        public bool IsValidSudoku(char[,] board)
        {
            var set = new HashSet<string>();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] != '.')
                    {
                        //hashset + 自编码 去重 判重
                        if (!set.Add($"R {i} {board[i, j]}") ||
                            !set.Add($"C {j} {board[i, j]}") ||
                            !set.Add($"B {i/3} {j/3} {board[i, j]}"))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
