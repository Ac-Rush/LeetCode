using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.BackTrack
{
   public   class Regular_Expression_Matching
    {

        public bool IsMatch(string s, string p)
        {
            return IsMatch(s, p, 0, 0);
        }

        public bool IsMatch(string s, string p, int indexS, int indexP)
        {
            if (p.Length == indexP)
            {
                return s.Length == indexS;
            }
            bool first_match = (s.Length != indexS &&
                                       (p[indexP] == s[indexS] || p[indexP] == '.'));

            if (p.Length - 1 > indexP && p[indexP + 1] == '*')
            {
                return (IsMatch(s, p, indexS, indexP + 2) ||
                        (first_match && IsMatch(s, p, indexS + 1, indexP)));
            }
            else
            {
                return first_match && IsMatch(s, p, indexS + 1, indexP + 1);
            }
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
        public bool IsMatch(string s, string p, int indexS, int indexP, bool?[,] memo)
        {
            if (memo[indexS, indexP].HasValue) return memo[indexS, indexP].Value;
            if (p.Length == indexP)
            {
                return s.Length == indexS;
            }
            bool first_match = (s.Length != indexS &&
                                       (p[indexP] == s[indexS] || p[indexP] == '.'));
            var ans = false;
            if (p.Length - 1 > indexP && p[indexP + 1] == '*')
            {
                ans = (IsMatch(s, p, indexS, indexP + 2, memo) ||
                        (first_match && IsMatch(s, p, indexS + 1, indexP, memo)));
            }
            else
            {
                ans = first_match && IsMatch(s, p, indexS + 1, indexP + 1, memo);
            }
            memo[indexS, indexP] = ans;
            return ans;
        }

        /// <summary>
        /// dp 的方法 从后向前推
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
