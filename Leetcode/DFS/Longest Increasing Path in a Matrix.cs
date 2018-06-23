using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.DFS_BFS
{
    using System;
    /// <summary>
    /// good my solution
    /// </summary>
    public class Longest_Increasing_Path_in_a_Matrix2
    {
        /// <summary>
        /// memorization
        /// </summary>
        public static int[,] dirs = { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };

       
        public static int LongestIncreasingPath(int[,] matrix)
        {
            var max = 0;
            var meno = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    meno[i, j] = -1;
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    max = Math.Max(max, Dfs(meno, matrix, i, j));
                }
            }
            return max;
        }

        private static int Dfs(int[,] memo, int[,] matrix, int r, int c)
        {
            if (memo[r, c] != -1)
            {
                return memo[r, c];
            }
            var len = 0;
            for (int i = 0; i < dirs.GetLength(0); i++)
            {
                var rr = r + dirs[i, 0];
                var cc = c + dirs[i, 1];
                if (0 <= rr && rr < matrix.GetLength(0)
                    && 0 <= cc && cc < matrix.GetLength(1)
                    && matrix[r, c] > matrix[rr, cc])
                {
                    len = Math.Max(len, Dfs(memo,matrix, rr, cc));
                }
            }
            memo[r, c] = len + 1; 
            return memo[r, c];
        }
    }

    public  class Longest_Increasing_Path_in_a_Matrix
    {
        /// <summary>
        /// Time Limit Exceeded
        /// </summary>
        public static  int[,] dirs = { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };
        public static int LongestIncreasingPath(int[,] matrix)
        {
            var max = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    max = Math.Max(max, Dfs(matrix, i, j));
                }
            }
            return max;
        }

        private static int Dfs(int[,] matrix, int r, int c)
        {
            var len = 0;
            for (int i = 0; i < dirs.GetLength(0); i++)
            {
                var rr = r + dirs[i, 0];
                var cc = c + dirs[i, 1];
                if (0 <=rr &&rr < matrix.GetLength(0)
                    && 0 <=cc && cc < matrix.GetLength(1)
                    && matrix[r,c] >matrix[rr , cc ] )
                {
                    len = Math.Max(len, Dfs(matrix, rr, cc));
                }
            }
            return len + 1; //bug  was len++
        }
    }
}
