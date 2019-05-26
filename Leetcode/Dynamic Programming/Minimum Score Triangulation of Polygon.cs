using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Minimum_Score_Triangulation_of_Polygon_Dp
    {
        public int MinScoreTriangulation(int[] A)
        {
            var n = A.Length;
            var dp = new int[n, n];
            for (int d = 2; d < n; ++d) //d就是区间距离
            {
                for (int i = 0; i + d < n; ++i) //i就是 start
                {
                    int j = i + d;  //j就是end
                    dp[i,j] = int.MaxValue;
                    for (int k = i + 1; k < j; ++k) // 跟memo类似，k就是 i的下一个到 j的上一个
                        dp[i,j] = Math.Min(dp[i,j], dp[i,k] + dp[k,j] + A[i] * A[j] * A[k]);
                }
            }
            return dp[0, n - 1];
        }
    }


    /// <summary>
    /// 通过
    /// </summary>
    class Minimum_Score_Triangulation_of_Polygon_Memo
    {
        private Dictionary<Tuple<int, int>, int> memo = new Dictionary<Tuple<int, int>, int>();
        public int MinScoreTriangulation(int[] A)
        {
            return Helper(A, 0, A.Length - 1);
        }

        private int Helper(int[] A, int start, int end)
        {
            if(memo.ContainsKey(new Tuple<int,int>(start,end)))
            {
                return memo[new Tuple<int, int>(start, end)];
            }
            if (end < start + 2) return 0;
            if (end == start + 2)
            {
                return A[start] * A[start + 1] * A[end];
            }

            var min = int.MaxValue;
            var first = A[start];
            var last = A[end];
            for (int i = start + 1; i <= end - 1; i++)
            {
                min = Math.Min(min, first * last * A[i] + Helper(A, start, i) + Helper(A, i, end));
            }
            memo[new Tuple<int, int>(start, end)] = min;
            return min;
        }
    }

    /// <summary>
    ///回溯，超时
    /// </summary>
    class Minimum_Score_Triangulation_of_Polygon
    {
        public int MinScoreTriangulation(int[] A)
        {
            return Helper(A, 0, A.Length-1);
        }

        private int Helper(int[] A, int start, int end)
        {
            if (end < start + 2) return 0;
            if(end == start + 2)
            {
                return A[start] * A[start + 1] * A[end];
            }

            var min = int.MaxValue;
            var first = A[start];
            var last = A[end];
            for (int i = start +1; i <= end-1; i++)
            {
                min = Math.Min(min, first * last * A[i] + Helper(A, start, i) + Helper(A, i, end));
            }
            return min;
        }
    }
}
