using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Dynamic_Programming
{
    class Palindrome_Partitioning_II
    {
        public int MinCut(string s)
        {
            int n = s.Length;
            int[] cut = new int[n + 1];
            for (int i = 0; i <= n; i++) cut[i] = i - 1;
            for (int i = 0; i < n; i++)
            {
                //从i 一步一步 左右搜回文，知道不是回文
                //      s[i]
                //s[i-1]  s[i] s[i+1]
                for (int j = 0; i - j >= 0 && i + j < n && s[i - j] == s[i + j]; j++) // odd length palindrome
                    cut[i + j + 1] = Math.Min(cut[i + j + 1], 1 + cut[i - j]); //是当前最小，还是 cut[i-j] +1 最小， 以为 [i-j.... i+j]是一个回文

                for (int j = 1; i - j + 1 >= 0 && i + j < n && s[i - j + 1] == s[i + j]; j++) // even length palindrome
                    cut[i + j + 1] = Math.Min(cut[i + j + 1], 1 + cut[i - j + 1]);
            }
            return cut[n];
        }
    }
}
