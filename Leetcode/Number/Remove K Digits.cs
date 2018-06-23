using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Number
{
    public class Remove_K_Digits
    {

        public string RemoveKdigits(string num, int k)
        {
            int digits = num.Length - k;
            char[] stk = new char[num.Length];
            int top = 0;
            // k keeps track of how many characters we can remove
            // if the previous character in stk is larger than the current one
            // then removing it will get a smaller number
            // but we can only do so when k is larger than 0
            for (int i = 0; i < num.Length; ++i)
            {
                char c = num[i];
                while (top > 0 && stk[top - 1] > c && k > 0)
                {
                    top -= 1;
                    k -= 1;
                }
                stk[top++] = c;
            }
            // find the index of first non-zero digit
            int idx = 0;
            while (idx < digits && stk[idx] == '0') idx++;
            return idx == digits ? "0" : new string(stk, idx, digits - idx);
        }

        public static string RemoveKdigitsMy(string num, int k)
        {
            var dp = new string[k + 1, num.Length + 1];
            for (int i = 0; i < k + 1; i++)
            {
                dp[i, 0] = "";
            }
            for (int i = 1; i <= num.Length  ; i++)
            {
                dp[0, i] = num.Substring(0, i);
            }
            for (int i = 1; i <= k; i++)
            {
                for (int j = 1; j <= num.Length; j++)
                {
                    var curt = "";
                    var s1 = dp[i - 1, j - 1].TrimStart(new []{'0'});
                    var s2 = (dp[i - 1, j -1] + num[j-1]).TrimStart(new[] { '0' });
                    if (s1.Length > s2.Length || (s1.Length == s2.Length && s1.CompareTo(s2) > 0))
                    {
                        dp[i, j] = s2;
                    }
                    else
                    {
                        dp[i, j] = s1;
                    }
                }
            }
            return dp[k, num.Length];
        }
    }
}
