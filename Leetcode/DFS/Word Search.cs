using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.ArrayS
{
    //DFS solution
    public class Word_Search_my
    {
        public static bool Exist(char[,] board, string word)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (DFS(board, word, 0, i, j)) return true;
                }
            }
            return false;
        }

        private static bool DFS(char[,] board, string word, int index, int r, int c)
        {
            if (index == word.Length )return true;  //先这个判断， 因为如果刚好在边界结尾， 需要这样的判断， 要不然还得特殊处理
            if (r < 0 || c < 0 || r == board.GetLength(0) || c == board.GetLength(1)) return false; //然后再这个判断，
            if (board[r,c] != word[index]) return false;
            board[r,c] ^= (char)256;   // 这样就可以不用走重
            var hasWord = DFS(board, word, index + 1, r - 1, c)|| 
             DFS(board, word, index + 1, r + 1, c)||
             DFS(board, word, index + 1, r, c - 1)||
             DFS(board, word, index + 1, r, c + 1);
            board[r, c] ^= (char)256;  //reset
            return hasWord;
        }
    }
}
