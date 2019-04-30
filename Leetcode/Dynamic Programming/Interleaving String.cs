using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Interleaving_String
    {
        /// <summary>
        /// 我的答案
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="s3"></param>
        /// <returns></returns>
        public bool IsInterleave(string s1, string s2, string s3)
        {
            int l1 = s1.Length, l2 = s2.Length;
            if (s1.Length + s2.Length != s3.Length) return false;
            bool[,] dp = new bool[l1 + 1, l2 + 1];
            dp[0, 0] = true;
            for (int i = 1; i <= l1; i++)
            {
                dp[i, 0] = dp[i - 1, 0] && s3[i - 1] == s1[i - 1]; //bug was    dp[i, 0] =  s3[i - 1] == s1[i - 1];
            }
            for (int i = 1; i <= l2; i++)
            {
                dp[0, i] = dp[0, i - 1] && s3[i - 1] == s2[i - 1];  //bug 
            }
            for (int i = 1; i <= l1; i++)
            {
                for (int j = 1; j <= l2; j++)
                {
                    dp[i, j] = (s3[i + j - 1] == s1[i - 1] && dp[i - 1, j]) || (s3[i + j - 1] == s2[j - 1] && dp[i, j - 1]);

                }
            }
            return dp[l1, l2];
        }


        public bool IsInterleave2(string s1, string s2, string s3)
        {
            int l1 = s1.Length, l2 = s2.Length;
            if (s1.Length + s2.Length != s3.Length) return false;
            bool[,] dp = new bool[l1 + 1, l2 + 1];
            dp[0, 0] = true;
            for (int i = 1; i <= l1; i++)
            {
                dp[i, 0] = dp[i - 1, 0] && s3[i - 1] == s1[i - 1]; //bug was    dp[i, 0] =  s3[i - 1] == s1[i - 1];
            }
            for (int i = 1; i <= l2; i++)
            {
                dp[0, i] = dp[0, i - 1] && s3[i - 1] == s2[i - 1];  //bug 
            }
            for (int i = 1; i <= l1; i++)
            {
                for (int j = 1; j <= l2; j++)
                {
                    dp[i, j] = (s3[i + j - 1] == s1[i - 1] && dp[i - 1, j]) || (s3[i + j - 1] == s2[j - 1] && dp[i, j - 1]);

                }
            }
            return dp[l1, l2];
        }
    }
}
