using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BackTrack
{
    /// <summary>
    /// 用 hash 节省了 一维的时间复杂度
    /// 存了 列， 对角线，反对角线 号
    /// </summary>
    class N_Queens_II
    {
        private int count = 0;
        public int TotalNQueens(int n)
        {
            dfs(new int[n], 0, new HashSet<int>());
            return count;
        }
        private  void dfs( int[] result, int row, HashSet<int> visited )
        {
            if (row == result.Length)
            {
                count++;
                return;
            }

            for (int i = 0; i < result.Length; i++)
            {
                var diagonal1 = i + row + result.Length*2;
                var diagonal2 = row - i + result.Length*5;
                if (visited.Contains(i) || visited.Contains(diagonal1) || visited.Contains(diagonal2)) continue;
                result[row] = i; //用 array 就不用 remove 这样不错

                visited.Add(i);
                visited.Add(diagonal1);
                visited.Add(diagonal2);
                dfs(result, row + 1, visited);
                visited.Remove(i);
                visited.Remove(diagonal1);
                visited.Remove(diagonal2);
            }
        }
    }


    class N_Queens_II_2
    {
        private int count = 0;
        public int TotalNQueens(int n)
        {
            dfs(new int[n], 0);
            return count;
        }
        private void dfs(int[] result, int row)
        {
            if (row == result.Length)
            {
                count++;
                return;
            }

            for (int i = 0; i < result.Length; i++)
            {
                bool bAvail = true;
                for (int j = 0; j < row; j++)
                    if (result[j] == i || Math.Abs(result[j] - i) == row - j) bAvail = false;
                if (bAvail)
                {
                    result[row] = i;  //用 array 就不用 remove 这样不错
                    dfs(result, row + 1);
                }
            }
        }
    }
}
