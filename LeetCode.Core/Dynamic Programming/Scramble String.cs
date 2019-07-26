using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Scramble_String
    {
        public bool IsScramble(string s1, string s2)
        {
            if (s1.Equals(s2)) return true;

            int[] letters = new int[26];
            for (int i = 0; i < s1.Length; i++)
            {
                letters[s1[i] - 'a']++;
                letters[s2[i] - 'a']--;
            }
            for (int i = 0; i < 26; i++) if (letters[i] != 0) return false;

            for (int i = 1; i < s1.Length; i++)
            {
                if (IsScramble(s1.Substring(0, i), s2.Substring(0, i))
                    && IsScramble(s1.Substring(i), s2.Substring(i))) return true;
                if (IsScramble(s1.Substring(0, i), s2.Substring(s2.Length - i))
                    && IsScramble(s1.Substring(i), s2.Substring(0, s2.Length - i))) return true;
            }
            return false;
        }
    }

    /*
     * //动态规划
     *  设状态为 f[n][i][j] ，表示长度为n， 起点为 s1[i] 和起点为 s2[j] 两个字符串是否为 scramble,  状态转移方程
     *  f[n][i][j]  = (f[k][i][j]  && f[n-k][i+k][j+k] ) 
     *               || (f[k][j][j+n-k]  && f[n-k][i+k][j])
     * 
     */
}
