using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BackTrack
{
   public   class Regular_Expression_Matching
    {

        public bool IsMatch2(string text, string pattern)
        {
            if (string.IsNullOrEmpty(pattern)) return string.IsNullOrEmpty(text);
            bool first_match = (!string.IsNullOrEmpty(text) &&
                                   (pattern[0] == text[0] || pattern[0] == '.'));

            if (pattern.Length >= 2 && pattern[1] == '*')
            {
                return (IsMatch2(text, pattern.Substring(2)) ||
                        (first_match && IsMatch2(text.Substring(1), pattern)));
            }
            else
            {
                return first_match && IsMatch2(text.Substring(1), pattern.Substring(1));
            }
        }




        public bool IsMatch(string text, string pattern)
        {
            var memo = new bool?[text.Length + 1, pattern.Length + 1];
            return IsMatch(text.ToCharArray(), pattern.ToCharArray(), 0, 0, memo);
        }

       /// <summary>
       /// memo 的方式
       /// </summary>
       /// <param name="text"></param>
       /// <param name="pattern"></param>
       /// <param name="tIndex"></param>
       /// <param name="pIndex"></param>
       /// <param name="memo"></param>
       /// <returns></returns>
        public bool IsMatch(char[] text, char[] pattern, int tIndex, int pIndex , bool?[,] memo)
        {
            if (pIndex == pattern.Length) return tIndex == text.Length;
            if (memo[tIndex, pIndex] != null)
            {
                return memo[tIndex, pIndex].Value;
            }
           
            bool first_match = (tIndex != text.Length &&
                                   (pattern[pIndex] == text[tIndex] || pattern[pIndex] == '.'));

            bool ret;
            if (pattern.Length > pIndex + 1 && pattern[pIndex + 1] == '*')
            {
                 ret= (IsMatch(text, pattern, tIndex, pIndex +2, memo) ||
                        (first_match && IsMatch(text, pattern, tIndex + 1, pIndex , memo)));
              
            }
            else
            {
                return first_match && IsMatch(text, pattern, tIndex + 1, pIndex + 1, memo);
            }
            memo[tIndex, pIndex] = ret;
            return ret;
        }

        /// <summary>
        /// dp 的方法
        /// </summary>
        /// <param name="text"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public bool IsMatchDp(string text, string pattern)
        {
            var dp = new bool[text.Length + 1,pattern.Length + 1];
            dp[text.Length,pattern.Length] = true;

            for (int i = text.Length; i >= 0; i--)
            {
                for (int j = pattern.Length - 1; j >= 0; j--)
                {
                    var first_match = (i < text.Length &&
                                           (pattern[j] == text[i] ||
                                            pattern[j] == '.'));
                    if (j + 1 < pattern.Length && pattern[j + 1] == '*')
                    {
                        dp[i,j] = dp[i,j + 2] || first_match && dp[i + 1,j];
                    }
                    else
                    {
                        dp[i,j] = first_match && dp[i + 1,j + 1];
                    }
                }
            }
            return dp[0,0];
        }
    }
}
