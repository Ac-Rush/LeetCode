﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    /// <summary>
    /// https://leetcode.com/problems/maximum-length-of-pair-chain/description/
    /*
     You are given n pairs of numbers. In every pair, the first number is always smaller than the second number.

Now, we define a pair (c, d) can follow another pair (a, b) if and only if b < c. Chain of pairs can be formed in this fashion.

Given a set of pairs, find the length longest chain which can be formed. You needn't use up all the given pairs. You can select pairs in any order.

Example 1:
Input: [[1,2], [2,3], [3,4]]
Output: 2
Explanation: The longest chain is [1,2] -> [3,4]
Note:
The number of given pairs will be in the range [1, 1000].
    */
    /// </summary>
    class Maximum_Length_of_Pair_Chain
    {

        public int FindLongestChain(int[,] pairs)
        {
            /*
            var res = pairs;
            int N = pairs.GetLength(0);
            int[] dp = new int[N];
            for (var index = 0; index < dp.Length; index++)
            {
                dp[index] = 1;
            }

            for (int j = 1; j < N; ++j)
            {
                for (int i = 0; i < j; ++i)
                {
                    if (res[i, 1] < res[j, 0])
                        dp[j] = Math.Max(dp[j], dp[i] + 1);
                }
            }

            return dp.Max();

    */

            System.Array.Sort<int[]>(pairs, (a, b) => a[0] - b[0]);
            int N = pairs.length;
            int[] dp = new int[N];
            Arrays.fill(dp, 1);

            for (int j = 1; j < N; ++j)
            {
                for (int i = 0; i < j; ++i)
                {
                    if (pairs[i][1] < pairs[j][0])
                        dp[j] = Math.max(dp[j], dp[i] + 1);
                }
            }

            int ans = 0;
            for (int x: dp) if (x > ans) ans = x;
            return ans;
        }
    }

    public static class MyEnumerableExtension
    {
        public static IEnumerable AsEnumerable(this int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            for (int j = 0; j < arr.GetLength(1); j++)
                yield return arr[i, j];
        }

    }
}