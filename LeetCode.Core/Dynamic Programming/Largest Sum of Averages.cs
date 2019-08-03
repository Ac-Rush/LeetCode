using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Largest_Sum_of_Averages
    {
        /*
         * 
         * sums[i] means the sum from A[0] to A[i - 1]
            dp[k][i] means the largest sum of averages if we devide the A[0] ... A[i - 1] into k parts
         */
        public double LargestSumOfAverages(int[] A, int K)
        {
            var n = A.Length;
            var dp = new double[K + 1,n +1];
            int[] sums = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                sums[i] = sums[i - 1] + A[i - 1];
            }
            for (int k = 1; k <= K; k++)
            {
                for (int i = k; i <= n; i++)
                {
                    for (int j = k; j <= i; j++)
                    {
                        if (k == 1)
                        {
                            dp[k,i] = (double)sums[i] / i;
                        }
                        else
                        {
                            dp[k,i] = Math.Max(dp[k,i], dp[k - 1,j - 1] + (double)(sums[i] - sums[j - 1]) / (i - j + 1));
                        }
                    }
                }
            }
            return dp[K,n];
        }

    }
}
