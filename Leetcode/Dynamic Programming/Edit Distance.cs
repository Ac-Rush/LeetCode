using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Edit_Distance
    {
        /// <summary>
        /// my solution
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public int MinDistance(string word1, string word2)
        {
            if (string.IsNullOrEmpty(word1) && string.IsNullOrEmpty(word2))
            {
                return 0;
            }
            if (string.IsNullOrEmpty(word1) )
            {
                return word2.Length;
            }
            if (string.IsNullOrEmpty(word2))
            {
                return word1.Length;
            }
            var l1 = word1.Length;
            var l2 = word2.Length;
            var dp = new int[l1 + 1, l2 + 1];
            for (int i = 1; i <= l1; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + 1;
            }
            for (int i = 1; i <= l2; i++)
            {
                dp[0, i] = dp[0, i -1] + 1;
            }
            for (int i = 1; i <= l1; i++)
            {
                for (int j = 1; j <= l2; j++)
                {
                    if (word1[i -1] == word2[j -1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]) , dp[i - 1, j - 1]) + 1;
                    }
                } 
            }
            return dp[l1, l2];
        }



        /// <summary>
        ///  O（N）的空间复杂度
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public int MinDistance2(string word1, string word2)
        {
            if (string.IsNullOrEmpty(word1) && string.IsNullOrEmpty(word2))
            {
                return 0;
            }
            if (string.IsNullOrEmpty(word1))
            {
                return word2.Length;
            }
            if (string.IsNullOrEmpty(word2))
            {
                return word1.Length;
            }
            var l1 = word1.Length;
            var l2 = word2.Length;
            var dp = new int[l2 + 1];
            for (int i = 1; i <= l2; i++)
            {
                dp[i] = i;
            }
            for (int i = 1; i <= l1; i++)
            {
                int prev = i;
                for (int j = 1; j <= l2; j++)
                {
                    int cur;
                    if (word1[i - 1] == word2[j - 1])
                    {
                        cur = dp[j - 1];
                    }
                    else
                    {
                        cur = Math.Min(Math.Min(prev, dp[j - 1]), dp[j]) + 1;
                    }
                    dp[j - 1] = prev;    //不能 override 了 dp[j], 用prev来存当前的; 
                    prev = cur;
                }
                dp[l2] = prev;
            }
            return dp[l2];
        }
    }
}
