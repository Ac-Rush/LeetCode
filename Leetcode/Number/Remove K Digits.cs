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

        public string RemoveKdigitsMy2(string num, int k)
        {
            var dp = new string[k + 1, num.Length + 1];
            for (int i = 0; i < k + 1; i++)
            {
                dp[i, 0] = "";
            }
            for (int i = 1; i <= num.Length; i++)
            {
                dp[0, i] = num.Substring(0, i);
            }
            for (int i = 1; i <= k; i++)
            {
                for (int j = 1; j <= num.Length; j++)
                {
                    var curt = "";
                    var s1 = dp[i - 1, j - 1].TrimStart(new[] { '0' });
                    var s2 = (dp[i - 1, j - 1] + num[j - 1]).TrimStart(new[] { '0' });
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
