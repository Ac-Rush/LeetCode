using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Maximum_Length_of_Repeated_Subarray
    {
        /**
 * dp[i][j] = a[i] == b[j] ? 1 + dp[i + 1][j + 1] : 0;
 * dp[i][j] : max lenth of common subarray start at a[i] & b[j];
 */
        //这个是倒过来做，优化成了一维
        public int FindLength(int[] a, int[] b)
        {
            int m = a.Length, n = b.Length;
            if (m == 0 || n == 0) return 0;
            int[] dp = new int[n + 1];
            int max = 0;
            for (int i = m - 1; i >= 0; i--)
            for (int j = 0; j < n; j++)
                max = Math.Max(max, dp[j] = a[i] == b[j] ? 1 + dp[j + 1] : 0);
            return max;
        }

        /// <summary>
        /// 这个看着比较明了
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public int findLength1(int[] A, int[] B)
        {
            if (A == null || B == null) return 0;
            int m = A.Length;
            int n = B.Length;
            int max = 0;
            //dp[i][j] is the length of longest common subarray ending with nums[i] and nums[j]
            int[,] dp = new int[m + 1,n + 1];
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i,j] = 0;
                    }
                    else
                    {
                        if (A[i - 1] == B[j - 1])
                        {
                            dp[i,j] = 1 + dp[i - 1,j - 1];
                            max = Math.Max(max, dp[i,j]);
                        }
                    }
                }
            }
            return max;
        }


        /// <summary>
        /// 这个优化成了 一维
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public int findLength2(int[] A, int[] B)
        {
            if (A == null || B == null) return 0;
            int m = A.Length;
            int n = B.Length;
            int max = 0;
            //dp[i][j] is the length of longest common subarray ending with nums[i] and nums[j]
            int[] dp = new int[ n + 1];
            for (int i = 1; i <= m; i++)
            {
                var temp = new int[n + 1];
                for (int j = 1; j <= n; j++)
                {
                        if (A[i - 1] == B[j - 1])
                        {
                            temp[j] = 1 + dp[j-1];
                            max = Math.Max(max, temp[j]);
                        }
                }
                dp = temp;
            }
            return max;
        }
    }
}
