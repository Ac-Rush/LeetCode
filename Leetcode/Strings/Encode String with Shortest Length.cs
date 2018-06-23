using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Strings
{
    /*这个 dp 居然是使用的 string
     * 
     * This is the first question I have answered in Leetcode. I hope you guys will like my solution. The approach here is simple. We will form 2-D array of Strings.
dp[i][j] = string from index i to index j in encoded form.

We can write the following formula as:-
dp[i][j] = min(dp[i][j], dp[i][k] + dp[k+1][j]) or if we can find some pattern in string from i to j which will result in more less length.

Time Complexity = O(n^3)
     * 
     * 
     */
    class Encode_String_with_Shortest_Length
    {
        /// <summary>
        /// 太厉害了
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string Encode(string s)
        {
            string[,] dp = new string[s.Length,s.Length];

            for (int l = 0; l < s.Length; l++)  //  l 是 len
            {
                for (int i = 0; i < s.Length - l; i++)
                {
                    int j = i + l;
                    var substr = s.Substring(i, j + 1 - i);
                    // Checking if string length < 5. In that case, we know that encoding will not help.
                    if (j - i < 4)
                    {
                        dp[i,j] = substr;
                    }
                    else
                    {
                        dp[i,j] = substr;
                        // Loop for trying all results that we get after dividing the strings into 2 and combine the   results of 2 substrings
                        for (int k = i; k < j; k++)
                        {
                            if ((dp[i,k] + dp[k + 1,j]).Length < dp[i,j].Length)
                            {
                                dp[i,j] = dp[i,k] + dp[k + 1,j];
                            }
                        }

                        // Loop for checking if string can itself found some pattern in it which could be repeated.
                        for (int k = 0; k < substr.Length; k++)
                        {
                            String repeatStr = substr.Substring(0, k + 1);
                            if (repeatStr != null
                               && substr.Length % repeatStr.Length == 0
                               && substr.Replace(repeatStr, "").Length == 0)
                            {
                                String ss = substr.Length / repeatStr.Length + "[" + dp[i,i + k] + "]";
                                if (ss.Length < dp[i,j].Length)
                                {
                                    dp[i,j] = ss;
                                }
                            }
                        }
                    }
                }
            }

            return dp[0,s.Length - 1];
        }



       
    }
}
