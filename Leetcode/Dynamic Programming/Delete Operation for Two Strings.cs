using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Delete_Operation_for_Two_Strings
    {
        /// <summary>
        /// d'p 空间优化
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public int MinDistanceDpOpt(string word1, string word2)
        {
            var dp = new int[word2.Length + 1];
            for (int i = 0; i < word1.Length; i++)
            {
                var prev = 0;
                for (int j = 0; j < word2.Length; j++)
                {
                    var cur = 0;  
                    if (word1[i] == word2[j])
                    {
                        cur = prev + 1;
                    }
                    else
                    {
                        cur = Math.Max(dp[ j], dp[ j + 1]);
                    }
                    prev = dp[j + 1];
                    dp[j + 1] = cur;  // 有化成 1D 记录 prev 左上角元素
                }
            }

            return word1.Length + word2.Length - 2 * dp[ word2.Length];
        }

        /// <summary>
        /// Using Longest Common Subsequence- Dynamic Programming
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public int MinDistanceDp(string word1, string word2)
        {
            var dp = new int[word1.Length + 1, word2.Length + 1];
            for (int i = 0; i < word1.Length; i++)
            {
                for (int j = 0; j < word2.Length; j++)
                {
                    if (word1[i] == word2[j])
                    {
                        dp[i + 1, j + 1] = dp[i, j] + 1;
                    }
                    else
                    {
                        dp[i + 1, j + 1] = Math.Max(dp[i + 1, j], dp[i, j + 1]);
                    }
                }
            }

            return word1.Length + word2.Length - 2 * dp[word1.Length,word2.Length];
        }



        /// <summary>
        /// Longest Common Subsequence with Memoization 
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public int MinDistanceMemo(string word1, string word2)
        {
            var memo = new int[word1.Length + 1, word2.Length + 1];
            for (int i = 0; i < memo.GetLength(0); i++)
            {
                for (int j = 0; j < memo.GetLength(1); j++)
                {
                    memo[i, j] = -1;
                }
            }
            return word1.Length + word2.Length - 2 * lcsMemo(word1.ToCharArray(), word2.ToCharArray(), word1.Length, word2.Length, memo);
        }

        public int lcsMemo(char[] word1, char[] word2, int index1, int index2, int[,] memo)
        {
            if (index1 == 0 || index2 == 0)
                return 0;
            if (memo[index1, index2] != -1)
            {
                return memo[index1, index2];
            }

            if (word1[index1 - 1] == word2[index2 - 1])
            {
                memo[index1, index2] = 1 + lcsMemo(word1, word2, index1 - 1, index2 - 1,memo);
            }
            else
            {
                memo[index1, index2] = Math.Max(lcsMemo(word1, word2, index1 - 1, index2 , memo), lcsMemo(word1, word2, index1, index2 - 1, memo));
            }
            return memo[index1, index2];
        }



        /// <summary>
        /// my solution  Time Limit Exceeded
        /// 
        ///递归分治
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public int MinDistanceMy(string word1, string word2)
        {
            return word1.Length + word2.Length - 2*lcs(word1.ToCharArray(), word2.ToCharArray(), word1.Length, word2.Length);
        }

        public int lcs(char[] word1, char[] word2, int index1, int index2)
        {
            if(index1 == 0 || index2 == 0)
                return 0;

            if (word1[index1 -1] == word2[index2 -1])
            {
                return 1+ lcs(word1, word2, index1 - 1, index2 - 1);
            }
            else
            {
                return  Math.Max(lcs(word1, word2, index1 -1, index2), lcs(word1, word2, index1, index2 - 1)); 
            }
        }
    }
}
